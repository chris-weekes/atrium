using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using atriumBE;
using lmDatasets;

 namespace LawMate.UserControls
{
    public delegate void BrowseIssueEventHandler(object sender, TreeNodeMouseClickEventArgs e);
    public delegate void IssueSelectionChangeEventHandler(object sender, TreeViewEventArgs e);

    public partial class ucBrowseIssues : UserControl
    {
        FileManager myFM;
        public event BrowseIssueEventHandler IssueSelected;
        public event IssueSelectionChangeEventHandler IssueNavigated;


        private appDB.IssueRow selectedIssue;
        private string SelectedIssueLangText = "IssueNameEng";
        public appDB.IssueRow SelectedIssue
        {
            get { return selectedIssue; }
        }

        public string IssuePath
        {
            get
            {
                return tvIssues.SelectedNode.FullPath;
            }
        }
        public ucBrowseIssues()
        {
            InitializeComponent();
            tvIssues.DrawMode = TreeViewDrawMode.OwnerDrawText;
            tvIssues.DrawNode += new DrawTreeNodeEventHandler(tvIssues_DrawNode);
        }

        void tvIssues_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            try
            {
                Font f = e.Node.NodeFont != null ? e.Node.NodeFont : e.Node.TreeView.Font;
                Size sz = TextRenderer.MeasureText(e.Node.Text, f);
                Rectangle rc = new Rectangle(e.Bounds.X - 1, e.Bounds.Y, sz.Width + 2, e.Bounds.Height);
                Color fore = e.Node.ForeColor;
                if (fore == Color.Empty) fore = e.Node.TreeView.ForeColor;
                // Have to indicate focus somehow, how about yellow foreground text?
                if (e.Node == e.Node.TreeView.SelectedNode)
                {
                    fore = SystemColors.HighlightText;
                    if ((e.State & TreeNodeStates.Focused) != 0) fore = SystemColors.Window;
                }
                Color back = e.Node.BackColor;
                if (back == Color.Empty) back = e.Node.TreeView.BackColor;
                if (e.Node == e.Node.TreeView.SelectedNode) back = SystemColors.Highlight;
                SolidBrush bbr = new SolidBrush(back);
                e.Graphics.FillRectangle(bbr, rc);
                TextRenderer.DrawText(e.Graphics, e.Node.Text, f, rc, fore, TextFormatFlags.GlyphOverhangPadding);
                bbr.Dispose();

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
        
        public void LoadRoot(atriumManager atmng,int programId)
        {
            //load root
            if (UIHelper.AtMng.AppMan.Language.ToUpper() == "FRE")
                SelectedIssueLangText = "IssueNameFre";

            myFM = atmng.GetFile();
            //selectedIssue = myFM.CurrentFile;

            

            if (programId == 0)
            {
                LoadRootX(atmng,0);
            }
            else
            {
                // load roots based on program issue
                atLogic.ObjectBE obe= atmng.GetCodeTableBE("ProgramIssue");
                if(obe.myDT.Rows.Count==0)
                    obe.Load();
                CodesDB.ProgramIssueDataTable pidt = (CodesDB.ProgramIssueDataTable)obe.myDT;
                foreach (CodesDB.ProgramIssueRow pir in pidt)
                {
                    if (pir.ProgramId == programId)
                        LoadRootX(atmng, pir.IssueId);
                }
            }

            tvIssues.ExpandAll();
        }

        private void LoadRootX(atriumManager atmng,int issueId)
        {
            appDB.IssueRow rootIssue = atmng.DB.Issue.FindByIssueId(issueId);

            TreeNode nd = new TreeNode();

            nd.Text = rootIssue[SelectedIssueLangText].ToString();
            nd.Tag = rootIssue;
            nd.Name = rootIssue.IssueId.ToString();


            tvIssues.Nodes.Add(nd);
            LoadLevel(nd, issueId);
        }

        private void checkNodeForFileId(TreeNode trnd, appDB.IssueRow issue)
        {
            if (issue.IsFileIdNull())
            {
                trnd.ImageKey = "folder.gif";
                trnd.SelectedImageKey = "folder.gif";
            }
        }

        private void LoadLevel(TreeNode pnd, int parentIssueId)
        {
          //  myFM.AtMng.GetIssue().LoadByParentIssueId(parentIssueId);

            appDB.IssueRow[]  issueRows = (appDB.IssueRow[])myFM.AtMng.DB.Issue.Select("ParentIssueId=" + parentIssueId.ToString());
            foreach (appDB.IssueRow isr in issueRows)
            {
                TreeNode nd = new TreeNode();

                nd.Text = isr[SelectedIssueLangText].ToString();
                nd.Tag = isr;
                nd.Name = isr.IssueId.ToString();
                
                checkNodeForFileId(nd, isr);
                pnd.Nodes.Add(nd);
            }
        }

        public void FindIssue(appDB.IssueRow ir)
        {
            TreeNode tn = FindIssueNode(ir);
            if (tn != null)
                tvIssues.SelectedNode = tn;
 
        }


        public TreeNode FindIssueNode(appDB.IssueRow ir)
        {
            TreeNode tn = FindIssueNodeX(ir);
            if (tn != null)
            {
                tn.EnsureVisible();
                selectedIssue = ir;
            }
            return tn;
        }

        private TreeNode FindIssueNodeX(appDB.IssueRow ir)
        {
            TreeNode[] tns = tvIssues.Nodes.Find(ir.IssueId.ToString(), true);
            foreach (TreeNode tn in tns)
            {
                    return tn;
            }
            //not found so load node
       //     myFM.AtMng.GetIssue().Load();

            //myFM.GetIssue().LoadByParentIssueId(ir.ParentIssueId);
            appDB.IssueRow[] idr = (appDB.IssueRow[])myFM.AtMng.DB.Issue.Select("IssueId=" + ir.ParentIssueId.ToString());

            if (idr.Length > 0)
            {
                appDB.IssueRow pir = idr[0];
                TreeNode tn1 = FindIssueNode(pir);
                if (tn1 != null)
                {
                    LoadLevel(tn1, pir.IssueId);
                    return tn1.Nodes[ir.IssueId.ToString()];
                }
                else
                    return null;
            }
            else
                return null;
        }

        private void tvIssues_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                selectedIssue = (appDB.IssueRow)e.Node.Tag;
                if (e.Node.Nodes.Count == 0)
                {
                    LoadLevel(e.Node, selectedIssue.IssueId);
                    e.Node.Expand();
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void tvIssues_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                selectedIssue = (appDB.IssueRow)e.Node.Tag;
                if(IssueSelected!=null)
                    IssueSelected(this, e);
            }
            catch(Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }

        private void tvIssues_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                selectedIssue = (appDB.IssueRow)e.Node.Tag;
                if (IssueNavigated != null)
                    IssueNavigated(this, e);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void tvIssues_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (tvIssues.SelectedNode != null && tvIssues.SelectedNode.Nodes.Count == 0)
                    {
                        LoadLevel(tvIssues.SelectedNode, selectedIssue.IssueId);
                        tvIssues.SelectedNode.Expand();
                    }
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }


    }
}
