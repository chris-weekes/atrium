using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LawMate.Admin
{
    public partial class ucWorkflowLegend : UserControl
    {
        DataTable dtRoleLegend;
        atriumBE.FileManager FM;

        public ucWorkflowLegend()
        {
            InitializeComponent();
        }

        public void InitLegend(atriumBE.FileManager fm)
        {
            FM = fm;
            //get all roles and contact types with colors defined
            DataTable gRoles = FM.Codes("RoleCode");
            DataTable fRoles = FM.Codes("ContactType");

            dtRoleLegend = new DataTable();
            dtRoleLegend.Columns.Add("Type", typeof(string));
            dtRoleLegend.Columns.Add("Description", typeof(string));
            dtRoleLegend.Columns.Add("Color", typeof(string));

            foreach (DataRow dr in gRoles.Rows)
            {
                if (!dr.IsNull("WFBGColor") && dr["WFBGColor"].ToString() != "0")
                    dtRoleLegend.Rows.Add("G", dr["RoleEng"].ToString(), dr["WFBGColor"].ToString());
            }
            foreach (DataRow dr in fRoles.Rows)
            {
                if (!dr.IsNull("WFBGColor") && dr["WFBGColor"].ToString() != "0")
                    dtRoleLegend.Rows.Add("F", dr["ContactTypeDescEng"].ToString(), dr["WFBGColor"].ToString());
            }

            gridExRoleLegend.DataSource = dtRoleLegend;
            gridExRoleLegend.DataMember = "";
            UIHelper.SetDataTableAsGridDataSource(gridExRoleLegend, dtRoleLegend);
        }


        private void gridExRoleLegend_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            try
            {
                string sColor = e.Row.Cells["Color"].Text.ToString();
                Color cColor = Color.FromArgb(Convert.ToInt32(sColor));
                Janus.Windows.GridEX.GridEXFormatStyle gfs = new Janus.Windows.GridEX.GridEXFormatStyle();
                gfs.BackColor = cColor;
                e.Row.RowStyle = gfs;
            }
            catch (Exception x)
            {

                UIHelper.HandleUIException(x);
            }
        }


    }
}
