using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

 namespace LawMate.Admin
{
    public partial class fOfficeToJudicialDistrict : fBase
    {
        public fOfficeToJudicialDistrict()
        {
            InitializeComponent();
        }
        public fOfficeToJudicialDistrict(Form f): base(f)
        {
            InitializeComponent();
            AtMng.OfficeMng.GetOffice2JD().Load();
            atriumBE.FileManager FM = AtMng.GetFile();

            //office2JDGridEX.DropDowns["ddOffice"].SetDataBinding(FM.Codes("vofficelist"),"");
            //mccOfficeId.SetDataBinding(FM.Codes("vofficelist"), "");
            UIHelper.ComboBoxInit(FM.Codes("vofficelist"), office2JDGridEX.DropDowns["ddOffice"], FM);
            UIHelper.ComboBoxInit(FM.Codes("province"), office2JDGridEX.DropDowns["ddProvinceDescription"], FM);
            UIHelper.ComboBoxInit(FM.Codes("vofficelist"), mccOfficeId, FM);
            UIHelper.ComboBoxInit(FM.Codes("province"), mccProvinceCode, FM);

            //FM.Dispose();
            
            office2JDBindingSource.DataSource = AtMng.OfficeMng.DB;
            office2JDBindingSource.DataMember = AtMng.OfficeMng.DB.Office2JD.TableName;
        }

        private void fOfficeToJudicialDistrict_Load(object sender, EventArgs e)
        {
            office2JDGridEX.MoveFirst();
        }

        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            switch (e.Command.Key)
            {
                case "cmdCancel":
                    Cancel();
                    break;
                case "cmdDelete":
                    Delete();
                    break;
                case "cmdNew":
                    New();
                    break;
                case "cmdSave":
                    Save();
                    break;
            }
        }

        private void New()
        {
            lmDatasets.officeDB.Office2JDRow jdr = (lmDatasets.officeDB.Office2JDRow)AtMng.GetOffice().GetOffice2JD().Add(null);
            office2JDGridEX.MoveToNewRecord();
        }

        private void Cancel()
        {
            UIHelper.Cancel(office2JDBindingSource);
        }

        private void Save()
        {
            if (AtMng.OfficeMng.DB.Office2JD.HasErrors)
            {
                UIHelper.TableHasErrorsOnSaveMessBox(AtMng.OfficeMng.DB);
            }
            else
            {
                try
                {
                    this.office2JDBindingSource.EndEdit();

                    atLogic.BusinessProcess bp = AtMng.GetBP();
                    bp.AddForUpdate(AtMng.OfficeMng.GetOffice2JD());
                    bp.Update();
                }
                catch (Exception x)
                {
                    throw x;
                }
            }
        }

        private void Delete()
        {
            try
            {
                if (UIHelper.ConfirmDelete())
                {                    
                    if(CurrentRow()!=null)
                        CurrentRow().Delete();

                    this.office2JDBindingSource.EndEdit();

                    atLogic.BusinessProcess bp = AtMng.GetBP();
                    bp.AddForUpdate(AtMng.OfficeMng.GetOffice2JD());
                    bp.Update();
                }
            }
            catch (Exception x)
            {
                throw x;
            }
        }
        private lmDatasets.officeDB.Office2JDRow CurrentRow()
        {
            if (office2JDBindingSource.Current != null)
                return (lmDatasets.officeDB.Office2JDRow)((DataRowView)office2JDBindingSource.Current).Row;
            else
                return null;

        }
    }

}