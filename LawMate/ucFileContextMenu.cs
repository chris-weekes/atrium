using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using lmDatasets;

 namespace LawMate
{
    public enum FileContextMenuItem
    {
        None,
        ViewFile,
        RenameFile,
        MoveFile,
        NewActivity,
        NewMail,
        NewDocument,
        NewFile,
        AddToShortcuts,
        CreateXRef,
        SearchFiles,
        SearchDocuments,
        Delete,
        FileProperties,
        FileStats,
        SearchOpinions,
        Refresh,
        NewOffice,
        ViewExplorer,
        NewMemo,
        NewFaxCoverSheet,
        MoveShortcutContainer,
        DeleteShortcutContainer,
        RenameShortcutContainer,
        NewShortcutContainer,
        DeleteFileShortcut,
        RenameFileShortcut,
        MoveFileShortcut,
        DocXrefViewInExternalApp,
        DocXrefViewInLMViewer,
        DocXrefMove,
        DocXrefJumpToFile,
        DocXrefDelete,
        docXrefRename,
        FileXrefView,
        FileXrefDelete,
        DynMenu,
        BrowseFileInExplorer,
        FileAKAs
    }

    public partial class ucFileContextMenu : UserControl
    {
        public event ContextEventHandler ContextMenuClicked;
        public FileTreeView Ftv;

        public ucFileContextMenu()
        {
            InitializeComponent();
        }
        public void LoadLabels()
        {
            cmdExplorerFindFile.Text = String.Format(Properties.Resources.cmdExplorerFindFile, Properties.Resources.AppName);
            cmdFLawMateExplorer.Text = String.Format(Properties.Resources.AppExplorer, Properties.Resources.AppName);
            cmdViewInLMViewer.Text = String.Format(Properties.Resources.AppDocViewerTooltip, Properties.Resources.AppName);
        }

        private bool usedInTreeView = true;
        public bool UsedInTreeView
        {
            get
            {
                return usedInTreeView;
            }
            set
            {
                usedInTreeView = value;

                Janus.Windows.UI.InheritableBoolean jUsedInTree = (usedInTreeView) ? Janus.Windows.UI.InheritableBoolean.True : Janus.Windows.UI.InheritableBoolean.False;

                cmdFNewOffice.Visible = jUsedInTree;
                uiContextMenu4.Commands["Separator"].Visible = jUsedInTree;
                cmdFMove.Visible = jUsedInTree;
                cmdFRename.Visible = jUsedInTree;
                cmdFRefresh.Visible = jUsedInTree;
                cmdFNewFile.Visible = jUsedInTree;
                cmdFNewOffice.Visible = jUsedInTree;
                cmdFDelete.Visible = jUsedInTree;
                cmdFNewFile.Visible = jUsedInTree;
                cmdExplorerFindFile.Visible = jUsedInTree;
            }
        }

