using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using atriumBE;
using lmDatasets;
 namespace LawMate
{
    public partial class fBrowseOffices : Form
    {
        private officeDB.OfficeRow selectedOffice;
        private int selectedOfficeId;
        private atriumManager Atmng;

        public officeDB.OfficeRow SelectedOffice
        {
            get { return selectedOffice; }
        }

        public int OfficeId
        {
            get { return selectedOfficeId; }
        }

        public fBrowseOffices()
        {
            InitializeComponent();
        }
        public fBrowseOffices(atriumManager atmng)
        {
            InitializeComponent();
            Atmng = atmng;
            Atmng.OfficeMng.GetOffice().Load();
            officeBindingSource.DataSource = atmng.OfficeMng.DB ;
            officeBindingSource.DataMember = atmng.OfficeMng.DB.Office.TableName;
            atriumBE.FileManager FMCodes = atmng.GetFile();

            UIHelper.ComboBoxInit("OfficeType", officeGridEX.DropDowns["ddOfficeType"], FMCodes);
            UIHelper.ComboBoxInit("Department", officeGridEX.DropDowns["ddDepartment"], FMCodes);
            
            lblCurrentFile.Text = "";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                selectedOfficeId = selectedOffice.OfficeId;
                this.Close();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                selectedOfficeId = 0;
                this.Close();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void officeBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                if (officeBindingSource.Current == null)
                    return;
                selectedOffice = (officeDB.OfficeRow)((DataRowView)officeBindingSource.Current).Row;

                //ugly translation issue with officename/officenamefre
                if(Atmng.AppMan.Language.ToUpper()=="FRE")
                    lblCurrentFile.Text = selectedOffice.OfficeNameFre + " (" + selectedOffice.OfficeCode + ")";
                else
                    lblCurrentFile.Text = selectedOffice.OfficeName + " (" + selectedOffice.OfficeCode + ")";

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void officeGridEX_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                using (fWait fProgress = new fWait(LawMate.Properties.Resources.waitLoading))
                {
                    fFile f= fMain.Main.OpenFile(selectedOffice.OfficeFileId);
                    f.MoreInfo("officer");
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void fBrowseOffices_Load(object sender, EventArgs e)
        {
            try
            {
                officeGridEX.MoveTo(officeGridEX.FilterRow);
                officeGridEX.CurrentColumn = officeGridEX.RootTable.Columns["OfficeCode"];
                officeGridEX.EditMode = Janus.Windows.GridEX.EditMode.EditOn;
            }
            catch (Exception x)
            {
                //do nothing
            }
        }
    }
}