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
    public delegate void ToolkitEventHandler(object sender, TreeNodeMouseClickEventArgs e);

    public partial class ucOfficerToolkit : UserControl
    {
        //FileManager myFM;
        atriumManager Atmng;
        public event ToolkitEventHandler NodeSelected;


        private int toolkitOfficerId;
        private int tkOfficeId;
        public officeDB.OfficerRow ToolkitOfficer
        {
            get { return Atmng.GetOffice(tkOfficeId).DB.Officer.FindByOfficerId(toolkitOfficerId); }
        }

        private fMain mainForm;
        public fMain MainForm
        {
            set { mainForm = value; }
        }


        private TreeNode selectedNode;
        public TreeNode SelectedNode
        {
            get { return selectedNode; }
        }

        public ucOfficerToolkit(atriumManager atmng, fMain mainform)
        {
            InitializeComponent();
            SetAtmng(atmng, mainform);
            CreateNodes();
            if (UIHelper.getScalingFactor() > 1)
                tvOfficerToolkit.ItemHeight = tvOfficerToolkit.ItemHeight + 2;
        }

        public ucOfficerToolkit(officeDB.OfficerRow or, atriumManager atmng, fMain mainform)
        {
            InitializeComponent();
            SetAtmng(atmng, mainform);
            CreateNodes();
            setOfficer(or);
            ucFileContextMenu1.LoadLabels();
            LoadContextMenuLabels();
        }

        public void SetAtmng(atriumManager atmng, fMain mainform)
        {
            Atmng = atmng;
            mainForm = mainform;
        }
        public void LoadContextMenuLabels()
        {
            cmdBFList.Text = "BF List";
            cmdBFList.Image = Properties.Resources.BFListCalendar;
            cmdDocs.Text = "E-mails/Documents";
            cmdDocs.Image = Properties.Resources.doc2;
            cmdFiles.Text = "Files";
            cmdFiles.Image = Properties.Resources.folder16;
            cmdCalendar.Text = "Calendar";
            cmdCalendar.Image = Properties.Resources.otkCalendar1;
            cmdAddBook.Text = "Address Book";
            cmdAddBook.Image = Properties.Resources.address_book;
            cmdPersonalFile.Text = "Personal File";
            cmdPersonalFile.Image = Properties.Resources.folder16;
            cmdMyOffice.Text = "My Office";
            cmdMyOffice.Image = Properties.Resources.office_building;

        }
        private void AddNodeToDict(TreeNode node)
        {
            if (!removedNodesDic.ContainsKey(node.Name))
                removedNodesDic.Add(node.Name, node);
            tvOfficerToolkit.Nodes.Remove(tvOfficerToolkit.Nodes[node.Name]);
        }

        private TreeNode RemoveNodeFromDict(string NodeName)
        {
            if (!removedNodesDic.ContainsKey(NodeName))
                return null;

            TreeNode tn = removedNodesDic[NodeName];
            removedNodesDic.Remove(NodeName);
            return tn;
        }

        Dictionary<string, TreeNode> removedNodesDic = new Dictionary<string, TreeNode>();
        public void setOfficer(officeDB.OfficerRow or)
        {
            toolkitOfficerId = or.OfficerId;
            tkOfficeId = or.OfficeId;

            tvOfficerToolkit.ExpandAll();

            tvOfficerToolkit.Nodes["nodeMyDocs"].Collapse();

            if (Atmng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.OfficerTKHideBF, false))
                AddNodeToDict(tvOfficerToolkit.Nodes["NodeMyItems"]);

            tvOfficerToolkit.Nodes["nodeMyDocs"].Nodes["NodeMyChron"].Collapse();
            tvOfficerToolkit.Nodes["nodeMyDocs"].Nodes["nodReceived"].Collapse();
            if (Atmng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.OfficerTKHideDocs, false))
                AddNodeToDict(tvOfficerToolkit.Nodes["nodeMyDocs"]);

            tvOfficerToolkit.Nodes["NodeMyFiles"].Nodes["ndRecentFiles"].Collapse();
            if (Atmng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.OfficerTKHideFiles, false))
                AddNodeToDict(tvOfficerToolkit.Nodes["NodeMyFiles"]);

            if (Atmng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.OfficerTKHideAddBook, false))
                AddNodeToDict(tvOfficerToolkit.Nodes["nodeAddressBook"]);
            
            if (Atmng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.OfficerTKHideCalendar, false))
                AddNodeToDict(tvOfficerToolkit.Nodes["ndCalendar"]);

            if (or.OfficeRow.IsOfficeFileIdNull())
            {
                cmdMyOffice.Visible = Janus.Windows.UI.InheritableBoolean.False;
                tvOfficerToolkit.Nodes.Remove(tvOfficerToolkit.Nodes["NodeMyOffice"]);
            }
            else
            {
                tvOfficerToolkit.Nodes["NodeMyOffice"].Tag = or.OfficeRow.OfficeFileId;
                if (Atmng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.OfficerTKHideMyOffice, false))
                    AddNodeToDict(tvOfficerToolkit.Nodes["NodeMyOffice"]);
            }

            if (or.IsMyFileIdNull())
            {
                cmdPersonalFile.Visible = Janus.Windows.UI.InheritableBoolean.False;
                tvOfficerToolkit.Nodes.Remove(tvOfficerToolkit.Nodes["NodePersonalFile"]);
            }
            else
            {
                tvOfficerToolkit.Nodes["NodePersonalFile"].Tag = or.MyFileId;
                if (Atmng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.OfficerTKHidePersonalFile, false))
                    AddNodeToDict(tvOfficerToolkit.Nodes["NodePersonalFile"]);
            }

            if (or.IsShortcutsIdNull())
                tvOfficerToolkit.Nodes["nodeMyDocShortcuts"].Remove();
            else
                tvOfficerToolkit.Nodes["nodeMyDocShortcuts"].Tag = or.ShortcutsId;


        }

        public void SetOfficerToolkitPrefs()
        {
            //My BFLIST
            if (Atmng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.OfficerTKHideBF, false)) //should be hidden
            {
                if (!removedNodesDic.ContainsKey("NodeMyItems"))
                    AddNodeToDict(tvOfficerToolkit.Nodes["NodeMyItems"]);
            }
            else //should be displayed
            {
                if (removedNodesDic.ContainsKey("NodeMyItems"))
                    ToggleNodeDisplay("NodeMyItems", false);
            }

            //My DOCS
            if (Atmng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.OfficerTKHideDocs, false)) //should be hidden
            {
                if (!removedNodesDic.ContainsKey("nodeMyDocs"))
                    AddNodeToDict(tvOfficerToolkit.Nodes["nodeMyDocs"]);
            }
            else //should be displayed
            {
                if (removedNodesDic.ContainsKey("nodeMyDocs"))
                    ToggleNodeDisplay("nodeMyDocs", false);
            }

            //My FILES
            if (Atmng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.OfficerTKHideFiles, false)) //should be hidden
            {
                if (!removedNodesDic.ContainsKey("NodeMyFiles"))
                    AddNodeToDict(tvOfficerToolkit.Nodes["NodeMyFiles"]);
            }
            else //should be displayed
            {
                if (removedNodesDic.ContainsKey("NodeMyFiles"))
                    ToggleNodeDisplay("NodeMyFiles", false);
            }

            //My ADDRESS BOOK
            if (Atmng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.OfficerTKHideAddBook, false)) //should be hidden
            {
                if (!removedNodesDic.ContainsKey("nodeAddressBook"))
                    AddNodeToDict(tvOfficerToolkit.Nodes["nodeAddressBook"]);
            }
            else //should be displayed
            {
                if (removedNodesDic.ContainsKey("nodeAddressBook"))
                    ToggleNodeDisplay("nodeAddressBook", false);
            }

            //My Calendar
            if (Atmng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.OfficerTKHideCalendar, false)) //should be hidden
            {
                if (!removedNodesDic.ContainsKey("ndCalendar"))
                    AddNodeToDict(tvOfficerToolkit.Nodes["ndCalendar"]);
            }
            else //should be displayed
            {
                if (removedNodesDic.ContainsKey("ndCalendar"))
                    ToggleNodeDisplay("ndCalendar", false);
            }

            //My OFFICE
            if (cmdMyOffice.Visible == Janus.Windows.UI.InheritableBoolean.True) //assume command is visible, otherwise no OfficeId on officer row
            {
                if (Atmng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.OfficerTKHideMyOffice, false)) //should be hidden
                {
                    if (!removedNodesDic.ContainsKey("NodeMyOffice"))
                        AddNodeToDict(tvOfficerToolkit.Nodes["NodeMyOffice"]);
                }
                else //should be displayed
                {
                    if (removedNodesDic.ContainsKey("NodeMyOffice"))
                        ToggleNodeDisplay("NodeMyOffice", false);
                }
            }

            //My PERSONAL FILE
            if (cmdPersonalFile.Visible == Janus.Windows.UI.InheritableBoolean.True) //assume command is visible, otherwise no MyFileId on officer row
            {
                if (Atmng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.OfficerTKHidePersonalFile, false)) //should be hidden
                {
                    if (!removedNodesDic.ContainsKey("NodePersonalFile"))
                        AddNodeToDict(tvOfficerToolkit.Nodes["NodePersonalFile"]);
                }
                else //should be displayed
                {
                    if (removedNodesDic.ContainsKey("NodePersonalFile"))
                        ToggleNodeDisplay("NodePersonalFile", false);
                }
            }
        }


        private void tvOfficerToolkit_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (e.Node.GetNodeCount(true) > 0)
                    {
                        if (!(e.Node.Tag != null && e.Node.Tag.GetType() == typeof(appDB.EFileSearchRow)) && tvOfficerToolkit.HitTest(e.Location).Location == TreeViewHitTestLocations.Label)
                        {
                            if (e.Node.IsExpanded)
                                e.Node.Collapse(true);
                            else
                                e.Node.Expand();
                        }
                    }
                    switch (tvOfficerToolkit.HitTest(e.Location).Location)
                    {
                        case TreeViewHitTestLocations.Label:
                        case TreeViewHitTestLocations.Image:
                        case TreeViewHitTestLocations.PlusMinus:
                            selectedNode = e.Node;
                            NodeSelected(this, e);
                            break;
                    }
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void uiContextMenu1_Popup(object sender, EventArgs e)
        {
            try
            {
                cmdBFList.IsChecked = !Atmng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.OfficerTKHideBF, false);
                cmdDocs.IsChecked = !Atmng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.OfficerTKHideDocs, false);
                cmdFiles.IsChecked = !Atmng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.OfficerTKHideFiles, false);
                cmdCalendar.IsChecked = !Atmng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.OfficerTKHideCalendar, false);
                cmdAddBook.IsChecked = !Atmng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.OfficerTKHideAddBook, false);
                cmdPersonalFile.IsChecked = !Atmng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.OfficerTKHidePersonalFile, false);
                cmdMyOffice.IsChecked = !Atmng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.OfficerTKHideMyOffice, false);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                switch (e.Command.Key)
                {
                    case "cmdBFList":
                        ToggleNodeDisplay("NodeMyItems", !e.Command.IsChecked);
                        Atmng.OfficeMng.GetOfficerPrefs().SetPref(OfficerPrefsBE.OfficerTKHideBF, !e.Command.IsChecked);
                        break;
                    case "cmdDocs":
                        ToggleNodeDisplay("nodeMyDocs", !e.Command.IsChecked);
                        Atmng.OfficeMng.GetOfficerPrefs().SetPref(OfficerPrefsBE.OfficerTKHideDocs, !e.Command.IsChecked);
                        break;
                    case "cmdFiles":
                        ToggleNodeDisplay("NodeMyFiles", !e.Command.IsChecked);
                        Atmng.OfficeMng.GetOfficerPrefs().SetPref(OfficerPrefsBE.OfficerTKHideFiles, !e.Command.IsChecked);
                        break;
                    case "cmdCalendar":
                        ToggleNodeDisplay("ndCalendar", !e.Command.IsChecked);
                        Atmng.OfficeMng.GetOfficerPrefs().SetPref(OfficerPrefsBE.OfficerTKHideCalendar, !e.Command.IsChecked);
                        break;
                    case "cmdAddBook":
                        ToggleNodeDisplay("nodeAddressBook", !e.Command.IsChecked);
                        Atmng.OfficeMng.GetOfficerPrefs().SetPref(OfficerPrefsBE.OfficerTKHideAddBook, !e.Command.IsChecked);
                        break;
                    case "cmdPersonalFile":
                        ToggleNodeDisplay("NodePersonalFile", !e.Command.IsChecked);
                        Atmng.OfficeMng.GetOfficerPrefs().SetPref(OfficerPrefsBE.OfficerTKHidePersonalFile, !e.Command.IsChecked);
                        break;
                    case "cmdMyOffice":
                        ToggleNodeDisplay("NodeMyOffice", !e.Command.IsChecked);
                        Atmng.OfficeMng.GetOfficerPrefs().SetPref(OfficerPrefsBE.OfficerTKHideMyOffice, !e.Command.IsChecked);
                        break;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void ToggleNodeDisplay(string nodeName, bool hide)
        {
            if (hide)
                AddNodeToDict(tvOfficerToolkit.Nodes[nodeName]);
            else
            {
                switch (nodeName)
                {
                    case "NodeMyItems":
                        tvOfficerToolkit.Nodes.Insert(0, RemoveNodeFromDict(nodeName));
                        break;
                    case "nodeMyDocs":
                        if (tvOfficerToolkit.Nodes.ContainsKey("NodeMyItems"))
                            tvOfficerToolkit.Nodes.Insert(1, RemoveNodeFromDict(nodeName));
                        else
                            tvOfficerToolkit.Nodes.Insert(0, RemoveNodeFromDict(nodeName));
                        break;
                    case "NodeMyFiles":
                        if (tvOfficerToolkit.Nodes.ContainsKey("nodeMyDocs"))
                            tvOfficerToolkit.Nodes.Insert(tvOfficerToolkit.Nodes["nodeMyDocs"].Index + 1, RemoveNodeFromDict(nodeName));
                        else if (tvOfficerToolkit.Nodes.ContainsKey("NodeMyItems"))
                            tvOfficerToolkit.Nodes.Insert(1, RemoveNodeFromDict(nodeName));
                        else
                            tvOfficerToolkit.Nodes.Insert(0, RemoveNodeFromDict(nodeName));
                        break;
                    case "ndCalendar":
                        if (tvOfficerToolkit.Nodes.ContainsKey("NodeMyFiles"))
                            tvOfficerToolkit.Nodes.Insert(tvOfficerToolkit.Nodes["NodeMyFiles"].Index + 1, RemoveNodeFromDict(nodeName));
                        else if (tvOfficerToolkit.Nodes.ContainsKey("nodeMyDocs"))
                            tvOfficerToolkit.Nodes.Insert(tvOfficerToolkit.Nodes["nodeMyDocs"].Index + 1, RemoveNodeFromDict(nodeName));
                        else if (tvOfficerToolkit.Nodes.ContainsKey("NodeMyItems"))
                            tvOfficerToolkit.Nodes.Insert(1, RemoveNodeFromDict(nodeName));
                        else
                            tvOfficerToolkit.Nodes.Insert(0, RemoveNodeFromDict(nodeName));
                        break;
                    case "nodeAddressBook":
                        if (tvOfficerToolkit.Nodes.ContainsKey("ndCalendar"))
                            tvOfficerToolkit.Nodes.Insert(tvOfficerToolkit.Nodes["ndCalendar"].Index + 1, RemoveNodeFromDict(nodeName));
                        else if (tvOfficerToolkit.Nodes.ContainsKey("NodeMyFiles"))
                            tvOfficerToolkit.Nodes.Insert(tvOfficerToolkit.Nodes["NodeMyFiles"].Index + 1, RemoveNodeFromDict(nodeName));
                        else if (tvOfficerToolkit.Nodes.ContainsKey("nodeMyDocs"))
                            tvOfficerToolkit.Nodes.Insert(tvOfficerToolkit.Nodes["nodeMyDocs"].Index + 1, RemoveNodeFromDict(nodeName));
                        else if (tvOfficerToolkit.Nodes.ContainsKey("NodeMyItems"))
                            tvOfficerToolkit.Nodes.Insert(1, RemoveNodeFromDict(nodeName));
                        else
                            tvOfficerToolkit.Nodes.Insert(0, RemoveNodeFromDict(nodeName));
                        break;

                    case "NodePersonalFile":
                        if (tvOfficerToolkit.Nodes.ContainsKey("nodeMyDocShortcuts"))
                            tvOfficerToolkit.Nodes.Insert(tvOfficerToolkit.Nodes["nodeMyDocShortcuts"].Index + 1, RemoveNodeFromDict(nodeName));
                        else if (tvOfficerToolkit.Nodes.ContainsKey("nodeAddressBook"))
                            tvOfficerToolkit.Nodes.Insert(tvOfficerToolkit.Nodes["nodeAddressBook"].Index + 1, RemoveNodeFromDict(nodeName));
                        else if (tvOfficerToolkit.Nodes.ContainsKey("ndCalendar"))
                            tvOfficerToolkit.Nodes.Insert(tvOfficerToolkit.Nodes["ndCalendar"].Index + 1, RemoveNodeFromDict(nodeName));
                        else if (tvOfficerToolkit.Nodes.ContainsKey("NodeMyFiles"))
                            tvOfficerToolkit.Nodes.Insert(tvOfficerToolkit.Nodes["NodeMyFiles"].Index + 1, RemoveNodeFromDict(nodeName));
                        else if (tvOfficerToolkit.Nodes.ContainsKey("nodeMyDocs"))
                            tvOfficerToolkit.Nodes.Insert(tvOfficerToolkit.Nodes["nodeMyDocs"].Index + 1, RemoveNodeFromDict(nodeName));
                        else if (tvOfficerToolkit.Nodes.ContainsKey("NodeMyItems"))
                            tvOfficerToolkit.Nodes.Insert(1, RemoveNodeFromDict(nodeName));
                        else
                            tvOfficerToolkit.Nodes.Insert(0, RemoveNodeFromDict(nodeName));
                        break;
                    case "NodeMyOffice":
                        if (tvOfficerToolkit.Nodes.ContainsKey("NodePersonalFile"))
                            tvOfficerToolkit.Nodes.Insert(tvOfficerToolkit.Nodes["NodePersonalFile"].Index + 1, RemoveNodeFromDict(nodeName));
                        else if (tvOfficerToolkit.Nodes.ContainsKey("nodeMyDocShortcuts"))
                            tvOfficerToolkit.Nodes.Insert(tvOfficerToolkit.Nodes["nodeMyDocShortcuts"].Index + 1, RemoveNodeFromDict(nodeName));
                        else if (tvOfficerToolkit.Nodes.ContainsKey("nodeAddressBook"))
                            tvOfficerToolkit.Nodes.Insert(tvOfficerToolkit.Nodes["nodeAddressBook"].Index + 1, RemoveNodeFromDict(nodeName));
                        else if (tvOfficerToolkit.Nodes.ContainsKey("ndCalendar"))
                            tvOfficerToolkit.Nodes.Insert(tvOfficerToolkit.Nodes["ndCalendar"].Index + 1, RemoveNodeFromDict(nodeName));
                        else if (tvOfficerToolkit.Nodes.ContainsKey("NodeMyFiles"))
                            tvOfficerToolkit.Nodes.Insert(tvOfficerToolkit.Nodes["NodeMyFiles"].Index + 1, RemoveNodeFromDict(nodeName));
                        else if (tvOfficerToolkit.Nodes.ContainsKey("nodeMyDocs"))
                            tvOfficerToolkit.Nodes.Insert(tvOfficerToolkit.Nodes["nodeMyDocs"].Index + 1, RemoveNodeFromDict(nodeName));
                        else if (tvOfficerToolkit.Nodes.ContainsKey("NodeMyItems"))
                            tvOfficerToolkit.Nodes.Insert(1, RemoveNodeFromDict(nodeName));
                        else
                            tvOfficerToolkit.Nodes.Insert(0, RemoveNodeFromDict(nodeName));
                        break;
                }
                resetTreeViewBGColor();
            }
        }

        private void tvOfficerToolkit_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (tvOfficerToolkit.HitTest(e.Location).Location != TreeViewHitTestLocations.None)
                    {
                        uiCommandManager1.SetContextMenu(tvOfficerToolkit, null);
                    }
                    else
                    {
                        //    uiCommandManager1.SetContextMenu(tvOfficerToolkit, uiContextMenu1);

                    }
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void resetTreeViewBGColor()
        {
            //workaround to fix bold nodes not showing entire text
            tvOfficerToolkit.BackColor = SystemColors.Window;
        }

        private void ucOfficerToolkit_Load(object sender, EventArgs e)
        {
            resetTreeViewBGColor();
        }

        private void CreateNodes()
        {
            ImageList imgList = UIHelper.browseImgList();
            tvOfficerToolkit.ImageList = imgList;
            System.Windows.Forms.TreeNode treeNodeAllBFs = new System.Windows.Forms.TreeNode("All BFs");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("BFs and Mail");

            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("All Mail");
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Unread Mail");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Completed Items...");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("BF List", new System.Windows.Forms.TreeNode[] {
            treeNode3,
             treeNodeAllBFs,
            treeNode2,
                treeNode1,
           
            treeNode4});

            bool NotCVBImplementation=   !Atmng.GetSetting(atriumBE.AppBoolSetting.isCVB);
            System.Windows.Forms.TreeNode treeNode6 = null;

            if (NotCVBImplementation)
            {
                treeNode6 = new System.Windows.Forms.TreeNode("My Office\'s Opinions...");
            }

            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Checked out to me");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Drafts");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Today");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Yesterday");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("This Week");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Last Week");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Custom...");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Sent Items (Letterbook)", new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13});
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Today");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Yesterday");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("This Week");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Last Week");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Custom...");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Received Items", new System.Windows.Forms.TreeNode[] {
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18,
            treeNode19});

            System.Windows.Forms.TreeNode treeNode21 = null;

            if (NotCVBImplementation)
            {
                treeNode21 = new System.Windows.Forms.TreeNode("E-mails/Documents", new System.Windows.Forms.TreeNode[] 
                {
                    treeNode6,
                    treeNode7,
                    treeNode8,
                    treeNode14,
                    treeNode20
                });
            }
            else
            {
                treeNode21 = new System.Windows.Forms.TreeNode("E-mails/Documents", new System.Windows.Forms.TreeNode[] 
                {
                    treeNode7,
                    treeNode8,
                    treeNode14,
                    treeNode20
                });
            }
                
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Today");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Yesterday");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("This Week");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Last Week");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Custom...");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("Recently Viewed", new System.Windows.Forms.TreeNode[] {
            treeNode22,
            treeNode23,
            treeNode24,
            treeNode25,
            treeNode26});
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("Assigned Files");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("Files on which I am a contact");
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("Files", new System.Windows.Forms.TreeNode[] {
            treeNode27,
            treeNode28,
            treeNode29});
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("Calendar");
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("Address Book");
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("Shortcuts");
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("Personal File");
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("My Office");


            treeNodeAllBFs.ForeColor = System.Drawing.Color.Blue;
            treeNodeAllBFs.ImageIndex = 15;
            treeNodeAllBFs.Name = "NodeAllBFs";
            treeNodeAllBFs.NodeFont = new System.Drawing.Font("calibri", 8.75F);
            treeNodeAllBFs.SelectedImageIndex = 15;
            treeNodeAllBFs.Text = Properties.Resources.otkJustBFs;

            treeNode1.ForeColor = System.Drawing.Color.Blue;
            treeNode1.ImageIndex = 13;
            treeNode1.Name = "NodeUnreadMail";
            treeNode1.NodeFont = new System.Drawing.Font("calibri", 8.75F);
            treeNode1.SelectedImageIndex = 13;
            treeNode1.Text = Properties.Resources.otkUnreadMail;

            treeNode2.ForeColor = System.Drawing.Color.Blue;
            treeNode2.ImageIndex = 14;
            treeNode2.Name = "NodeAllMail";
            treeNode2.NodeFont = new System.Drawing.Font("calibri", 8.75F);
            treeNode2.SelectedImageIndex = 14;
            treeNode2.Text = Properties.Resources.otkAllMail;
            treeNode3.ForeColor = System.Drawing.Color.Blue;
            treeNode3.ImageIndex = 15;
            treeNode3.Name = "NodeBFList";
            treeNode3.NodeFont = new System.Drawing.Font("calibri", 8.75F);
            treeNode3.SelectedImageIndex = 15;
            treeNode3.Text = Properties.Resources.otkAllBFs;
            treeNode4.ForeColor = System.Drawing.Color.Blue;
            treeNode4.ImageIndex = 16;
            treeNode4.Name = "NodeCompletedItems";
            treeNode4.NodeFont = new System.Drawing.Font("calibri", 8.75F);
            treeNode4.SelectedImageIndex = 16;
            treeNode4.Text = Properties.Resources.otkCompletedItems;
            treeNode5.ImageIndex = 15;
            treeNode5.Name = "NodeMyItems";
            treeNode5.NodeFont = new System.Drawing.Font("calibri", 10F, System.Drawing.FontStyle.Bold);
            treeNode5.SelectedImageIndex = 15;
            treeNode5.Text = Properties.Resources.otkBFList;

            if (NotCVBImplementation)
            {
                treeNode6.ForeColor = System.Drawing.Color.Blue;
                treeNode6.ImageIndex = 18;
                treeNode6.Name = "ndMyOfficesOpinions";
                treeNode6.NodeFont = new System.Drawing.Font("calibri", 8.75F);
                treeNode6.SelectedImageIndex = 18;
                treeNode6.Text = Properties.Resources.otkMyOfficesOpinions;
            }

            treeNode7.ForeColor = System.Drawing.Color.Blue;
            treeNode7.ImageIndex = 19;
            treeNode7.Name = "NodeCheckOut";
            treeNode7.NodeFont = new System.Drawing.Font("calibri", 8.75F);
            treeNode7.SelectedImageIndex = 19;
            treeNode7.Text = Properties.Resources.otkCheckedOutToMe;
            treeNode8.ForeColor = System.Drawing.Color.Blue;
            treeNode8.ImageIndex = 20;
            treeNode8.Name = "NodeMyDrafts";
            treeNode8.NodeFont = new System.Drawing.Font("calibri", 8.75F);
            treeNode8.SelectedImageIndex = 20;
            treeNode8.Text = Properties.Resources.otkDrafts;
            treeNode9.ForeColor = System.Drawing.Color.Blue;
            treeNode9.ImageIndex = 21;
            treeNode9.Name = "ndChronToday";
            treeNode9.NodeFont = new System.Drawing.Font("calibri", 8.75F);
            treeNode9.SelectedImageIndex = 21;
            treeNode9.Text = Properties.Resources.otkToday;
            treeNode10.ForeColor = System.Drawing.Color.Blue;
            treeNode10.ImageIndex = 21;
            treeNode10.Name = "ndChronYesterday";
            treeNode10.NodeFont = new System.Drawing.Font("calibri", 8.75F);
            treeNode10.SelectedImageIndex = 21;
            treeNode10.Text = Properties.Resources.otkYesterday;
            treeNode11.ForeColor = System.Drawing.Color.Blue;
            treeNode11.ImageIndex = 21;
            treeNode11.Name = "ndChronThisWeek";
            treeNode11.NodeFont = new System.Drawing.Font("calibri", 8.75F);
            treeNode11.SelectedImageIndex = 21;
            treeNode11.Text = Properties.Resources.otkThisWeek;
            treeNode12.ForeColor = System.Drawing.Color.Blue;
            treeNode12.ImageIndex = 21;
            treeNode12.Name = "ndChronLastWeek";
            treeNode12.NodeFont = new System.Drawing.Font("calibri", 8.75F);
            treeNode12.SelectedImageIndex = 21;
            treeNode12.Text = Properties.Resources.otkLastWeek;
            treeNode13.ForeColor = System.Drawing.Color.Blue;
            treeNode13.ImageIndex = 21;
            treeNode13.Name = "ndChronCustom";
            treeNode13.NodeFont = new System.Drawing.Font("calibri", 8.75F);
            treeNode13.SelectedImageIndex = 21;
            treeNode13.Text = Properties.Resources.otkCustom;
            treeNode14.ImageIndex = 22;
            treeNode14.Name = "NodeMyChron";
            treeNode14.NodeFont = new System.Drawing.Font("calibri", 10F, System.Drawing.FontStyle.Bold);
            treeNode14.SelectedImageIndex = 22;
            treeNode14.Text = Properties.Resources.otkSentItems;
            treeNode15.ForeColor = System.Drawing.Color.Blue;
            treeNode15.ImageIndex = 21;
            treeNode15.Name = "ndRecToday";
            treeNode15.NodeFont = new System.Drawing.Font("calibri", 8.75F);
            treeNode15.SelectedImageIndex = 21;
            treeNode15.Text = Properties.Resources.otkToday;
            treeNode16.ForeColor = System.Drawing.Color.Blue;
            treeNode16.ImageIndex = 21;
            treeNode16.Name = "ndRecYesterday";
            treeNode16.NodeFont = new System.Drawing.Font("calibri", 8.75F);
            treeNode16.SelectedImageIndex = 21;
            treeNode16.Text = Properties.Resources.otkYesterday;
            treeNode17.ForeColor = System.Drawing.Color.Blue;
            treeNode17.ImageIndex = 21;
            treeNode17.Name = "ndRecThisWeek";
            treeNode17.NodeFont = new System.Drawing.Font("calibri", 8.75F);
            treeNode17.SelectedImageIndex = 21;
            treeNode17.Text = Properties.Resources.otkThisWeek;
            treeNode18.ForeColor = System.Drawing.Color.Blue;
            treeNode18.ImageIndex = 21;
            treeNode18.Name = "ndRecLastWeek";
            treeNode18.NodeFont = new System.Drawing.Font("calibri", 8.75F);
            treeNode18.SelectedImageIndex = 21;
            treeNode18.Text = Properties.Resources.otkLastWeek;
            treeNode19.ForeColor = System.Drawing.Color.Blue;
            treeNode19.ImageIndex = 21;
            treeNode19.Name = "ndRecCustom";
            treeNode19.NodeFont = new System.Drawing.Font("calibri", 8.75F);
            treeNode19.SelectedImageIndex = 21;
            treeNode19.Text = Properties.Resources.otkCustom;
            treeNode20.ImageIndex = 22;
            treeNode20.Name = "nodReceived";
            treeNode20.NodeFont = new System.Drawing.Font("calibri", 10F, System.Drawing.FontStyle.Bold);
            treeNode20.SelectedImageIndex = 22;
            treeNode20.Text = Properties.Resources.otkReceivedItems;
            treeNode21.ImageIndex = 23;
            treeNode21.Name = "nodeMyDocs";
            treeNode21.NodeFont = new System.Drawing.Font("calibri", 10F, System.Drawing.FontStyle.Bold);
            treeNode21.SelectedImageIndex = 23;
            treeNode21.Text = Properties.Resources.otkEmailsDocuments;
            treeNode22.ForeColor = System.Drawing.Color.Blue;
            treeNode22.ImageIndex = 21;
            treeNode22.Name = "ndToday";
            treeNode22.NodeFont = new System.Drawing.Font("calibri", 8.75F);
            treeNode22.SelectedImageIndex = 21;
            treeNode22.Text = Properties.Resources.otkToday;
            treeNode23.ForeColor = System.Drawing.Color.Blue;
            treeNode23.ImageIndex = 21;
            treeNode23.Name = "ndYesterday";
            treeNode23.NodeFont = new System.Drawing.Font("calibri", 8.75F);
            treeNode23.SelectedImageIndex = 21;
            treeNode23.Text = Properties.Resources.otkYesterday;
            treeNode24.ForeColor = System.Drawing.Color.Blue;
            treeNode24.ImageIndex = 21;
            treeNode24.Name = "ndThisWeek";
            treeNode24.NodeFont = new System.Drawing.Font("calibri", 8.75F);
            treeNode24.SelectedImageIndex = 21;
            treeNode24.Text = Properties.Resources.otkThisWeek;
            treeNode25.ForeColor = System.Drawing.Color.Blue;
            treeNode25.ImageIndex = 21;
            treeNode25.Name = "ndLastWeek";
            treeNode25.NodeFont = new System.Drawing.Font("calibri", 8.75F);
            treeNode25.SelectedImageIndex = 21;
            treeNode25.Text = Properties.Resources.otkLastWeek;
            treeNode26.ForeColor = System.Drawing.Color.Blue;
            treeNode26.ImageIndex = 21;
            treeNode26.Name = "ndCustom";
            treeNode26.NodeFont = new System.Drawing.Font("calibri", 8.75F);
            treeNode26.SelectedImageIndex = 21;
            treeNode26.Text = Properties.Resources.otkCustom;
            treeNode27.ImageIndex = 0;
            treeNode27.Name = "ndRecentFiles";
            treeNode27.NodeFont = new System.Drawing.Font("calibri", 10F, System.Drawing.FontStyle.Bold);
            treeNode27.SelectedImageIndex = 0;
            treeNode27.Text = Properties.Resources.otkRecentlyViewed;
            treeNode28.ForeColor = System.Drawing.Color.Blue;
            treeNode28.ImageIndex = 24;
            treeNode28.Name = "ndAss";
            treeNode28.NodeFont = new System.Drawing.Font("calibri", 8.75F);
            treeNode28.SelectedImageIndex = 24;
            treeNode28.Text = Properties.Resources.otkAssignedFiles;
            treeNode29.ForeColor = System.Drawing.Color.Blue;
            treeNode29.ImageIndex = 24;
            treeNode29.Name = "ndContact";
            treeNode29.NodeFont = new System.Drawing.Font("calibri", 8.75F);
            treeNode29.SelectedImageIndex = 24;
            treeNode29.Text = Properties.Resources.otkContactFiles;
            treeNode30.ImageIndex = 0;
            treeNode30.Name = "NodeMyFiles";
            treeNode30.NodeFont = new System.Drawing.Font("calibri", 10F, System.Drawing.FontStyle.Bold);
            treeNode30.SelectedImageIndex = 0;
            treeNode30.Text = Properties.Resources.otkFiles;
            treeNode31.ForeColor = System.Drawing.Color.Blue;
            treeNode31.ImageIndex = 17;
            treeNode31.Name = "ndCalendar";
            treeNode31.NodeFont = new System.Drawing.Font("calibri", 8.75F);
            treeNode31.SelectedImageIndex = 17;
            treeNode31.Text = Properties.Resources.otkCalendar;
            treeNode32.ForeColor = System.Drawing.Color.Blue;
            treeNode32.ImageIndex = 25;
            treeNode32.Name = "nodeAddressBook";
            treeNode32.NodeFont = new System.Drawing.Font("calibri", 8.75F);
            treeNode32.SelectedImageIndex = 25;
            treeNode32.Text = Properties.Resources.otkAddressBook;
            treeNode33.ForeColor = System.Drawing.Color.Blue;
            treeNode33.ImageIndex = 26;
            treeNode33.Name = "nodeMyDocShortcuts";
            treeNode33.NodeFont = new System.Drawing.Font("calibri", 8.75F);
            treeNode33.SelectedImageIndex = 26;
            treeNode33.Text = Properties.Resources.otkShortcuts;
            treeNode34.ForeColor = System.Drawing.Color.Blue;
            treeNode34.ImageIndex = 27;
            treeNode34.Name = "NodePersonalFile";
            treeNode34.NodeFont = new System.Drawing.Font("calibri", 8.75F);
            treeNode34.SelectedImageIndex = 27;
            treeNode34.Text = Properties.Resources.otkPersonalFile;
            treeNode35.ForeColor = System.Drawing.Color.Blue;
            treeNode35.ImageIndex = 28;
            treeNode35.Name = "NodeMyOffice";
            treeNode35.NodeFont = new System.Drawing.Font("calibri", 8.75F);
            treeNode35.SelectedImageIndex = 28;
            treeNode35.Text = Properties.Resources.otkMyOffice;
            this.tvOfficerToolkit.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode21,
            treeNode30,
            treeNode31,
            treeNode32,
            treeNode33,
            treeNode34,
            treeNode35});

        }
    }
}
