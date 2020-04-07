using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using atriumBE;
using lmDatasets;
using Janus.Windows.GridEX;

namespace LawMate
{
    public partial class fVersionHistory : Form //LawMate.fBase
    {

        DocManager myActualDocMng;
        docDB.DocumentRow myActualDR;

        FileManager myVirtualFM;
        DocManager myVirtualDM;

        public fVersionHistory(DocManager docMng, docDB.DocumentRow dr)
            //: base(f)
        {
            InitializeComponent();

            myActualDocMng = docMng;
            myActualDR = dr;

            myVirtualFM = fMain.Main.AtMng.GetFile();
            myVirtualDM = myVirtualFM.GetDocMng();

            versionHistoryBindingSource.DataSource = myActualDocMng.GetVersionListDataTable(myActualDR.DocRefId,myActualDR.FileId);
            ucDocViewVerHistory.Visible = false;
            this.Text = dr.efSubject;
            if (versionHistoryBindingSource.Count == 0) { MessageBox.Show(Properties.Resources.UINoPreviousVersion, Properties.Resources.UINoPreviousVersionCaption, MessageBoxButtons.OK); }

        }

        public int VersionCount
        {
            get { return versionHistoryBindingSource.Count; }
        }

        public docDB.VersionHistoryListRow CurrentRow()
        {
            if (versionHistoryBindingSource.Current == null)
                return null;
            else
                return (docDB.VersionHistoryListRow)((DataRowView)versionHistoryBindingSource.Current).Row;
        }

        private void grexVersionHistory_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            try
            {
                if (e.Column.Key.ToUpper() == "DELETE") // verify which column button was clicked
                {
                    DeleteVersion();
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void DeleteVersion()
        {
            if (CurrentRow() == null) { return; }

            if (UIHelper.ConfirmDelete(Properties.Resources.UIDeleteVersion, Properties.Resources.UIDeleteVersionCaption))
            {

                int DocRefExists = myActualDocMng.GetDocContent().DocContentAuditDelete(CurrentRow().DocId, CurrentRow().Version);
                if (DocRefExists == 0)
                {
                    CurrentRow().Delete();
                    versionHistoryBindingSource.EndEdit();
                }
                else
                {
                    MessageBox.Show("The version you are trying to delete, is used by another file", "Cannot Delete Version", MessageBoxButtons.OK);
                }
                
            }
        }

        private void PreviewVersion()
        {
            
            docDB.DocumentRow dr = myVirtualDM.GetDocument().Load(myActualDR.DocId);
            myVirtualDM.GetDocContent().Load(dr.DocRefId, CurrentRow().Version);
            ucDocViewVerHistory.Init(myVirtualDM);
            //ucDocViewVerHistory.ReturnFocusTo = this.grexVersionHistory;
            DataView dvDoc = new DataView(dr.Table, "DocId=" + dr.DocId.ToString(), "", DataViewRowState.CurrentRows);

            ucDocViewVerHistory.Datasource = dvDoc;
            ucDocViewVerHistory.Preview();
            ucDocViewVerHistory.Visible = true;
        }

        private void RecoverVersion()
        {
          
            
            docDB.DocumentRow dr = myVirtualDM.GetDocument().Load(myActualDR.DocId);
            if(!(dr.DocContentRow !=null && dr.DocContentRow.Version==CurrentRow().Version))
                 myVirtualDM.GetDocContent().Load(dr.DocRefId, CurrentRow().Version);

            myActualDR.DocContentRow.Contents = dr.DocContentRow.Contents;
            myActualDR.DocContentRow.Ext = dr.DocContentRow.Ext;
            myActualDR.DocContentRow.Size = dr.DocContentRow.Size;
            myActualDR.DocContentRow.ModDate = dr.DocContentRow.ModDate;
            myActualDR.DocContentRow.CreateDate = dr.DocContentRow.CreateDate;

            myActualDocMng.FM.SaveAll();
            //atLogic.BusinessProcess bp = myActualDocMng.FM.GetBP();
            //bp.AddForUpdate(myActualDocMng.GetDocContent());
            //bp.AddForUpdate(myActualDocMng.GetDocument());
            //bp.Update();

            this.Close();
        }

        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {

            try
            {
                switch (e.Command.Key)
                {
                    case "cmdDelete":
                        DeleteVersion();
                        break;
                    case "cmdRecover":
                        RecoverVersion();
                        break;
                    case "cmdPreview":
                        PreviewVersion();
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
