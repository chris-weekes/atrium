using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;

 namespace LawMate.UserControls
{
    public interface IRequiredCtl
    {
         Color ReqColor
        {
            get;
            set;
        }
         bool IsPopulated
        {
            get;
        }
         void RequiredAction();
    }

    [DefaultBindingProperty("SelectedValue")]
    [LookupBindingProperties("DataSource", "DisplayMember", "ValueMember", "SelectedValue")]
    public partial class ucMultiDropDown : UserControl, IRequiredCtl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        bool OKToUpdate = true;

        public event EventHandler ASelectedValueChanged;
        protected virtual void OnASelectedValueChanged()
        {
            if (ASelectedValueChanged != null)
                ASelectedValueChanged(this, new EventArgs());
        }

        [Category("Data")]
        public override string Text
        {
            get
            {
                return cboMulti.Text; 
            }
        }

        public bool IsPopulated
        {
            get
            {
                return this.Text != "";
            }
        }

        public Janus.Windows.GridEX.EditControls.MultiColumnCombo ucMcc
        {
            get { return cboMulti; }
        }

        [Category("Layout")]
        public Color ReqColor
        {
            set
            {
                cboMulti.BackColor = value;

            }
            get
            {
                return cboMulti.BackColor; ;
            }
        }
        [Localizable(true),
        Category("Layout")]
        public int Middle
        {
            set
            {
                cboMulti.Width = value - 3;
                lblTitle.Left = value - 3;
            }
            get
            {
                return cboMulti.Width + 3;
            }
        }

        [Category("Data")]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        public string ValueMember
        {
            set
            {
                cboMulti.ValueMember = value;
            }
            get
            {
                return cboMulti.ValueMember;
            }
        }
        [
        Localizable(true),
        Category("Data")]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        public string DisplayMember
        {
            set
            {
                cboMulti.DisplayMember = value;
            }
            get
            {
                return cboMulti.DisplayMember;
            }
        }

        [Bindable(BindableSupport.Yes)]
        [Browsable(false)]
        public object SelectedValue
        {
            set
            {
                
                OKToUpdate = false;
                string v=null, sv=null;
                if (value != null)
                    v = value.ToString();
                if (cboMulti.Value != null)
                    sv = cboMulti.Value.ToString();

                if (this.DataBindings.Count > 0)//&& this.BindingContext.Contains(this.DataBindings["SelectedValue"].DataSource))
                {
                    try
                    {

                        if (this.BindingContext[this.DataBindings["SelectedValue"].DataSource].Count > 0)
                        {
                            DataRow drv = (DataRow)((DataRowView)this.BindingContext[this.DataBindings["SelectedValue"].DataSource].Current).Row;
                            if (drv.RowState == DataRowState.Added)
                            {
                                //hide oboslete in list
                                if (cboMulti.DataSource.GetType() == typeof(DataView))
                                {
                                    DataView dv = (DataView)cboMulti.DataSource;
                                    FilterObsolete(dv);
                                }
                            }
                        }
                    }
                    catch (Exception x)
                    {
                        //ignore
                    }
                }
                if (v != sv)
                {
                    cboMulti.Value = value;

                    if (v != "")
                    {
                        if (cboMulti.DropDownList.SelectedItems.Count > 0)
                        {
                            System.Data.DataRowView dv = (System.Data.DataRowView)cboMulti.DropDownList.SelectedItems[0].GetRow().DataRow;
                            lblTitle.Text = dv[Column2].ToString();
                        }
                    }
                    else
                        lblTitle.Text = "";
                        
                }
                if (v == "")
                    lblTitle.Text = "";

                this.toolTip1.SetToolTip(this.lblTitle, lblTitle.Text);
                //if (PropertyChanged != null && isChanged)
                //{
                //    PropertyChangedEventArgs pce = new PropertyChangedEventArgs("SelectedValue");
                //    PropertyChanged(this, pce);
                //}

                OKToUpdate = true;
                OnTextChanged(new EventArgs());
            }
            get
            {

                return cboMulti.Value; ;

            }
        }

        private  void FilterObsolete(DataView dv)
        {
            if (dv == null)
                return;

            OKToUpdate = false;
            object val = cboMulti.Value;
            if (dv.Table.Columns.Contains("Obsolete"))
                dv.RowFilter = "Obsolete=false";
            else if (dv.Table.Columns.Contains("CurrentEmployee"))
                dv.RowFilter = "CurrentEmployee=true";
            cboMulti.Value = val;
            OKToUpdate = true;
        }

        [Bindable(BindableSupport.Yes)]
        [Browsable(false)]
        public int SelectedIndex
        {
             get
            {

                return cboMulti.SelectedIndex; ;

            }
        }


        [Category("Data")]
        [Description("Indicates the source of data for the control.")]
        [RefreshProperties(RefreshProperties.Repaint)]
        [AttributeProvider(typeof(IListSource))]
        public object DataSource
        {
            set
            {
                cboMulti.DataSource = value;
            }
            get
            {
                return cboMulti.DataSource;
            }
           
        }
        [Category("Data")]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        public string Column1
        {
            set
            {
                cboMulti.DropDownList.Columns[0].DataMember = value;
            }
            get
            {
                return cboMulti.DropDownList.Columns[0].DataMember;
            }
        }
        [Localizable(true),Category("Data")]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        public string Column2
        {
            set
            {
                cboMulti.DropDownList.Columns[1].DataMember = value;
            }
            get
            {
                return cboMulti.DropDownList.Columns[1].DataMember;
            }
        }

