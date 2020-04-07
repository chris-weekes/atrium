using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

 namespace LawMate.Admin
{
    public partial class fCity : fBase
    {
        public fCity()
        {
            InitializeComponent();
        }
        public fCity(Form f): base(f)
        {
            InitializeComponent();
            AtMng.GetProvince().Load();
            AtMng.GetCity().Load();
            provinceBindingSource.DataMember = "Province";
            provinceBindingSource.DataSource = AtMng.DB;
            
        }

        private void Save()
        {
            provinceGridEX.CurrentRow.EndEdit();
            provinceGridEX.UpdateData();
            provinceGridEX.Update();
            provinceBindingSource.EndEdit();

            atLogic.BusinessProcess bp = AtMng.GetBP();
            bp.AddForUpdate(AtMng.GetProvince());
            bp.AddForUpdate(AtMng.GetCity());
            bp.Update();
        }
        private void Cancel()
        {
            try
            {
                if (MessageBox.Show("All edits will be cancelled.  Are you sure you want to proceed?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    UIHelper.Cancel(provinceBindingSource);
                }
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
                switch(e.Command.Key)
                {
                    case "cmdNew":
                        lmDatasets.appDB.CityRow cr=(lmDatasets.appDB.CityRow) AtMng.GetCity().Add(CurrentRow());
                        cr.CityID= AtMng.PKIDGet("City", 10);
                        break;
                    case "cmdSave":
                        Save();
                        break;
                    case "cmdCancel":
                        Cancel();
                        break;
                }
            }
            catch (Exception x)
            {
                
                UIHelper.HandleUIException(x);
            }
        }

        public lmDatasets.appDB.ProvinceRow CurrentRow()
        {
            return (lmDatasets.appDB.ProvinceRow)((DataRowView)provinceBindingSource.Current).Row;
        }
    }
}