        public void EnableMenuItem(bool EnableItem, FileContextMenuItem MenuItem)
        {
            Janus.Windows.UI.CommandBars.UICommand ts;
            switch(MenuItem)
            {
                case FileContextMenuItem.FileAKAs:
                    ts = cmdFileAKA;
                    break;
                case FileContextMenuItem.BrowseFileInExplorer:
                    ts = cmdExplorerFindFile;
                    break;
                case FileContextMenuItem.FileXrefView:
                    ts = cmdJumpToXref;
                    break;
                case FileContextMenuItem.FileXrefDelete:
                    ts = cmdDeleteXRef;
                    break;
                case FileContextMenuItem.DocXrefViewInExternalApp:
                    ts = cmdViewInExternal;
                    break;
                case FileContextMenuItem.DocXrefViewInLMViewer:
                    ts = cmdViewInLMViewer;
                    break;
                case FileContextMenuItem.DocXrefMove:
                    ts = cmdMove;
                    break;
                case FileContextMenuItem.DocXrefJumpToFile:
                    ts = cmdJumpToFileDocXref;
                    break;
                case FileContextMenuItem.DocXrefDelete:
                    ts = cmdDelete;
                    break;
                case FileContextMenuItem.MoveFileShortcut:
                    ts = cmdMoveFileShortcut;
                    break;
                case FileContextMenuItem.RenameFileShortcut:
                    ts = cmdRenameFileShortcut;
                    break;
                case FileContextMenuItem.DeleteFileShortcut:
                    ts = cmdDeleteFileShortcut;
                    break;
                case FileContextMenuItem.DeleteShortcutContainer:
                    ts = cmdDeleteShortcutFolder;
                    break;
                case FileContextMenuItem.RenameShortcutContainer:
                    ts = cmdRenameFolder;
                    break;
                case FileContextMenuItem.MoveShortcutContainer:
                    ts = cmdMoveShortcutContainer ;
                    break;
                case FileContextMenuItem.NewMemo:
                    ts = cmdFNewMemo;
                    break;
                case FileContextMenuItem.NewFaxCoverSheet:
                    ts = cmdFNewFaxCover;
                    break;
                case FileContextMenuItem.RenameFile:
                    ts = cmdFRename;
                    break;
                case FileContextMenuItem.Delete:
                    ts = cmdFDelete;
                    break;
                case FileContextMenuItem.AddToShortcuts:
                    ts = cmdFAddToShortcuts;
                    break;
                case FileContextMenuItem.MoveFile:
                    ts = cmdFMove;
                    break;
                case FileContextMenuItem.CreateXRef:
                    ts = cmdFNewXref;
                    break;
                case FileContextMenuItem.NewOffice:
                    ts = cmdFNewOffice;
                    break;
                case FileContextMenuItem.NewFile:
                    ts = cmdFNewFile;
                    break;
                case FileContextMenuItem.NewActivity:
                    ts = cmdFNewActivity;
                    break;
                case FileContextMenuItem.NewMail:
                    ts = cmdFNewEmail;
                    break;
                case FileContextMenuItem.NewDocument:
                    ts = cmdFNewDocument;
                    break;
                case FileContextMenuItem.ViewExplorer:
                    ts = cmdFLawMateExplorer;
                    break;
                default:
                    ts=null;
                    break;
            }
            if (ts != null)
            {
                if (EnableItem)
                    ts.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                else
                    ts.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            }
        }
        private void SetMenuClickedEventArgs(FileContextMenuItem MenuItem)
        {
            SetMenuClickedEventArgs(MenuItem, null);
        }
        private void SetMenuClickedEventArgs(FileContextMenuItem MenuItem,ActivityConfig.ACSeriesRow acs)
        {
            appDB.EFileSearchRow efilerow=null;
            docDB.DocXRefRow docxrefrow = null;
            TreeNode nd = null;
            try
            {
                nd = (TreeNode)uiCommandManager1.Tag;
                if (nd.Tag.GetType() == typeof(appDB.EFileSearchRow))
                    efilerow = (appDB.EFileSearchRow)nd.Tag;
                else if (nd.Tag.GetType() == typeof(docDB.DocXRefRow))
                    docxrefrow = (docDB.DocXRefRow)nd.Tag;


                //efilerow = (appDB.EFileSearchRow)nd.Tag;
            }
            catch (Exception x)
            {
                efilerow = (appDB.EFileSearchRow)uiCommandManager1.Tag;
            }

            if (ContextMenuClicked != null)
            {
                FileContextEventArgs fe = new FileContextEventArgs();
                fe.MenuItem = MenuItem;
                fe.SelectedFile = efilerow;
                fe.ACSeries = acs;
                fe.Node = nd;
                ContextMenuClicked(this, fe);
            }
        }
        
        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                switch (e.Command.Key)
                {
                    case "cmdFileAKA":
                        SetMenuClickedEventArgs(FileContextMenuItem.FileAKAs);
                        break;
                    case "cmdExplorerFindFile":
                        SetMenuClickedEventArgs(FileContextMenuItem.BrowseFileInExplorer);
                        break;
                    case "cmdDeleteXRef":
                        SetMenuClickedEventArgs(FileContextMenuItem.FileXrefDelete);
                        break;
                    case "cmdJumpToXref":
                        SetMenuClickedEventArgs(FileContextMenuItem.FileXrefView);
                        break;
                    case "cmdRename":
                        SetMenuClickedEventArgs(FileContextMenuItem.docXrefRename);
                        break;
                    case "cmdViewInLMViewer":
                        SetMenuClickedEventArgs(FileContextMenuItem.DocXrefViewInLMViewer);
                        break;
                    case "cmdViewInExternal":
                        SetMenuClickedEventArgs(FileContextMenuItem.DocXrefViewInExternalApp);
                        break;
                    case "cmdMove":
                        SetMenuClickedEventArgs(FileContextMenuItem.DocXrefMove);
                        break;
                    case "cmdDelete":
                        SetMenuClickedEventArgs(FileContextMenuItem.DocXrefDelete);
                        break;
                    case "cmdJumpToFileDocXref":
                        SetMenuClickedEventArgs(FileContextMenuItem.DocXrefJumpToFile);
                        break;
                    case "cmdNewContainer":
                        SetMenuClickedEventArgs(FileContextMenuItem.NewShortcutContainer);
                        break;
                    case "cmdRenameFileShortcut":
                        SetMenuClickedEventArgs(FileContextMenuItem.RenameFileShortcut);
                        break;
                    case "cmdMoveFileShortcut":
                        SetMenuClickedEventArgs(FileContextMenuItem.MoveFileShortcut);
                        break;
                    case "cmdDeleteFileShortcut":
                        SetMenuClickedEventArgs(FileContextMenuItem.DeleteFileShortcut);
                        break;
                    case "cmdRenameFolder":
                        SetMenuClickedEventArgs(FileContextMenuItem.RenameShortcutContainer);
                        break;
                    case "cmdDeleteShortcutFolder":
                        SetMenuClickedEventArgs(FileContextMenuItem.DeleteShortcutContainer);
                        break;
                    case "cmdMoveShortcutContainer":
                        SetMenuClickedEventArgs(FileContextMenuItem.MoveShortcutContainer);
                        break;
                    case "cmdFAddToShortcuts":
                        SetMenuClickedEventArgs(FileContextMenuItem.AddToShortcuts);
                        break;
                    case "cmdFDelete":
                        SetMenuClickedEventArgs(FileContextMenuItem.Delete);
                        break;
                    case "cmdFFileProperties":
                        SetMenuClickedEventArgs(FileContextMenuItem.FileProperties);
                        break;
                    case "cmdFFileStats":
                        SetMenuClickedEventArgs(FileContextMenuItem.FileStats);
                        break;
                    case "cmdFJumpToFile":
                    case "cmdJumpToFileFileXref":
                    case "cmdJumpToFile":
                        SetMenuClickedEventArgs(FileContextMenuItem.ViewFile);
                        break;
                    case "cmdFLawMateExplorer":
                        SetMenuClickedEventArgs(FileContextMenuItem.ViewExplorer);
                        break;
                    case "cmdFMove":
                        SetMenuClickedEventArgs(FileContextMenuItem.MoveFile);
                        break;
                    case "cmdFNewActivity":
                        SetMenuClickedEventArgs(FileContextMenuItem.NewActivity);
                        break;
                    case "cmdFNewDocument":
                        SetMenuClickedEventArgs(FileContextMenuItem.NewDocument);
                        break;
                    case "cmdFNewEmail":
                        SetMenuClickedEventArgs(FileContextMenuItem.NewMail);
                        break;
                    case "cmdFNewFaxCover":
                        SetMenuClickedEventArgs(FileContextMenuItem.NewFaxCoverSheet);
                        break;
                    case "cmdFNewFile":
                        SetMenuClickedEventArgs(FileContextMenuItem.NewFile);
                        break;
                    case "cmdFNewMemo":
                        SetMenuClickedEventArgs(FileContextMenuItem.NewMemo);
                        break;
                    case "cmdFNewOffice":
                        SetMenuClickedEventArgs(FileContextMenuItem.NewOffice);
                        break;
                    case "cmdFNewXref":
                        SetMenuClickedEventArgs(FileContextMenuItem.CreateXRef);
                        break;
                    case "cmdRefresh":
                    case "cmdFRefresh":
                        SetMenuClickedEventArgs(FileContextMenuItem.Refresh);
                        break;
                    case "cmdFRename":
                        SetMenuClickedEventArgs(FileContextMenuItem.RenameFile);
                        break;
                    case "cmdFSearchDocuments":
                        SetMenuClickedEventArgs(FileContextMenuItem.SearchDocuments);
                        break;
                    case "cmdFSearchFiles":
                        SetMenuClickedEventArgs(FileContextMenuItem.SearchFiles);
                        break;
                    case "cmdFSearchOpinions":
                        SetMenuClickedEventArgs(FileContextMenuItem.SearchOpinions);
                        break;
                }
                if (e.Command.Key.StartsWith("tsACMenu"))
                {
                    SetMenuClickedEventArgs(FileContextMenuItem.DynMenu,(ActivityConfig.ACSeriesRow) e.Command.Tag);
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }


    }
}
