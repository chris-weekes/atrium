using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

 namespace LawMate
{
    public partial class ucBase : UserControl
    {

        atriumBE.FileManager fmCurrent;

        public atriumBE.FileManager FM
        {
            get { return fmCurrent; }
            set { fmCurrent = value; }
        }
        public ucBase()
        {
            InitializeComponent();

        }
        public virtual void ReadOnly(bool makeReadOnly)
        {
        }

        public virtual void ApplySecurity(DataRow dr)
        { 
        }
        public virtual void ApplyBR(bool DataNotDirty)
        {
            fFile f=FileForm();
            if(f!=null)
                f.IsDirty = !DataNotDirty;

        }

        public virtual void ReloadUserControlData()
        {
        }

        public virtual bool controlHasBorder()
        {
            return true;
        }

        public virtual string ucDisplayName()
        {
            return "";
        }
        public virtual void Save()
        {
        }
        public virtual void Cancel()
        {
        }
        public virtual void EndEdit()
        {
        }

        public virtual void Delete()
        { 
        }
        public virtual void SaveLayout()
        { }

        public virtual void MoveTab(string operation)
        {

        }

        public virtual void MoreInfo(string linkTable, int linkId)
        {
        }

        public virtual void MoreInfo(string linkTable, string filter)
        {
        }
        public virtual Janus.Windows.UI.CommandBars.UICommandManager CommandManager()
        {
            return null;
        }

        public virtual Janus.Windows.Common.VisualStyleManager VSManager()
        {
            return null;
        }

        public fFile FileForm()
        {
            if (this.ParentForm == null)
                return null;
            else if (this.ParentForm.GetType() == typeof(fFile))
                return (fFile)this.ParentForm;
            else
                return null;
        }

    }
}
