using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

 namespace LawMate.Admin
{
    public partial class fFileMetaChildren : fBase
    {
        atLogic.ObjectBE obeFileType;
        atLogic.ObjectBE obeMetaType;

        public fFileMetaChildren()
        {
            InitializeComponent();
        }

        public fFileMetaChildren(Form f)
            : base(f)
        {
            InitializeComponent();

            fileTypeChildrenBindingSource.DataSource = AtMng.CodeDB;
            fileTypeChildrenBindingSource.DataMember = AtMng.CodeDB.FileTypeChildren.TableName;

            metaTypeChildrenBindingSource.DataSource = AtMng.CodeDB;
            metaTypeChildrenBindingSource.DataMember = AtMng.CodeDB.MetaTypeChildren.TableName;

            fileTypeChildrenGridEX.DropDowns["ddFileType"].SetDataBinding(AtMng.GetFile().Codes("FileType"), "");
            metaTypeChildrenGridEX.DropDowns["ddMetaType"].SetDataBinding(AtMng.GetFile().Codes("FileMetaType"), "");

            obeFileType = AtMng.GetCodeTableBE("FileTypeChildren");
            obeFileType.Load();
            obeMetaType = AtMng.GetCodeTableBE("MetaTypeChildren");
            obeMetaType.Load();
        }

        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                switch (e.Command.Key)
                {
                    case "cmdCancel":
                        Cancel();
                        break;
                    case "cmdSave":
                        Save();
                        break;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
        private void Cancel()
        {
            try
            {
                if (MessageBox.Show("All edits (to all records) will be cancelled.  Are you sure you want to proceed?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    fileTypeChildrenGridEX.CancelCurrentEdit();
                    metaTypeChildrenGridEX.CancelCurrentEdit();
                    UIHelper.Cancel(fileTypeChildrenBindingSource);
                    UIHelper.Cancel(metaTypeChildrenBindingSource);
                    UIHelper.Cancel(AtMng.CodeDB);
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void Save()
        {
            try
            {
                if (MessageBox.Show("All edits (to all records) will be saved.  Are you sure you want to proceed?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    fileTypeChildrenGridEX.CurrentRow.EndEdit();
                    fileTypeChildrenGridEX.UpdateData();
                    metaTypeChildrenGridEX.CurrentRow.EndEdit();
                    metaTypeChildrenGridEX.UpdateData();

                    fileTypeChildrenBindingSource.EndEdit();
                    metaTypeChildrenBindingSource.EndEdit();

                    atLogic.BusinessProcess bp = AtMng.GetBP();

                    bp.AddForUpdate(obeFileType);
                    bp.AddForUpdate(obeMetaType);
                    bp.Update();

                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void fFileMetaChildren_Load(object sender, EventArgs e)
        {
            fileTypeChildrenGridEX.MoveFirst();
            metaTypeChildrenGridEX.MoveFirst();
        }

        private void fileTypeChildrenGridEX_DeletingRecord(object sender, Janus.Windows.GridEX.RowActionCancelEventArgs e)
        {
            try
            {
                if (UIHelper.ConfirmDelete() == false)
                    e.Cancel = true;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

    }
}

