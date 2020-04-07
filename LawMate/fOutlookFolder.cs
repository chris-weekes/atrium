using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using atriumBE;
using lmDatasets;
using Redemption;


 namespace LawMate
{
    public partial class fOutlookFolder : Form
    {

        RDOSession mySession;
        private global::System.Object missing = global::System.Type.Missing;

        public RDOFolder SelectedFolder = null;

        public fOutlookFolder()
        {
            InitializeComponent();
        }

        public fOutlookFolder(RDOSession session)
        {
            InitializeComponent();
            mySession = session;

            LoadStores();
            LoadFolders(treeView1.Nodes.Find(mySession.Stores.DefaultStore.EntryID, true)[0], mySession.Stores.DefaultStore.IPMRootFolder);  //
            treeView1.SelectedNode = treeView1.Nodes.Find(mySession.Stores.DefaultStore.GetDefaultFolder(rdoDefaultFolders.olFolderInbox).EntryID, true)[0];


        }

        public void LoadStores()
        {
            foreach (RDOStore store in mySession.Stores)
            {
                try
                {
                        TreeNode ndStore = treeView1.Nodes.Add(store.EntryID, store.Name);
                        ndStore.ImageIndex = 9;
                        ndStore.SelectedImageIndex = 9;
                        ndStore.Tag = "Store";
                }
                catch (Exception x)
                {
                    //ignore
                }
            }
        }

        public void LoadFolders(TreeNode ndParent, RDOFolder parent)
        {
            ndParent.Nodes.Clear();
            foreach (RDOFolder folder in parent.Folders)
            {
                if (folder.FolderKind == rdoFolderKind.fkGeneric && folder.DefaultItemType == (int)rdoItemType.olMailItem)
                {
                    TreeNode nd = ndParent.Nodes.Add(folder.EntryID, folder.Name);
                    nd.ImageIndex = 7;
                    nd.SelectedImageIndex = 5;
                    LoadFolders(nd, folder);
                }
            }
        }

        private void fOutlookFolder_Load(object sender, EventArgs e)
        {

        }
        private TreeNode GetTopNode(TreeNode nd)
        {
            if (nd.Parent == null)
                return nd;
            else
                return GetTopNode(nd.Parent);
        }
        private RDOFolder GetRDOFolder(TreeNode nd)
        {
            if (nd.Tag == "Store")
            {

                return mySession.Stores.GetStoreFromID(nd.Name, missing).IPMRootFolder;
            }
            else
            {

                TreeNode top = GetTopNode(nd);
                RDOFolder fld = mySession.Stores.GetStoreFromID(top.Name, missing).GetFolderFromID(nd.Name, missing);
                return fld;
            }
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectedFolder = GetRDOFolder(e.Node);
        }

    }
}