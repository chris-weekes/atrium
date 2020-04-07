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
    public delegate void BrowseEventHandler(object sender, FileContextEventArgs e);
    public delegate void TreeNodeDoubleClickEventHandler(object sender, TreeNodeMouseClickEventArgs e);

    public partial class ucBrowse : UserControl
    {
        FileManager myFM;

        private bool showContextMenu = true;
        public bool ShowContextMenu
        {
            get { return showContextMenu; }
            set
            {
                showContextMenu = value;
                if (myFTV != null)
                    myFTV.ShowContextMenu = showContextMenu;
            }
        }



        public ucFileContextMenu FileContextMenu
        {
            get
            {
                return ucFileContextMenu1;
            }
        }

        public event BrowseEventHandler FileSelected;
        public event ContextEventHandler ContextMenuClicked;
        public event TreeNodeDoubleClickEventHandler TreeNodeDoubleClicked;

        public FileTreeView myFTV;

        public void HideShortcutsAndXRefs(bool hideShortcuts, bool hideXrefs, bool hideDocShortcuts)
        {
            if (myFTV != null)
                myFTV.HideShortcutsAndXRefs(hideShortcuts, hideXrefs, hideDocShortcuts);
        }

        private bool displayOptionPanel = true;
        public bool DisplayOptionPanel
        {
            get
            {
                return displayOptionPanel;
            }
            set
            {
                displayOptionPanel = value;
                pnlTop.Closed = !value;
            }
        }

        private bool displayJumpToOptions = true;
        public bool DisplayJumpToOptions
        {
            get
            {
                return displayJumpToOptions;
            }
            set
            {
                displayJumpToOptions = value;
                if (value == true)
                    cmdJump.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                else
                    cmdJump.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            }
        }


        public bool ShowFileNumber
        {
            get
            {
                if (myFTV == null)
                    return false;
                return myFTV.ShowFileNumber;
            }
            set
            {
                if (myFTV == null)
                    return;
                if (myFTV.ShowFileNumber != value)
                {
                    myFTV.ShowFileNumber = value;
                    FilterApplied();
                }
                if (value)
                {
                    cmdShowFN.Checked = Janus.Windows.UI.InheritableBoolean.True;
                }
                else
                {
                    cmdShowFN.Checked = Janus.Windows.UI.InheritableBoolean.False;
                }
                   

                    //myFTV.ShowFileNumber = value;

                    //tvFiles.BeginUpdate();
                    ////resort tree
                    //myFTV.Resort(tvFiles.Nodes);
                    //tvFiles.EndUpdate();
                    ////clean up non-open nodes too
                    //appDB.EFileSearchRow er;

                    //foreach (TreeNode nd in myFTV.nonOpenNodes.Values)
                    //{
                    //    er = (appDB.EFileSearchRow)nd.Tag;
                    //    if (myFTV.ShowFileNumber & myFM.DB.FileMetaType.FindByMetaTypeCode(er.MetaType).HasFileNumber)
                    //        nd.Text = er.FileNumber + " - " + er.Name;
                    //    else
                    //        nd.Text = er.Name;

                    //}
                //}

            }
        }

        public bool ShowOnlyOpenFiles
        {
            get
            {
                if (myFTV == null)
                    return false;
                return myFTV.ShowOnlyOpenFiles;
            }
            set
            {

                if (myFTV == null)
                    return;
                if (myFTV.ShowOnlyOpenFiles != value)
                {
                    myFTV.ShowOnlyOpenFiles = value;
                    FilterApplied();

                    //if (myFTV.ShowOnlyOpenFiles)
                    //{
                    //    tvFiles.BeginUpdate();
                    //    ReloadToDisplayOnlyOpenFiles(tvFiles.Nodes);
                    //    tvFiles.EndUpdate();
                    //}
                    //else
                    //{
                    //    tvFiles.BeginUpdate();
                    //    ReloadNonOpenNodes(tvFiles.Nodes);
                    //    myFTV.nonOpenNodes.Clear();
                    //    tvFiles.EndUpdate();
                    //}
                }
                if (value)
                {
                    cmdShowOpenFiles.Checked = Janus.Windows.UI.InheritableBoolean.True;
                }
                else
                {
                    cmdShowOpenFiles.Checked = Janus.Windows.UI.InheritableBoolean.False;
                }
            }
        }

        public bool HideXrefs
        {
            get
            {
                if (myFTV == null)
                    return false;
                return myFTV.HideXrefs;
            }
            set
            {
                if (myFTV == null)
                    return;
                if (myFTV.HideXrefs != value)
                {
                    myFTV.HideXrefs = value;
                    FilterApplied();
                }
            }
        }

        private void FilterApplied()
        {
            Cursor.Current = Cursors.WaitCursor;
            tvFiles.Visible = false;
            appDB.EFileSearchRow efsr = myFTV.SelectedFile;
            ReloadRoot();
            myFTV.FindNode(efsr);
            tvFiles.BeginUpdate();
            //resort tree
            myFTV.Resort(tvFiles.Nodes);
            tvFiles.EndUpdate();
            //tvFiles.Sort();
            if (tvFiles.Nodes.Find(efsr.FileId.ToString(), true).Length > 0)
                tvFiles.SelectedNode = tvFiles.Nodes.Find(efsr.FileId.ToString(), true)[0];
            Cursor.Current = Cursors.Default;
            tvFiles.Visible = true;
            tvFiles.ExpandAll();
        }

        public void clearTreeViewNodes()
        {
            //if(myFTV!=null)
            //    myFTV.nonOpenNodes.Clear();
            tvFiles.Nodes.Clear();

        }
        //private void ReloadNonOpenNodes(TreeNodeCollection nodes)
        //{
        //    foreach (TreeNode nd in nodes)
        //    {
        //        int i = 0;
        //        do
        //        {
        //            if (myFTV.nonOpenNodes.ContainsKey(nd.Name + " - " + i.ToString()))
        //            {
        //                nd.Nodes.Add(myFTV.nonOpenNodes[nd.Name + " - " + i.ToString()]);

        //            }
        //            else
        //                break;

        //            i++;
        //        }
        //        while( true);
        //        ReloadNonOpenNodes(nd.Nodes);
        //    }
        //}
        //private void ReloadToDisplayOnlyOpenFiles(TreeNodeCollection nodes)
        //{
        //    appDB.EFileSearchRow er;
        //    int i = 0;
        //    foreach (TreeNode nd in nodes)
        //    {
        //        er = (appDB.EFileSearchRow)nd.Tag;
        //        if (er.StatusCode != "O")
        //        {
        //            //add node to collection keyed by parent node
        //            myFTV.nonOpenNodes.Add(nd.Parent.Name + " - " + i.ToString(), nd);
        //            i++;
        //            nd.Remove();
        //        }
        //        else
        //            ReloadToDisplayOnlyOpenFiles(nd.Nodes);
        //    }
        //}

        public appDB.EFileSearchRow SelectedFile
        {
            get { return myFTV.SelectedFile; }
        }

        public ucBrowse()
        {
            InitializeComponent();
            ImageList imgList = UIHelper.browseImgList();
            tvFiles.ImageList = imgList;
            tvFiles.DrawMode = TreeViewDrawMode.OwnerDrawText;
            tvFiles.DrawNode += new DrawTreeNodeEventHandler(tvFiles_DrawNode);
            if (UIHelper.getScalingFactor() > 1)
                tvFiles.ItemHeight = tvFiles.ItemHeight + 2;
        }


        int RootFileId;
        bool rootHasChildren = true;
        public bool RootHasChildren
        {
            get { return rootHasChildren; }
        }

        public void LoadRoot(atriumManager atmng, int rootFileId, bool hideShortcuts, bool hideXRefs, bool hideDocShorcuts)
        {
            //should only be called once
            //subsequent calls should use reloadroot

            //this.ShowFileNumber = atmng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.FTVShowFileNumber, true);
            //this.ShowOnlyOpenFiles = atmng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.FTVShowOpenFiles, false);
            //this.HideXrefs = atmng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.FTVShowXrefs, false);


            myFTV = new FileTreeView(atmng, tvFiles, ucFileContextMenu1);
            ucFileContextMenu1.LoadLabels();
            myFTV.ShowContextMenu = showContextMenu;
            ucFileContextMenu1.Ftv = myFTV;
            myFTV.FileSelected += new LawMate.BrowseEventHandler(myFTV_FileSelected);
            myFTV.NodeDoubleClicked += new TreeDoubleClickEventHandler(myFTV_NodeDoubleClicked);
            myFTV.HideShortcutsAndXRefs(hideShortcuts, hideXRefs, hideDocShorcuts);
            myFTV.LoadRoot(rootFileId, false);
            RootFileId = rootFileId;

            this.ShowFileNumber = atmng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.FTVShowFileNumber, true);
            this.ShowOnlyOpenFiles = atmng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.FTVShowOpenFiles, false);
            this.HideXrefs = atmng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.FTVShowXrefs, false);


            if (tvFiles.Nodes.Count == 1)
                rootHasChildren = false;

        }

        void myFTV_NodeDoubleClicked(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (TreeNodeDoubleClicked != null)
                TreeNodeDoubleClicked(sender, e);
        }


        void myFTV_FileSelected(object sender, FileContextEventArgs e)
        {
            if (FileSelected != null)
                FileSelected(sender, e);
        }



        public void ReloadRoot()
        {
            this.clearTreeViewNodes();
            myFTV.LoadRoot(RootFileId, false);
        }

        private void ucFileContextMenu1_ContextMenuClicked(object sender, FileContextEventArgs e)
        {
            if (ContextMenuClicked != null)
                ContextMenuClicked(sender, e);
        }

        private void tvFiles_DrawNode(object sender, DrawTreeNodeEventArgs e)
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
                TextRenderer.DrawText(e.Graphics, e.Node.Text, f, rc, fore, TextFormatFlags.GlyphOverhangPadding | TextFormatFlags.NoPrefix);
                bbr.Dispose();

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }


        public void FindFile(int fileId)
        {
            appDB.EFileSearchRow esr = myFTV.myAtmng.FileSearchByFileId(fileId)[0];
            TreeNode tn = myFTV.FindNode(esr);
            if (tn != null)
                tn.TreeView.Focus();
            else
                MessageBox.Show("The file could not be located.");

        }

        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {

                Janus.Windows.UI.CommandBars.UICommandBar bar = uiCommandManager1.CommandBars[0];
                if (bar.Commands.Contains(e.Command.Key) && bar.Commands[e.Command.Key].Commands.Count > 0)
                    bar.Commands[e.Command.Key].Expand();

                switch (e.Command.Key)
                {
                    case "cmdShowFN":
                        if (cmdShowFN.Checked == Janus.Windows.UI.InheritableBoolean.True)
                            this.ShowFileNumber = true;
                        else
                            this.ShowFileNumber = false;

                        UIHelper.AtMng.OfficeMng.GetOfficerPrefs().SetPref(OfficerPrefsBE.FTVShowFileNumber, ShowFileNumber);
                        break;
                    case "cmdShowOpenFiles":
                        if (cmdShowOpenFiles.Checked == Janus.Windows.UI.InheritableBoolean.True)
                            this.ShowOnlyOpenFiles = true;
                        else
                            this.ShowOnlyOpenFiles = false;

                        UIHelper.AtMng.OfficeMng.GetOfficerPrefs().SetPref(OfficerPrefsBE.FTVShowOpenFiles, ShowOnlyOpenFiles);
                        break;
                    case "cmdHideXRef":
                        if (cmdHideXRef.Checked == Janus.Windows.UI.InheritableBoolean.True)
                            this.HideXrefs = true;
                        else
                            this.HideXrefs = false;

                        UIHelper.AtMng.OfficeMng.GetOfficerPrefs().SetPref(OfficerPrefsBE.FTVShowXrefs, HideXrefs);
                        break;
                    case "cmdReset":
                        ReloadRoot();
                        break;
                    case "cmdJumpOffice":
                        FindFile(myFTV.myAtmng.OfficeLoggedOn.OfficeFileId);
                        break;
                    case "cmdJumpPersonal":
                        FindFile(myFTV.myAtmng.OfficerLoggedOn.MyFileId);
                        break;
                    case "cmdJumpShortcuts":
                        FindFile(myFTV.myAtmng.OfficerLoggedOn.ShortcutsId);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }


    }


}
