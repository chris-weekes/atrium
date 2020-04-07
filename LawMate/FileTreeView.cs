using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using atriumBE;
using lmDatasets;


 namespace LawMate
{
    public delegate void BrowseEventHandler(object sender, FileContextEventArgs e);
    public delegate void ContextEventHandler(object sender, FileContextEventArgs e);
    public delegate void TreeDoubleClickEventHandler(object sender, TreeNodeMouseClickEventArgs e);
    
    public class FileTreeView
    {

        //constants for dynamic menus
        public const string dmFILENEW = "FileNew";
        public const string dmACTIVITY = "Activity";
        public const string dmTIMEKEEP = "Timekeep";
        public const string dmAppt = "Appt";
        public const string dmHearing = "Hearing";
        public const string dmMassActivity = "MassActivity";
        public const string dmApptNew = "ApptNew";
        
        public event BrowseEventHandler FileSelected;
        public event TreeDoubleClickEventHandler NodeDoubleClicked;

        //        TreeNode src;

        public atriumManager myAtmng;


        private bool hideShortcuts = false;
        private bool hideXrefs = false;
        private bool hideDocShorcuts = false;
        private bool isExplorer = false;

        public bool HideXrefs
        {
            get { return hideXrefs; }
            set { hideXrefs = value; }
        }
        public bool HideShortcuts
        {
            get { return hideShortcuts; }
            set { hideShortcuts = value; }
        }
        public bool HideDocShortcuts
        {
            get { return hideDocShorcuts; }
            set { hideDocShorcuts = value; }
        }

        public void HideShortcutsAndXRefs(bool HideShortcuts, bool HideXRefs, bool HideDocShortcuts)
        {
            hideShortcuts = HideShortcuts;
            hideXrefs = HideXRefs;
            hideDocShorcuts = HideDocShortcuts;
        }

        private bool showContextMenu = true;
        public bool ShowContextMenu
        {
            get { return showContextMenu; }
            set { showContextMenu = value;
            if (showContextMenu)
            {
                myFCM.uiCommandManager1.SetContextMenu(tvFiles, myFCM.uiContextMenu6);

            }
            else
            {
                myFCM.uiCommandManager1.SetContextMenu(tvFiles, null);

            }
            }
        }

        private appDB.EFileSearchRow selectedFile;
        public appDB.EFileSearchRow SelectedFile
        {
            get { return selectedFile; }
            set { selectedFile = value; }
        }

        TreeView tvFiles;
        ucFileContextMenu myFCM;
        string ShortcutTo = Properties.Resources.ShortcutTo;
        string XRefTo = Properties.Resources.CrossReferencedTo;

        //public Dictionary<string, TreeNode> nonOpenNodes = new Dictionary<string, TreeNode>();

        public bool ShowFileNumber = true;
        public bool ShowOnlyOpenFiles = false;

