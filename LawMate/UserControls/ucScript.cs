using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

 namespace LawMate
{
    public partial class ucScript : ucBase
    {
        int docId;

        public ucScript()
        {
            InitializeComponent();
        }

        public void LoadHTML(string ctlNmVal)
        {

            docId = System.Convert.ToInt32(ctlNmVal.Replace("s-", ""));
            
           
            webBrowser1.ObjectForScripting = FM;

            webBrowser1.DocumentText = FM.AtMng.GetFile().GetDocMng().GetDocContent().Load(docId, null).ContentsAsText; //WI 73696 - added current version
        }

        public override void ReloadUserControlData()
        {
            webBrowser1.DocumentText = FM.AtMng.GetFile().GetDocMng().GetDocContent().Load(docId, null).ContentsAsText; //WI 73696 - added current version
        }
    }
}