        [Category("Data")]
        public Janus.Windows.GridEX.ComboStyle ComboType
        {
            set
            {
                cboMulti.ComboStyle = value;
            }
            get
            {
                return cboMulti.ComboStyle;
            }
        }

        [Category("Data")]
        public bool ReadOnly
        {
            set
            {
                cboMulti.ReadOnly = value;
                if (cboMulti.ReadOnly)
                    cboMulti.BackColor = SystemColors.Control;
                else
                    cboMulti.BackColor = SystemColors.Window;
            }
            get
            {
                return cboMulti.ReadOnly;
            }
        }

        [Localizable(true),Category("Data")]
        public string DisplayNameColumn1
        {
            set
            {
                cboMulti.DropDownList.Columns[0].Caption = value;
            }
            get
            {
                return cboMulti.DropDownList.Columns[0].Caption;
            }
        }
        [Category("Data")]
        public bool DDColumn1Visible
        {
            set 
            {  
                cboMulti.DropDownList.Columns[0].Visible = value;
                if(value)
                    cboMulti.DropDownList.ColumnHeaders = InheritableBoolean.True;
                else
                    cboMulti.DropDownList.ColumnHeaders = InheritableBoolean.False;
            }
            get { return cboMulti.DropDownList.Columns[0].Visible; }
        }
        [Category("Data")]
        public int DropDownColumn1Width
        {
            set
            {
                if (value == 0)
                    cboMulti.DropDownList.Columns[0].AutoSize();
                else
                    cboMulti.DropDownList.Columns[0].Width = value;
            }
            get
            {
                return cboMulti.DropDownList.Columns[0].Width;
            }
        }

        [Category("Data")]
        public int DropDownColumn2Width
        {
            set
            {
                if (value == 0)
                {
                    cboMulti.DropDownList.Columns[1].AutoSize();
                }
                else
                    cboMulti.DropDownList.Columns[1].Width = value;
            }
            get
            {
                return cboMulti.DropDownList.Columns[1].Width;
            }
        }

        [Localizable(true),Category("Data")]
        public string DisplayNameColumn2
        {
            set
            {
                cboMulti.DropDownList.Columns[1].Caption = value;
            }
            get
            {
                return cboMulti.DropDownList.Columns[1].Caption;
            }
        }


        public ucMultiDropDown()
        {
            InitializeComponent();
        }

        private void cboMulti_ValueChanged(object sender, EventArgs e)
        {
            OnASelectedValueChanged();

            if (cboMulti.DropDownList.SelectedItems.Count > 0)
            {
                System.Data.DataRowView dv = (System.Data.DataRowView)cboMulti.DropDownList.SelectedItems[0].GetRow().DataRow;
                lblTitle.Text = dv[Column2].ToString();
            }
            else
                lblTitle.Text = "";

            this.toolTip1.SetToolTip(this.lblTitle, lblTitle.Text);

            if (PropertyChanged != null & OKToUpdate)
            {
                PropertyChangedEventArgs pce = new PropertyChangedEventArgs("SelectedValue");
                PropertyChanged(this, pce);
            }
            //isChanged = false;

            OnTextChanged(new EventArgs());
        }

        public void SetDataBinding(DataTable dataSource, string dataMember)
        {
            OKToUpdate = false;
            DataView dv= new DataView(dataSource);
          //  dv.Sort =  dataSource.Columns[0].ColumnName;
            object val = cboMulti.Value;
            cboMulti.SetDataBinding(dv, dataMember);
            cboMulti.Value = val;
            OKToUpdate = true;
        }
        public void SetDataBinding(object dataSource, string dataMember)
        {
            OKToUpdate = false;
            object val = cboMulti.Value; 
            cboMulti.SetDataBinding(dataSource, dataMember);
            cboMulti.Value = val;
            OKToUpdate = true;
        }

        string myFilterOn;
        string myFilterBy;
        DataTable myFilterDT;
        DataRow myFilterRow;
        public void SetFilter(string columnFilterOn,string dcFilterBy,DataRow dr)
        {
            if (myFilterDT == null)
            {
                myFilterDT = dr.Table;
                myFilterRow = dr;
                myFilterOn = columnFilterOn;
                myFilterBy = dcFilterBy;
                myFilterDT.ColumnChanged += new DataColumnChangeEventHandler(dt_ColumnChanged);
            }
            ApplyFilter();
         

        }

        void dt_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Column.ColumnName == myFilterBy)
            {
                ApplyFilter();
            }
        }

        private void ApplyFilter()
        {
            if (!myFilterRow.IsNull(myFilterBy))
            {
                string filter = myFilterOn + "=" + myFilterRow[myFilterBy].ToString(); ;
                DataView dv = (DataView)cboMulti.DataSource;
                dv.RowFilter = filter;
            }
        }


        public void RequiredAction()
        {
           
        }
    }
}