        public FileTreeView(atriumManager atmng, TreeView tv, ucFileContextMenu fcm)
        {
            myFCM = fcm;
            myAtmng = atmng;
            myAtmng.FXUpdate += new atLogic.UpdateEventHandler(myAtmng_FXUpdate);
            myAtmng.EfileUpdate += new atLogic.UpdateEventHandler(myAtmng_EfileUpdate);
            tvFiles = tv;
            tvFiles.LabelEdit = false;

            myFCM.uiCommandManager1.SetContextMenu(tvFiles, myFCM.uiContextMenu6);

           
            tvFiles.MouseDown += new MouseEventHandler(tvFiles_MouseDown);
            tvFiles.NodeMouseClick += tvFiles_NodeMouseClick;
            tvFiles.AfterSelect += new TreeViewEventHandler(tvFiles_AfterSelect);
            tvFiles.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvFiles_NodeMouseDoubleClick);
            tvFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvFiles_DragDrop);
            tvFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvFiles_DragEnter);
            tvFiles.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvFiles_ItemDrag);
            tvFiles.DragOver += new System.Windows.Forms.DragEventHandler(this.tvFiles_DragOver);
            tvFiles.BeforeLabelEdit += new NodeLabelEditEventHandler(tvFiles_BeforeLabelEdit);
            tvFiles.AfterLabelEdit += new NodeLabelEditEventHandler(tvFiles_AfterLabelEdit);
        }


        void tvFiles_MouseDown(object sender, MouseEventArgs e)
        {
            if (ShowContextMenu)
            {
                //System.Diagnostics.Trace.WriteLine("tvFiles_MouseDown");
                TreeNode nd = ((TreeView)sender).GetNodeAt(e.X, e.Y);
                if (nd == null || nd.Tag == null)
                    myFCM.uiCommandManager1.SetContextMenu(tvFiles, myFCM.uiContextMenu6);
                else
                {
                    if (nd.Tag.GetType() == typeof(appDB.EFileSearchRow))
                    {
                        appDB.EFileSearchRow er = (appDB.EFileSearchRow)nd.Tag;

                        if (er.LinkType == (int)FXLinkType.ParentChild)
                        {
                            if (er.MetaType.ToUpper() != "SC")//Not a Shortcut Container File
                            {
                                myFCM.uiCommandManager1.SetContextMenu(tvFiles, myFCM.uiContextMenu4);
                            }
                            else
                            {
                                myFCM.uiCommandManager1.SetContextMenu(tvFiles, myFCM.uiContextMenu1);
                            }
                        }
                        else if (er.LinkType == (int)FXLinkType.Shortcut)
                        {
                            myFCM.uiCommandManager1.SetContextMenu(tvFiles, myFCM.uiContextMenu3);
                        }
                        else if (er.LinkType == (int)FXLinkType.XRef)
                        {
                            myFCM.uiCommandManager1.SetContextMenu(tvFiles, myFCM.uiContextMenu5);
                        }
                    }
                    else if (nd.Tag.GetType() == typeof(docDB.DocXRefRow) && nd.Name.StartsWith("nodeDocXRef"))
                    {
                        myFCM.uiCommandManager1.SetContextMenu(tvFiles, myFCM.uiContextMenu2);
                    }
                    else
                        myFCM.uiCommandManager1.SetContextMenu(tvFiles, myFCM.uiContextMenu6);
                }
            }
            else
            {
                TreeNode nd = ((TreeView)sender).GetNodeAt(e.X, e.Y);
                if (nd == null || nd.Tag == null)
                    myFCM.uiCommandManager1.SetContextMenu(tvFiles, myFCM.uiContextMenu6);
                else
                {
                    if (nd.Tag.GetType() == typeof(appDB.EFileSearchRow))
                    {
                        appDB.EFileSearchRow er = (appDB.EFileSearchRow)nd.Tag;

                        if (er.LinkType == (int)FXLinkType.ParentChild)
                        {
                            myFCM.uiCommandManager1.SetContextMenu(tvFiles, myFCM.uiContextMenu6);  
                        }
                        else if (er.LinkType == (int)FXLinkType.Shortcut)
                        {
                            myFCM.uiCommandManager1.SetContextMenu(tvFiles, myFCM.uiContextMenu7);
                        }
                        else if (er.LinkType == (int)FXLinkType.XRef)
                        {
                            myFCM.uiCommandManager1.SetContextMenu(tvFiles, myFCM.uiContextMenu7);
                        }
                    }
                    else
                        myFCM.uiCommandManager1.SetContextMenu(tvFiles, myFCM.uiContextMenu6);
                }
                //show refresh and navigate options only
                //will not reference lmwinhelper
                //myFCM.uiCommandManager1.SetContextMenu(tvFiles, myFCM.uiContextMenu7);
            }
        }

        private void FindByXRefId(List<TreeNode> oldNodes,TreeNodeCollection nds,int id)
        {
            foreach (TreeNode tn in nds)
            {
                FindByXRefId(oldNodes, tn.Nodes, id);
                if (tn.Tag!=null && tn.Tag.GetType() == typeof(appDB.EFileSearchRow))
                {
                    if (!((appDB.EFileSearchRow)tn.Tag).IsxrefIdNull() && ((appDB.EFileSearchRow)tn.Tag).xrefId == id)
                    { oldNodes.Add(tn); }
                }

            }

        }

        void myAtmng_EfileUpdate(object sender, atLogic.UpdateEventArgs e)
        {
            try
            {
               
                //a change to the file structure was detected!
                foreach (atriumDB.EFileRow er in e.ChangedRows)
                {
                    int fileId =(int) er["FileId", System.Data.DataRowVersion.Original];
                    TreeNode[] tns = tvFiles.Nodes.Find(fileId.ToString(), true);
                    foreach (TreeNode tn in tns)
                    {
                    if (er.RowState != System.Data.DataRowState.Deleted)
                    {
                        //WriteNodeText(er, tn, drMetaType);
                    }
                    else
                    {
                        tn.Remove();
                    }
                    }
                }
            }
            catch (Exception x)
            {
            }
        }


        void myAtmng_FXUpdate(object sender, atLogic.UpdateEventArgs e)
        {
            try
            {
                //a change to the file structure was detected!
                foreach (atriumDB.FileXRefRow fxr in e.ChangedRows)
                {
                    if (fxr.RowState != System.Data.DataRowState.Deleted)
                    {
                        //find node if it exists
                        List<TreeNode> oldNodes = new List<TreeNode>();

                        FindByXRefId(oldNodes, tvFiles.Nodes, fxr.Id);
                        foreach (TreeNode oldNode in oldNodes)
                        {
                            if (oldNode.Tag.GetType() == typeof(appDB.EFileSearchRow))
                            {
                                if (((appDB.EFileSearchRow)oldNode.Tag).xrefId == fxr.Id)
                                { oldNode.Remove(); }
                            }
                        }
                        //add, remove or update node as appropriate based on fxr.rowstate

                        //could be loaded in more than one place  ie toolkit with multiple roots
                        TreeNode[] tns = tvFiles.Nodes.Find(fxr.FileId.ToString(), true);
                        List<TreeNode> allParents = new List<TreeNode>();
                        allParents.AddRange(tns);
                        TreeNode[] scNd = tvFiles.Nodes.Find("nodeMyDocShortcuts", true);
                        if (scNd.Length == 1 && scNd[0].Tag.GetType() == typeof(appDB.EFileSearchRow))
                        {
                            if (((appDB.EFileSearchRow)scNd[0].Tag).FileId == fxr.FileId)
                                allParents.Add(scNd[0]);
                        }
                        scNd = tvFiles.Nodes.Find("NodePersonalFile", true);
                        if (scNd.Length == 1 && scNd[0].Tag.GetType() == typeof(appDB.EFileSearchRow))
                        {
                            if (((appDB.EFileSearchRow)scNd[0].Tag).FileId == fxr.FileId)
                                allParents.Add(scNd[0]);
                        }
                        scNd = tvFiles.Nodes.Find("NodeMyOffice", true);
                        if (scNd.Length == 1 && scNd[0].Tag.GetType() == typeof(appDB.EFileSearchRow))
                        {
                            if (((appDB.EFileSearchRow)scNd[0].Tag).FileId == fxr.FileId)
                                allParents.Add(scNd[0]);
                        }

                        foreach (TreeNode parentFileNode in allParents)
                        {
                            bool isLoaded = false;
                            if (parentFileNode.Nodes.Count == 0)
                            {
                                //just load the nodes or don't do anything?
                            }
                            else
                            {

                                appDB.EFileSearchDataTable edt = myAtmng.FileSearchByParentFileId(fxr.FileId);
                                foreach (appDB.EFileSearchRow efr in edt)
                                {
                                    //if (efr.xrefId == fxr.Id)
                                    if (efr.FileId == fxr.OtherFileId)
                                    {
                                        if (parentFileNode.Nodes.Find(efr.FileId.ToString(), false).Length == 0)
                                        {
                                            AddSingleNode(parentFileNode, efr);
                                        }
                                    }
                                }
                            }
                        }

                    }
                    else
                    {

                        List<TreeNode> oldNodes = new List<TreeNode>();

                        //remove delete nodes
                        int id =(int) fxr["Id", System.Data.DataRowVersion.Original];
                        FindByXRefId(oldNodes, tvFiles.Nodes, id);
                        foreach (TreeNode oldNode in oldNodes)
                        {
                            if (oldNode.Tag.GetType() == typeof(appDB.EFileSearchRow))
                            {
                                if (((appDB.EFileSearchRow)oldNode.Tag).xrefId == id)
                                { oldNode.Remove(); }
                            }
                        }
                    }
                }
            }
            catch (Exception x)
            {
                //ignore any error that happens here
                //this event fires so many times it would overwhelm the user with error messages
                System.Diagnostics.Trace.WriteLine(x.Message);
            }
        }

        void tvFiles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node.Tag == null || e.Node.Name.StartsWith("nodeDocXRef"))
                    return;

                else if (e.Node.Tag.GetType() == typeof(appDB.EFileSearchRow))
                    SelectedFile = (appDB.EFileSearchRow)e.Node.Tag;
                else
                {
                    appDB.EFileSearchDataTable edt = myAtmng.FileSearchByFileId((int)e.Node.Tag);
                    if (edt.Rows.Count == 0)
                    {
                        MessageBox.Show(Properties.Resources.YouDoNotHaveAccessToThisFile);
                        return;
                    }
                    else
                    {
                        SelectedFile = edt[0];
                        e.Node.Tag = SelectedFile;
                    }
                }

                if (e.Node.Nodes.Count == 0 & SelectedFile.LinkType == (int)FXLinkType.ParentChild)
                {
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        LoadLevel(e.Node, SelectedFile);
                        if (e.Action == TreeViewAction.ByMouse)
                            e.Node.Expand();
                        Cursor.Current = Cursors.Default;
                    }
                    catch (Exception x)
                    {
                        Cursor.Current = Cursors.Default;
                    }
                }

                myFCM.uiCommandManager1.Tag = SelectedFile;
                if (FileSelected != null)
                {
                    
                    FileContextEventArgs fce = new FileContextEventArgs();
                    fce.MenuItem = FileContextMenuItem.None;
                    fce.SelectedFile = SelectedFile;
                    fce.Node = e.Node;
                    FileSelected(this, fce);
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        void tvFiles_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
          
            if (e.Label == null || e.Label == "")
            {
                e.CancelEdit = true;
                e.Node.TreeView.LabelEdit = false;
                return;
            }
            try
            {
                TreeNode pnd = e.Node.Parent;

                if (pnd.Tag != null && (e.Node.Tag.GetType() == typeof(appDB.EFileSearchRow) || e.Node.Name.StartsWith("nodeFileShortcut")))
                {
                    appDB.EFileSearchRow parentEfileSearchRow;
                    appDB.EFileSearchRow shortcutEfileSearchRow;

                    if (pnd.Tag.GetType() == typeof(appDB.EFileSearchRow))
                        parentEfileSearchRow = (appDB.EFileSearchRow)pnd.Tag;
                    else
                    {
                        appDB.EFileSearchDataTable efdt = myAtmng.FileSearchByFileId((int)pnd.Tag);
                        parentEfileSearchRow = (appDB.EFileSearchRow)efdt[0];
                    }
                    if (e.Node.Tag.GetType() == typeof(appDB.EFileSearchRow))
                        shortcutEfileSearchRow = (appDB.EFileSearchRow)e.Node.Tag;
                    else
                    {
                        appDB.EFileSearchDataTable efdt2 = myAtmng.FileSearchByFileId((int)e.Node.Tag);
                        shortcutEfileSearchRow = (appDB.EFileSearchRow)efdt2[0];
                    }

                    atriumBE.FileManager parentFM = myAtmng.GetFile(parentEfileSearchRow.FileId);
                    atriumBE.FileManager fileFM = myAtmng.GetFile(shortcutEfileSearchRow.FileId);
                    atriumDB.FileXRefRow fxr = parentFM.GetFileXRef().Load(shortcutEfileSearchRow.xrefId);

                    bool saveEfile = false;
                    if (fxr.LinkType == (int)FXLinkType.ParentChild) // rename file
                    {
                        fileFM = myAtmng.GetFile(shortcutEfileSearchRow.FileId);
                        fileFM.CurrentFile.NameE = e.Label;
                        shortcutEfileSearchRow.NameE = e.Label;
                        saveEfile = true;
                    }
                    else //rename file-shortcut or file-xref
                        fxr.Name = e.Label;

                    e.CancelEdit = true;
                    e.Node.TreeView.LabelEdit = false;
                    //re-insert file number in front if applicable
                    atriumDB.FileMetaTypeRow drMetaType = myAtmng.GetFile(0).DB.FileMetaType.FindByMetaTypeCode(fileFM.CurrentFile.MetaType);
                    if (saveEfile)
                    {

                        if (ShowFileNumber & Convert.ToBoolean(drMetaType["HasFileNumber"]))
                            e.Node.Text = fileFM.CurrentFile.FileNumber + " - " + fileFM.CurrentFile.Name;
                        else
                            e.Node.Text = fileFM.CurrentFile.Name;
                    }
                    else // shortcut
                    {
                        e.Node.Text = e.Label;
                    }


                    //save
                    try
                    {
                        atLogic.BusinessProcess bp = parentFM.GetBP();
                        if (saveEfile)
                            bp.AddForUpdate(fileFM.EFile);
                        else
                            bp.AddForUpdate(parentFM.GetFileXRef());

                        bp.Update();

                    }
                    catch (Exception x)
                    {
                        parentFM.DB.RejectChanges();
                        UIHelper.HandleUIException(x);
                    }
                }
                else if (e.Node.Name.StartsWith("nodeDocXRef"))
                {
                    docDB.DocXRefRow docXrefRow = (docDB.DocXRefRow)e.Node.Tag;
                    docXrefRow.Name = e.Label;

                    FileManager fmDoc = myAtmng.GetFile(docXrefRow.FileId);
                    DocManager dmDoc = fmDoc.GetDocMng();
                    docDB.DocXRefRow dxr = dmDoc.GetDocXRef().Load(docXrefRow.Id);

                    dxr.Name = e.Label;
                    e.Node.TreeView.LabelEdit = false;
                    //save
                    try
                    {
                        atLogic.BusinessProcess bp = fmDoc.GetBP();

                        bp.AddForUpdate(dmDoc.GetDocXRef());
                        bp.Update();

                    }
                    catch (Exception x)
                    {
                        dmDoc.DB.RejectChanges();
                        UIHelper.HandleUIException(x);
                    }
                }
                else
                {
                    MessageBox.Show(Properties.Resources.NoParentNodeOrEFileRowParentNode);
                    e.CancelEdit = true;
                    e.Node.TreeView.LabelEdit = false;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
                e.CancelEdit = true;
            }
        }

        private void RemoveLeadingFileNumberForEdit(TreeNode nd, appDB.EFileSearchRow efsr)
        {
            //nd.Text = efsr.Name;
        }

        void tvFiles_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            try
            {
                if (e.Node.Name.StartsWith("nodeDocXRef") || e.Node.Name.StartsWith("nodeFileShortcut") || e.Node.Name.StartsWith("nodeContainerDocXref"))
                {
                    //do nothing, allow edit
                }
                else
                {
                    if (e.Node.Tag != null && e.Node.Tag.GetType() == typeof(appDB.EFileSearchRow))
                    {
                        appDB.EFileSearchRow efsr = (appDB.EFileSearchRow)e.Node.Tag;
                        if (efsr.LinkType == (int)FXLinkType.ParentChild && efsr.MetaType.ToUpper() == "SC" && myAtmng.WorkingAsOfficer.ShortcutsId != efsr.FileId)
                        {
                            //do nothing, allow edit
                        }
                        else if (efsr.LinkType == (int)FXLinkType.Shortcut)
                        {
                            //do nothing, allow edit
                        }
                        else
                            e.CancelEdit = true;
                    }
                    else
                        e.CancelEdit = true;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }
        public void LoadRoot(int rootFileId, TreeNode nd)
        {
            isExplorer = (rootFileId == 0);
            LoadRoot(rootFileId, true);
            nd.Tag = SelectedFile;
            LoadLevel(nd, SelectedFile);
        }
        public void LoadRoot(int rootFileId, bool isNode)
        {

            try
            {
                isExplorer = (rootFileId == 0);

                //load root
                //atriumDB.EFileRow[] roots = myFM.EFile.LoadFileRoots();
                //foreach (atriumDB.EFileRow efr in roots)
                //{
                //    selectedFile = efr;
                if (!isNode)
                {
                    SelectedFile = myAtmng.FileSearchByFileId(rootFileId)[0];
                    TreeNode nd = new TreeNode();
                    if (ShowFileNumber & myAtmng.GetFile(0).DB.FileMetaType.FindByMetaTypeCode(SelectedFile.MetaType).HasFileNumber)
                        nd.Text = SelectedFile.FileNumber + " - " + SelectedFile.Name;
                    else
                        nd.Text = SelectedFile.Name;

                    nd.Name = SelectedFile.FileId.ToString();
                    nd.Tag = SelectedFile;
                    if (rootFileId == 0)
                    {
                        nd.ImageIndex = 30;
                        nd.SelectedImageIndex = 30;
                    }
                    tvFiles.Nodes.Add(nd);

                    LoadLevel(nd, selectedFile);
                    // }
                    tvFiles.ExpandAll();
                    if (tvFiles.Nodes.Count > 0)
                        tvFiles.SelectedNode = tvFiles.Nodes[0];
                }

            }
            catch (Exception x)
            {
                MessageBox.Show(Properties.Resources.CantLoadFileExplorer);
            }


        }

        public void LoadLevelPublic(TreeNode pnd, appDB.EFileSearchRow parent)
        {
            LoadLevel(pnd, parent);
        }

        private void LoadLevel(TreeNode pnd, appDB.EFileSearchRow parent)
        {
            if (parent == null)
                return;

            //Load Files
            appDB.EFileSearchDataTable dtEfile = myAtmng.FileSearchByParentFileId(parent.FileId);
            //Load Doc Shortcuts
            docDB.DocXRefDataTable dtDocShortcuts = myAtmng.DocShortcuts(parent.FileId);

            AddNodes(pnd, dtEfile, dtDocShortcuts);
        }

        public TreeNode FindNode(appDB.EFileSearchRow efr)
        {
            TreeNode tn = FindNodeH(efr);
            if (tn != null)
            {
                tvFiles.SelectedNode = tn;
                tn.Expand();
                tn.EnsureVisible();
            }
            return tn;
        }
        private TreeNode FindNodeH(appDB.EFileSearchRow efr)
        {
            TreeNode tn = FindNodex(efr);
            if (tn != null)
            {
                tn.EnsureVisible();
                //tvFiles.SelectedNode = tn;

                SelectedFile = efr;
                if (FileSelected != null)
                {
                    FileContextEventArgs fce = new FileContextEventArgs();
                    fce.MenuItem = FileContextMenuItem.None;
                    fce.SelectedFile = SelectedFile;
                    FileSelected(this, fce);
                }

            }
            return tn;
        }
        private TreeNode FindNodex(appDB.EFileSearchRow efr)
        {
            TreeNode[] tns = tvFiles.Nodes.Find(efr.FileId.ToString(), true);
            foreach (TreeNode tn in tns)
            {
                if (((appDB.EFileSearchRow)tn.Tag).LinkType == (int)FXLinkType.ParentChild)
                    return tn;
            }
            //not found so load node
            appDB.EFileSearchDataTable esdt = myAtmng.FileSearchFindParent(efr.FileId);
            if (esdt.Rows.Count > 0)
            {
                appDB.EFileSearchRow pr = esdt[0];
                TreeNode tn1 = FindNodeH(pr);
                if (tn1 != null)
                {
                    LoadLevel(tn1, pr);
                    if (tn1.Nodes.Find(efr.FileId.ToString(), false).Length > 0)
                        return tn1.Nodes[efr.FileId.ToString()];
                    else
                    {
                        TreeNode tn2 = AddSingleNode(tn1, efr);
                        return tn2;
                    }
                }
                else
                    return null;

            }
            else
                return null;
        }
        public TreeNode FindLoadedNode(int fileId)
        {
            //this only searches loaded nodes

            TreeNode[] tns = tvFiles.Nodes.Find(fileId.ToString(), true);
            foreach (TreeNode tn in tns)
            {
                if (((appDB.EFileSearchRow)tn.Tag).LinkType == (int)FXLinkType.ParentChild)
                    return tn;
            }

            return null;
        }

        private void AddNodes(TreeNode pnd, appDB.EFileSearchDataTable dtEfile, docDB.DocXRefDataTable dtDocShortcuts)
        {
            appDB.EFileSearchRow[] efrSorted;

            string sSort;
            if (ShowFileNumber)
                sSort = "LinkType,SortKey";
            else
                sSort = "LinkType,Name" + myAtmng.AppMan.Language.Substring(0, 1);

            if (ShowOnlyOpenFiles)
                efrSorted = (appDB.EFileSearchRow[])dtEfile.Select("StatusCode='O'", sSort);
            else
                efrSorted = (appDB.EFileSearchRow[])dtEfile.Select("", sSort);

            foreach (appDB.EFileSearchRow efr in efrSorted)
            {
                //System.Diagnostics.Trace.WriteLine(efr.SortKey);
                if (efr.LinkType == (int)FXLinkType.ParentChild)
                    AddSingleNode(pnd, efr);
                if (efr.LinkType == (int)FXLinkType.Shortcut && !hideShortcuts)
                    AddSingleNode(pnd, efr);
                if (efr.LinkType == (int)FXLinkType.XRef && !hideXrefs)
                    AddSingleNode(pnd, efr);
            }

            if (!hideDocShorcuts)
            {
                //now they are sorted CJW 2015-3-11
                docDB.DocXRefRow[] dxrs =(docDB.DocXRefRow[]) dtDocShortcuts.Select("", "Name");
                foreach (docDB.DocXRefRow docXrefRow in dxrs)
                {
                    System.Windows.Forms.TreeNode nd = new System.Windows.Forms.TreeNode();
                    nd.Name = "nodeDocXRef" + docXrefRow.DocId.ToString();
                    nd.Tag = docXrefRow;
                    nd.Text = docXrefRow.Name;
                    nd.ImageIndex = 5;
                    nd.SelectedImageIndex = 5;
                    pnd.Nodes.Add(nd);
                }
            }
        }

        private TreeNode AddSingleNode(TreeNode pnd, appDB.EFileSearchRow efr)
        {
            TreeNode nd = new TreeNode();
            nd.Tag = efr;
            nd.Name = efr.FileId.ToString();

            atriumDB.FileMetaTypeRow drMetaType = myAtmng.GetFile(0).DB.FileMetaType.FindByMetaTypeCode(efr.MetaType);
            
            //direct hook to OF type - there is no other way of identifying an office typed file ... for now
            if (drMetaType.MetaTypeCode.ToUpper() == "OF")
            {
                nd.ImageIndex = 28;
                nd.SelectedImageIndex = 28;
            }
            else if (drMetaType.IsContainer)
            {
                if (!drMetaType.IsFile)
                {
                    if (!drMetaType.HasFileNumber)
                    {
                        //structural container
                        nd.ImageIndex = 29;
                        nd.SelectedImageIndex = 29;
                    }
                    else
                    {
                        //file container
                        nd.ImageIndex = 2;
                        nd.SelectedImageIndex = 2;
                    }
                }
                else
                {
                    if (drMetaType.HasFileNumber && drMetaType.AllowSubFiles)
                    {
                        //File Node auto & not auto
                        if(drMetaType.SubFileAutoNumber)
                        {
                            nd.ImageIndex = 32;
                            nd.SelectedImageIndex = 32;
                        }
                        else
                        {
                            nd.ImageIndex = 33;
                            nd.SelectedImageIndex = 33;
                        }
                    }
                }
            }
            else
            {
                if (!drMetaType.HasFileNumber)
                {
                    //folder
                    nd.ImageIndex = 4;
                    nd.SelectedImageIndex = 4;
                }
                else
                {
                    int img = 10;
                    switch (efr.StatusCode.ToUpper())
                    {
                        case "A":
                            img = 7;
                            break;
                        case "M":
                            img = 9;
                            break;
                        case "C":
                            img = 8;
                            break;
                        case "P":
                            img = 11;
                            break;
                    }
                    nd.ImageIndex = img;
                    nd.SelectedImageIndex = img;
                }
            }


            WriteNodeText(efr, nd, drMetaType);

            //check file status to determine whether to show node or place in non-open collection
            if (efr.StatusCode != "O" && ShowOnlyOpenFiles)
            {
                //nonOpenNodes.Add(nd.Parent.Name + " - " + i.ToString(), nd);
                //nonOpenNodes.Add(efr.FullFileNumber, nd);
                //i++;
            }
            else
            {

                pnd.Nodes.Add(nd);
            }

            return nd;
        }

        private void WriteNodeText(appDB.EFileSearchRow efr, TreeNode nd, atriumDB.FileMetaTypeRow drMetaType)
        {
            if (efr.LinkType == (int)FXLinkType.XRef)
            {
                nd.ImageIndex = 12;
                nd.SelectedImageIndex = 12;
                if (ShowFileNumber)
                    nd.Text = efr.FullFileNumber + " - " + efr.Name;
                else
                    nd.Text = efr.Name + " (" + efr.FullFileNumber + ")";

                nd.ToolTipText = String.Format(Properties.Resources.XrefShortcutToFileNameFileNumber, XRefTo, efr.Name, efr.FullFileNumber);
            }
            else if (efr.LinkType == (int)FXLinkType.Shortcut)
            {
                nd.ImageIndex = 6;
                nd.SelectedImageIndex = 6;
                nd.Text = efr.XRefName;
                nd.ToolTipText = String.Format(Properties.Resources.XrefShortcutToFileNameFileNumber, ShortcutTo, efr.Name, efr.FullFileNumber);
            }
            else if (efr.LinkType == (int)FXLinkType.ParentChild)
            {
                if (ShowFileNumber & Convert.ToBoolean(drMetaType["HasFileNumber"]))
                    nd.Text = efr.FileNumber + " - " + efr.Name;
                else
                    nd.Text = efr.Name;

            }
        }



        public void Resort(TreeNodeCollection nodes)
        {
            appDB.EFileSearchRow er;
            foreach (TreeNode nd in nodes)
            {
                if (nd.Tag.GetType() == typeof(appDB.EFileSearchRow))
                {
                    er = (appDB.EFileSearchRow)nd.Tag;
                    //if (ShowFileNumber & myAtmng.GetFile(0,false).DB.FileMetaType.FindByMetaTypeCode(er.MetaType).HasFileNumber)
                    //    nd.Text = er.FileNumber + " - " + er.Name;
                    //else
                    //    nd.Text = er.Name;
                    WriteNodeText(er, nd, myAtmng.GetFile(0).DB.FileMetaType.FindByMetaTypeCode(er.MetaType));
                    Resort(nd.Nodes);
                }
            }


        }

        private void tvFiles_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //System.Diagnostics.Trace.WriteLine("tvFiles_NodeMouseClick");
            if (e.Clicks > 1)
                return;
            if (e.Node.Tag == null) // || e.Node.Name.StartsWith("nodeFileShortcut") || e.Node.Name == "nodeMyDocShortcuts" || e.Node.Name.StartsWith("nodeContainerDocXref"))
                return;
            //else if (e.Node.Tag.GetType() == typeof(appDB.EFileSearchRow))
            //    SelectedFile = (appDB.EFileSearchRow)e.Node.Tag;
            //else
            //{
            //    SelectedFile = myAtmng.FileSearchByFileId((int)e.Node.Tag)[0];
            //    e.Node.Tag = SelectedFile;
            //}
                        TreeNode nd = ((TreeView)sender).GetNodeAt(e.X, e.Y);
                    if (nd == null)
                        return;
        myFCM.uiCommandManager1.Tag = nd;

            if (e.Button == MouseButtons.Right && ShowContextMenu) //display context menu
            {
                try
                {

                    tvFiles.SelectedNode = nd;
                    if (nd.Tag != null)
                    {
                        if (nd.Name == "nodeMyDocShortcuts")
                        {
                            myFCM.EnableMenuItem(false, FileContextMenuItem.MoveShortcutContainer);
                            myFCM.EnableMenuItem(false, FileContextMenuItem.DeleteShortcutContainer);
                            myFCM.EnableMenuItem(false, FileContextMenuItem.RenameShortcutContainer);
                            //myFCM.uiCommandManager1.Tag = nd;
                        }
                        //Node is Efile Row
                        else if (nd.Tag.GetType() == typeof(appDB.EFileSearchRow))
                        {
                            appDB.EFileSearchRow er = (appDB.EFileSearchRow)nd.Tag;
                            
                            if (er.LinkType == (int)FXLinkType.ParentChild)
                            {
                                FileManager fm = myAtmng.GetFile(er.FileId);
                                BuildMenu(fm, myFCM.uiCommandManager1.Commands["cmdFNew"], dmFILENEW);

                                if (er.MetaType.ToUpper() != "SC")//Not a Shortcut Container File
                                {
                                    //get permissions

                                    bool efileAdd = fm.EFile.CanAdd(fm.CurrentFile);
                                    bool acAdd = fm.GetActivity().CanAdd(fm.CurrentFile);
                                    bool docAdd = fm.GetDocMng().GetDocument().CanAdd(fm.CurrentFile);

                                    //Rename shortcut
                                    myFCM.EnableMenuItem((er.LinkType == (int)FXLinkType.Shortcut), FileContextMenuItem.RenameFile);

                                    //Add to Shortcuts
                                    myFCM.EnableMenuItem((er.LinkType == (int)FXLinkType.ParentChild), FileContextMenuItem.AddToShortcuts);

                                    //Delete non file
                                    myFCM.EnableMenuItem((er.LinkType != (int)FXLinkType.ParentChild), FileContextMenuItem.Delete);

                                    //Create XRef
                                    myFCM.EnableMenuItem((er.LinkType == (int)FXLinkType.ParentChild), FileContextMenuItem.CreateXRef);

                                    //New Office
                                    myFCM.EnableMenuItem(er.MetaType.ToUpper() == "OF", FileContextMenuItem.NewOffice);

                                    //New File
                                    myFCM.EnableMenuItem(efileAdd, FileContextMenuItem.NewFile);

                                    //New Activity,mail,doc
                                    myFCM.EnableMenuItem(acAdd, FileContextMenuItem.NewActivity);
                                    myFCM.EnableMenuItem(acAdd, FileContextMenuItem.NewMail);

                                    myFCM.EnableMenuItem(docAdd, FileContextMenuItem.NewDocument);
                                    myFCM.EnableMenuItem(docAdd, FileContextMenuItem.NewMemo);
                                    myFCM.EnableMenuItem(docAdd, FileContextMenuItem.NewFaxCoverSheet);

                                    //Check for AKAs
                                    BuidAKA(fm, myFCM.uiCommandManager1.Commands["cmdFileAKA"]);

                                }
                                else
                                {
                                    atriumDB.FileXRefRow parentfile = fm.EFile.GetParentFileXref(fm.CurrentFile);
                                    string ParentMetaType = fm.AtMng.GetFile(parentfile.FileId).CurrentFile.MetaType;
                                    bool isAShortcutRoot = (ParentMetaType != "SC");

                                    myFCM.EnableMenuItem(!isAShortcutRoot, FileContextMenuItem.MoveShortcutContainer);
                                    myFCM.EnableMenuItem(!isAShortcutRoot, FileContextMenuItem.DeleteShortcutContainer);
                                    myFCM.EnableMenuItem(!isAShortcutRoot, FileContextMenuItem.RenameShortcutContainer);
                                }
                            }
                            //else if (er.LinkType == (int)FXLinkType.Shortcut)
                            //{
                            //    myFCM.uiContextMenu3.CommandManager.Tag = nd;
                            //    myFCM.uiContextMenu3.Show(tvFiles);
                            //}
                            //else if (er.LinkType == (int)FXLinkType.XRef)
                            //{
                            //    myFCM.uiContextMenu5.CommandManager.Tag = nd;
                            //    myFCM.uiContextMenu5.Show(tvFiles);
                            //}


                            //if (er.LinkType != (int)FXLinkType.Shortcut && er.MetaType.ToUpper()!="SC")
                            //{
                            //myFCM.contextMenuFileExplorer.Tag = nd;
                            //myFCM.contextMenuFileExplorer.Show(tvFiles, e.X, e.Y);
                            //    myFCM.uiContextMenu4.CommandManager.Tag = nd;
                            //    myFCM.uiContextMenu4.Show(tvFiles);
                            //}
                        }
                        //else if (nd.Tag.GetType() == typeof(docDB.DocXRefRow) && nd.Name.StartsWith("nodeDocXRef"))
                        //{
                        //    myFCM.uiContextMenu2.CommandManager.Tag = nd;
                        //    myFCM.uiContextMenu2.Show(tvFiles);
                        //}
                        myFCM.uiCommandManager1.Tag = nd;
                    }
                }
                catch (Exception x)
                {
                    UIHelper.HandleUIException(x);
                }

            }
            if (e.Button == MouseButtons.Left)
            {

                if (e.Node.GetNodeCount(true) > 0)
                {
                    //TreeNode nd = ((TreeView)sender).GetNodeAt(e.X, e.Y);
                    tvFiles.SelectedNode = nd;

                    if (tvFiles.HitTest(e.Location).Location == TreeViewHitTestLocations.Label)
                    {
                        if (e.Node.IsExpanded)
                            e.Node.Collapse(true);
                        else
                            e.Node.Expand();
                    }
                }
            }
        }

        private void tvFiles_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (((TreeNode)e.Item).Tag == null)
                return;

            //src = (TreeNode)e.Item;
            if ((((TreeNode)e.Item).Tag).GetType() == typeof(appDB.EFileSearchRow))
            {
                appDB.EFileSearchRow file = (appDB.EFileSearchRow)((TreeNode)e.Item).Tag;
                if (file == null)
                    return;
                if (file.LinkType != (int)FXLinkType.XRef)
                {
                    DragDropEffects d = tvFiles.DoDragDrop(e.Item, DragDropEffects.Move);
                    if (d == DragDropEffects.Move)
                    {
                        // src.Remove();
                    }
                }
            }
            else if ((((TreeNode)e.Item).Tag).GetType() == typeof(docDB.DocXRefRow))
            {
                docDB.DocXRefRow doc = (docDB.DocXRefRow)((TreeNode)e.Item).Tag;

                if (doc == null)
                    return;

                DragDropEffects d = tvFiles.DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }


        TreeNode OldNode = null;
        private void tvFiles_DragOver(object sender, DragEventArgs e)
        {
            Point p = tvFiles.PointToClient(new Point(e.X, e.Y));
            // System.Diagnostics.Trace.WriteLine(p.ToString());
            TreeNode nd = tvFiles.HitTest(p).Node;
            if (nd == null)
            {
                e.Effect = DragDropEffects.None;
                if (OldNode != null)
                {
                    OldNode.ForeColor = Color.Black;
                    OldNode.NodeFont = new Font(tvFiles.Font, FontStyle.Regular);
                }
                return;
            }
            nd.ForeColor = Color.Gray;
            nd.NodeFont = new Font(tvFiles.Font, FontStyle.Underline);

            if ((OldNode != null) && (OldNode != nd))
            {
                OldNode.ForeColor = Color.Black;
                OldNode.NodeFont = new Font(tvFiles.Font, FontStyle.Regular);
            }
            OldNode = nd;



            if (e.Data.GetDataPresent(typeof(List<System.Data.DataRow>)))
            {
                if (nd.Tag != null)
                {
                    if (nd.Name.StartsWith("nodeDocXRef"))
                        e.Effect = DragDropEffects.None;
                    else if (nd.Tag.GetType() == typeof(appDB.EFileSearchRow))
                    {
                        appDB.EFileSearchRow efsr = (appDB.EFileSearchRow)nd.Tag;
                        if (efsr.LinkType != (int)FXLinkType.XRef)
                            e.Effect = DragDropEffects.Move;
                        else
                            e.Effect = DragDropEffects.None;
                    }
                }
            }
            else
            {
                TreeNode src = (TreeNode)e.Data.GetData(typeof(TreeNode));

                //dragging a shortcut - allow move effect on parentfile efilesearchrow
                if (src.Name.StartsWith("nodeDocXRef")) //|| src.Name.StartsWith("nodeFileShortcut") || src.Name.StartsWith("nodeContainerDocXref"))
                {
                    appDB.EFileSearchRow efsr = null;
                    if (nd.Tag.GetType() == typeof(appDB.EFileSearchRow))
                        efsr = (appDB.EFileSearchRow)nd.Tag;

                    if (efsr != null && efsr.LinkType == (int)FXLinkType.ParentChild)
                        e.Effect = DragDropEffects.Move;
                    else
                        e.Effect = DragDropEffects.None;

                }

                //dragging file or shortcut
                else
                {
                    if (nd != null && nd.Tag != null && src.Parent != null)
                    {
                        if (nd.Tag.GetType() == typeof(appDB.EFileSearchRow) && ((appDB.EFileSearchRow)nd.Tag).LinkType == (int)FXLinkType.ParentChild)
                            e.Effect = DragDropEffects.Move;
                        else
                            e.Effect = DragDropEffects.None;
                    }
                    else
                        e.Effect = DragDropEffects.None;
                }
            }
        }

        private void tvFiles_DragEnter(object sender, DragEventArgs e)
        {
            Point p = tvFiles.PointToClient(new Point(e.X, e.Y));
            // System.Diagnostics.Trace.WriteLine(p.ToString());
            TreeNode nd = tvFiles.HitTest(p).Node;
            if (nd == null)
            {
                e.Effect = DragDropEffects.None;
                return;
            }


            if (e.Data.GetDataPresent(typeof(List<System.Data.DataRow>)))
            {
                if (nd.Tag != null)
                {
                    if (nd.Name.StartsWith("nodeDocXRef"))
                        e.Effect = DragDropEffects.None;
                    else if (nd.Tag.GetType() == typeof(appDB.EFileSearchRow))
                    {
                        appDB.EFileSearchRow efsr = (appDB.EFileSearchRow)nd.Tag;
                        if (efsr.LinkType != (int)FXLinkType.XRef)
                            e.Effect = DragDropEffects.Move;
                        else
                            e.Effect = DragDropEffects.None;
                    }
                }
            }
            else if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                TreeNode src = (TreeNode)e.Data.GetData(typeof(TreeNode));
                //dragging a shortcut - allow move effect on parentfile efilesearchrow
                if (src.Name.StartsWith("nodeDocXRef")) //|| src.Name.StartsWith("nodeFileShortcut") || src.Name.StartsWith("nodeContainerDocXref"))
                {
                    appDB.EFileSearchRow efsr = null;
                    if (nd.Tag.GetType() == typeof(appDB.EFileSearchRow))
                        efsr = (appDB.EFileSearchRow)nd.Tag;

                    if (efsr != null && efsr.LinkType == (int)FXLinkType.ParentChild)
                        e.Effect = DragDropEffects.Move;
                    else
                        e.Effect = DragDropEffects.None;

                }

                //dragging file or shortcut
                else
                {
                    if (nd != null && nd.Tag != null && src.Parent != null)
                    {
                        if (nd.Tag.GetType() == typeof(appDB.EFileSearchRow) && ((appDB.EFileSearchRow)nd.Tag).LinkType == (int)FXLinkType.ParentChild)
                            e.Effect = DragDropEffects.Move;
                        else
                            e.Effect = DragDropEffects.None;
                    }
                    else
                        e.Effect = DragDropEffects.None;
                }
            }
        }

        private void DropBF(List<System.Data.DataRow> abrs, appDB.EFileSearchRow target)
        {
            ////bool splitThread = false;
            //if (abrs.Count == 1)
            //{
            //    //DialogResult answer = MessageBox.Show(Properties.Resources.DoYouWantToSplitTheThread, Properties.Resources.MoveBF, MessageBoxButtons.YesNoCancel);
            //    //if (answer == DialogResult.Cancel)
            //    //    return;

            //    //splitThread = (answer == DialogResult.Yes);
            //    atriumDB.ActivityBFRow  abrMove=(atriumDB.ActivityBFRow)abrs[0];
            //    FileManager FM = myAtmng.GetFile(abrMove.FileId, false);
            //    FM.InitActivityProcess();

            //    atriumDB.ActivityRow ar = FM.DB.Activity.FindByActivityId(abrMove.ActivityId);// abr.ActivityRow;
            //    FM.GetActivity().CheckMove(ar);
            //    atriumDB.ActivityRow[] ars = (atriumDB.ActivityRow[])FM.DB.Activity.Select("Processid=" + ar.ProcessId.ToString(), "ConvIndexBase,ConversationIndex");
            //    //if (ar.ProcessRow == null)
            //    //{
            //    //    //this means we are moving a acxref
            //    //    splitThread = true;
            //    //}
            //    //else if (ars.Length > 1 & ars[0].ActivityId != ar.ActivityId)
            //    //{
            //    //    DialogResult result = MessageBox.Show(Properties.Resources.DoYouWantToSplitTheThread, Properties.Resources.MoveBF, MessageBoxButtons.YesNoCancel);

            //    //    if (result == DialogResult.Cancel)
            //    //        return;
            //    //    splitThread = result == DialogResult.Yes;
            //    //}

            //}
            foreach (atriumDB.ActivityBFRow abr in abrs)
            {
                FileManager fm = myAtmng.GetFile(abr.FileId);
                fm.InitActivityProcess();
            }
            UIHelper.MoveAcBF(target.FileId, abrs);
        }
        private void tvFiles_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                Point p = tvFiles.PointToClient(new Point(e.X, e.Y));
                TreeNode nd = tvFiles.HitTest(p).Node;
                if (nd != null)
                {
                    nd.ForeColor = Color.Black;
                    nd.NodeFont = new Font(tvFiles.Font, FontStyle.Regular);

                    int targetFileId;
                    if (nd.Tag.GetType() == typeof(appDB.EFileSearchRow))
                        targetFileId = ((appDB.EFileSearchRow)nd.Tag).FileId;
                    else
                        targetFileId = (int)nd.Tag;

                    //MessageBox.Show("move to "+target.NameE);
                    if (e.Data.GetDataPresent(typeof(List<System.Data.DataRow>)))
                    {
                        appDB.EFileSearchRow target = myAtmng.FileSearchByFileId(targetFileId)[0];//.FindByFileId(targetFileId);
                        DropBF((List<System.Data.DataRow>)e.Data.GetData(typeof(List<System.Data.DataRow>)), target);
                        return;
                    }


                    TreeNode src = (TreeNode)e.Data.GetData(typeof(TreeNode));
                    appDB.EFileSearchRow file = null;
                    docDB.DocXRefRow doc = null;

                    if (src.Tag.GetType() == typeof(appDB.EFileSearchRow))
                        file = (appDB.EFileSearchRow)src.Tag;
                    else if (src.Tag.GetType() == typeof(docDB.DocXRefRow))
                        doc = (docDB.DocXRefRow)src.Tag;


                    if (doc != null) //doc shortcut was dropped
                    {
                        //don't move docs if same file
                        if (doc.FileId == targetFileId)
                            return;

                        FileManager thisfm = myAtmng.GetFile(doc.FileId);
                        docDB.DocXRefRow docX = thisfm.GetDocMng().GetDocXRef().Load(doc.Id);

                        doc.FileId = targetFileId;
                        docX.FileId = targetFileId;

                        atLogic.BusinessProcess bp = myAtmng.GetBP();
                        bp.AddForUpdate(thisfm.GetDocMng().GetDocXRef());
                        bp.AddForUpdate(thisfm.EFile);
                        bp.Update();
                     

                        src.Remove();
                        nd.Nodes.Add(src);

                        tvFiles.SelectedNode = src;


                    }

                    else if (file != null) //file or file shortcut was dropped
                    {
                        //don't move files on to themselves
                        if (file.FileId == targetFileId)
                            return;

                        FileManager thisfm;
                        FXLinkType moveOp;
                        if (file.LinkType == (int)FXLinkType.ParentChild)
                        {
                            bool addToSc = (nd.Name.StartsWith("nodeContainerDocXref") | nd.Name.StartsWith("nodeMyDocShortcuts")) & !src.Name.StartsWith("nodeContainerDocXref");
                            fMove fMove1 = new fMove(myAtmng.GetFile(targetFileId).CurrentFile.FileMetaTypeRow, addToSc);
                            fMove1.tbName.Text = file.Name;
                            fMove1.ShowDialog();
                            if (fMove1.Cancel)
                            {
                                fMove1.Close();
                                return;
                            }
                            moveOp = fMove1.moveOp;
                            fMove1.Close();

                            //do Update with file manager for file
                            if (fMove1.moveOp == FXLinkType.ParentChild)
                            {
                                thisfm = myAtmng.GetFile(file.FileId);
                                //thisfm.EFile.Move(thisfm.CurrentFile, targetFileId, true);
                                UIHelper.MoveFile(thisfm, targetFileId);
                            }
                            else
                            {
                                thisfm = myAtmng.GetFile(targetFileId);
                                //thisfm.GetFileXRef().LoadByFileId(targetFileId);
                                atriumDB.FileXRefRow fxrNew = (atriumDB.FileXRefRow)thisfm.GetFileXRef().Add(thisfm.CurrentFile);
                                fxrNew.LinkType = (int)fMove1.moveOp;
                                fxrNew.OtherFileId = file.FileId;
                                fxrNew.Name = fMove1.tbName.Text;
                                if (fxrNew.HasErrors)
                                {
                                    string msg = fxrNew.GetColumnError("OtherFileId");
                                    fxrNew.RejectChanges();
                                    throw new LMException(msg);
                                }
                            }
                        }
                        else
                        {
                            moveOp = FXLinkType.Shortcut;//.ParentChild;
                            thisfm = myAtmng.GetFile(file.FileId);
                            //thisfm.GetFileXRef().LoadByFileId(file.FileId);
                            //thisfm.GetFileXRef().LoadByOtherFileId(file.FileId);
                            UIHelper.MoveFileShortcut(thisfm, file.xrefId, targetFileId);
                        }

                        atLogic.BusinessProcess bp = myAtmng.GetBP();
                        bp.AddForUpdate(thisfm.EFile);
                        bp.AddForUpdate(thisfm.GetFileXRef());
                        bp.Update();

                       

                        if (moveOp == FXLinkType.ParentChild)
                        {
                            //reload update file record
                            file = myAtmng.FileSearchByFileId(file.FileId)[0];
                            src.Tag = file;
                            WriteNodeText(file, src, thisfm.CurrentFile.FileMetaTypeRow);
                            //if (ShowFileNumber & thisfm.CurrentFile.FileMetaTypeRow.HasFileNumber)
                            //    src.Text = file.FileNumber + " - " + file.Name;
                            //else
                            //    src.Text = file.Name;

                            src.Remove();
                            if (!nd.Nodes.ContainsKey(file.FileId.ToString()))
                            {
                                nd.Nodes.Add(src);
                                tvFiles.SelectedNode = src;
                            }
                        }
                        else if (moveOp == FXLinkType.Shortcut)
                        {
                            if (file.LinkType == (int)FXLinkType.Shortcut)
                                src.Remove();

                            appDB.EFileSearchDataTable edt = myAtmng.FileSearchByParentFileId(targetFileId);
                            foreach (appDB.EFileSearchRow esrC in edt.Rows)
                            {
                                if (esrC.FileId == file.FileId)
                                {
                                    file = esrC;
                                }
                            }
                            //TreeNode nsc=AddSingleNode(nd, file);
                            //nsc.Name = "nodeFileShortcut" + file.FileId.ToString();
                            //src.Tag = file;
                            //WriteNodeText(file, src, thisfm.CurrentFile.FileMetaTypeRow);
                            ////if (ShowFileNumber & thisfm.CurrentFile.FileMetaTypeRow.HasFileNumber)
                            ////    src.Text = file.FileNumber + " - " + file.Name;
                            ////else
                            ////    src.Text = file.Name;
                            //nd.Nodes.Add(src);
                            //tvFiles.SelectedNode = src;
                        }
                        else
                        {
                            appDB.EFileSearchDataTable edt = myAtmng.FileSearchByParentFileId(targetFileId);
                            foreach (appDB.EFileSearchRow esrC in edt.Rows)
                            {
                                if (esrC.FileId == file.FileId)
                                {
                                    file = esrC;
                                }
                            }
                            //the sync code should handle this now
                            //AddSingleNode(nd, file);
                        }
                    }
                }
            }
            catch (Exception x)
            {
               
                //myFM.AtMng.SecurityManager.Rollback();
                UIHelper.HandleUIException(x);
            }
        }

        private void tvFiles_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                //if ( e.Node.Name == "nodeMyDocShortcuts" || e.Node.Name.StartsWith("nodeContainerDocXref"))
                //    return;

                if (e.Node.Name.StartsWith("nodeDocXref")) //Document Shortcut
                {
                    if (NodeDoubleClicked != null)
                        NodeDoubleClicked(this, e);
                }

                if (e.Node.Tag != null && e.Node.Tag.GetType() == typeof(appDB.EFileSearchRow))
                {
                    appDB.EFileSearchRow esr = (appDB.EFileSearchRow)e.Node.Tag;
                    if (esr != null && esr.LinkType != (int)FXLinkType.ParentChild)
                    {
                        //jump to xref
                        //TreeNode tn = FindNodeH(esr);


                        if (esr.LinkType != (int)FXLinkType.ParentChild)
                        {
                            if (NodeDoubleClicked != null)
                                NodeDoubleClicked(this, e);
                        }
                    }
                    else
                    {
                        if (NodeDoubleClicked != null)
                            NodeDoubleClicked(this, e);
                    }
                }

                else
                {
                    if (NodeDoubleClicked != null)
                        NodeDoubleClicked(this, e);
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        public static void BuidAKA(atriumBE.FileManager fm, Janus.Windows.UI.CommandBars.UICommand cmd)
        {
            //clear current items
            for (int i = cmd.Commands.Count - 1; i >= 0; i--)
            {
                cmd.Commands.RemoveAt(i);
            }
            if (fm.DB.FileAKA.Count > 0)
            {
                cmd.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                foreach(atriumDB.FileAKARow faka in fm.DB.FileAKA.Select("","FullFileNumber"))
                {
                    Janus.Windows.UI.CommandBars.UICommand newCmd;
                    //add new items
                    string key = "lblFileAka" + faka.Id.ToString();
                    if (cmd.CommandManager.Commands.Contains(key))
                    {
                        newCmd = cmd.CommandManager.Commands[key];
                    }
                    else
                    {

                        newCmd = new Janus.Windows.UI.CommandBars.UICommand();
                        newCmd.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
                        newCmd.Key = key;
                        newCmd.Image = Properties.Resources.folder;
                    }
                    newCmd.Text = faka.FullFileNumber;
                    newCmd.ToolTipText = "Full Path: " + faka.FullPath;
                    cmd.Commands.Add(newCmd);
                }
            }
            else
                cmd.Enabled = Janus.Windows.UI.InheritableBoolean.False;
        }

        public static void BuildMenu(atriumBE.FileManager fm, Janus.Windows.UI.CommandBars.UICommand cmd, string menu)
        {
            //clear current items
//            cmd.Commands.Clear();
            for (int i = cmd.Commands.Count-1; i >=0 ; i--)
            {
                
                if (cmd.Commands[i].Key.StartsWith("tsACMenu"))
                    cmd.Commands.RemoveAt(i);
            }


            foreach (lmDatasets.ActivityConfig.ACMenuRow acm in fm.AtMng.acMng.DB.ACMenu.Select("Menu='" + menu + "'", "Sort"))
            {

                ActivityConfig.ACSeriesRow acsrC = fm.AtMng.acMng.DB.ACSeries.FindByACSeriesId(acm.AcSeriesId);
                if (atriumBE.Workflow.Allowed(acsrC, fm.AtMng, fm))
                {
                    Janus.Windows.UI.CommandBars.UICommand newCmd;
                    //add new items
                    string key = "tsACMenu" + acsrC.ACSeriesId.ToString();
                    if (cmd.CommandManager.Commands.Contains(key))
                    {
                        newCmd = cmd.CommandManager.Commands[key];
                    }
                    else
                    {

                        newCmd = new Janus.Windows.UI.CommandBars.UICommand();
                        newCmd.Key = key;
                        if (!acsrC.IsIconResourceNull())
                            newCmd.Image = (Image)Properties.Resources.ResourceManager.GetObject(acsrC.IconResource);
                    }

                    if (menu == FileTreeView.dmAppt || menu == FileTreeView.dmApptNew)
                    {
                        newCmd.Text = fm.AtMng.acMng.GetACSeries().GetSeriesText(acsrC);
                    }
                    else
                    {
                        newCmd.Text = fm.AtMng.acMng.GetACSeries().GetNodeText(acsrC, (atriumBE.StepType)acsrC.StepType, false);
                    }
                    
                    newCmd.Tag = acsrC;
                    cmd.Commands.Add(newCmd);
                    
                }
                if (acm.IsSeparator)
                {
                    Janus.Windows.UI.CommandBars.UICommand newCmd;
                    newCmd = new Janus.Windows.UI.CommandBars.UICommand();
                    newCmd.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
                    newCmd.Key = "tsACMenuSeparator";
                    cmd.Commands.Add(newCmd);
                }
            }
        }

        public bool IsExplorer
        {
            get
            {
                
                return isExplorer;
            }
        }

    }

    public class FileContextEventArgs : EventArgs
    {
        public TreeNode Node;
        public appDB.EFileSearchRow SelectedFile;
        public FileContextMenuItem MenuItem;
        public ActivityConfig.ACSeriesRow ACSeries;
    }

}
