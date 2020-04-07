using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using lmDatasets;

 namespace LawMate
{
    public partial class ucTemplate : ucBase
    {
        public ucTemplate()
        {
            InitializeComponent();
        }
        public void bindDocumentData(lmDatasets.appDB.TemplateDataTable dt)
        {
            templateBindingSource.DataSource = dt.DataSet;
            templateBindingSource.DataMember = dt.TableName;


        }

        public override void MoreInfo(string linkTable, int linkId)
        {
            templateBindingSource.Position = templateBindingSource.Find("TemplateId", linkId);
        }
        private void templateGridEX_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                string let=(string)templateGridEX.CurrentRow.Cells[e.Column].Value;
            docDB.DocumentRow newDoc = FM.AtMng.GetTemplate().GenLetter(FM, let, new System.Collections.Hashtable());

           // newDoc.efSubject = "Success";

            //FM.GetDocMng().GetDocument().Update();
            //FM.AtMng.AppMan.Commit();
        }
        catch (Exception x)
        {
            UIHelper.HandleUIException(x);
        }

        }

        private void templateGridEX_EnabledChanged(object sender, EventArgs e)
        {
            try
            {
                UIHelper.GridEnabledChanged(templateGridEX);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
    }
}

