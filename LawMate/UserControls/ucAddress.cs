using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using lmDatasets;
using System.Text.RegularExpressions;

 namespace LawMate.UserControls
{
    public partial class ucAddress : UserControl, IRequiredCtl 
    {
        atriumBE.FileManager myFM;

        bool loading = false;

        public atriumBE.FileManager FM
        {
            get { return myFM; }
            set 
            {
                myFM = value;
                if (myFM != null)
                {
                    loading = true;
                    countryCodeComboBox.SetDataBinding(FM.Codes("Country"), "");
                    provinceCodeComboBox.SetDataBinding(FM.Codes("Province"), "");
                    loading = false;
                }
            }
        }

        public ucAddress()
        {
            InitializeComponent();
            countryCodeComboBox.TextChanged += new EventHandler(address1EditBox_TextChanged);
            provinceCodeComboBox.TextChanged += new EventHandler(address1EditBox_TextChanged);
            postalCodeEditBox.Validated += new EventHandler(postalCodeEditBox_Validating);
        }
        
        public object DataSource
        {
            set 
            {
                loading = true;
                uiCity.DataBindings.Clear();
                uiCity.DataBindings.Add("Text", value, "City");
                address1EditBox.DataBindings.Clear();
                address1EditBox.DataBindings.Add("Text", value, "Address1");
                address2EditBox.DataBindings.Clear();
                address2EditBox.DataBindings.Add("Text", value, "Address2");
                address3EditBox.DataBindings.Clear();
                address3EditBox.DataBindings.Add("Text", value, "Address3");
                postalCodeEditBox.DataBindings.Clear();
                postalCodeEditBox.DataBindings.Add("Text", value, "PostalCode");
                countryCodeComboBox.DataBindings.Clear();
                countryCodeComboBox.DataBindings.Add("SelectedValue", value, "CountryCode");
                provinceCodeComboBox.DataBindings.Clear();
                provinceCodeComboBox.DataBindings.Add("SelectedValue", value, "ProvinceCode");

                errorProvider2.DataSource = value;
                loading = false;
            }
        }
        
        private int columnOffset=0;
        public int ColumnTwoLeftPositionOffset
        {
            get { return columnOffset; }
            set 
            {
                int col1=91;
                int col2=206;
                int col3=289;
                address1EditBox.Left = col1 + value;
                address2EditBox.Left = col1 + value;
                address3EditBox.Left = col1 + value;
                uiCity.Left = col1 + value;
                countryCodeComboBox.Left = col1 + value;
                provinceCodeLabel.Left = col2 + value;
                postalCodeLabel.Left = col2 + value;
                provinceCodeComboBox.Left = col3 + value;
                postalCodeEditBox.Left = col3 + value;
                columnOffset = value;
                this.Width = col3 + 75;
            }
        }

        private bool isReadOnly=false;
        public bool IsReadOnly
        {
            get { return isReadOnly; }
            set
            {
                address1EditBox.ReadOnly = value;
                address2EditBox.ReadOnly = value;
                address3EditBox.ReadOnly = value;
                uiCity.ReadOnly = value;
                countryCodeComboBox.ReadOnly = value;
                provinceCodeComboBox.ReadOnly=value;
                postalCodeEditBox.ReadOnly = value;
                isReadOnly = value;

                Color bgColor;
                if (isReadOnly)
                    bgColor = SystemColors.Control;
                else
                    bgColor = SystemColors.Window;

                address1EditBox.BackColor = bgColor;
                address2EditBox.BackColor = bgColor;
                address3EditBox.BackColor = bgColor;
                uiCity.BackColor = bgColor;
                countryCodeComboBox.BackColor = bgColor;
                provinceCodeComboBox.BackColor = bgColor;
                postalCodeEditBox.BackColor = bgColor;
            }
        }

        private void countryCodeComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            
            if (countryCodeComboBox.SelectedValue != null)
            {
                atLogic.WhereClause wc = new atLogic.WhereClause();
                DataTable dtC=FM.Codes("Province");
                wc.Add("CountryCode", "=", countryCodeComboBox.SelectedValue.ToString());
                DataView dvC=new DataView(dtC,wc.Filter(),"", DataViewRowState.CurrentRows);
                provinceCodeComboBox.SetDataBinding(dvC, "");
            }

            //provinceCodeComboBox.SetDataBinding(new DataView(FM.Codes("Province"), "CountryCode='" + countryCodeComboBox.SelectedValue + "'", "ProvinceCode", DataViewRowState.CurrentRows), "");

            if (countryCodeComboBox.Text == "Canada")
            {
                this.postalCodeEditBox.CharacterCasing = CharacterCasing.Upper;
                this.postalCodeEditBox.Mask = "L0L 0L0";
            }
            else if (countryCodeComboBox.Text== "United States of America")
            {
                this.postalCodeEditBox.CharacterCasing = CharacterCasing.Upper;
                this.postalCodeEditBox.Mask = "00000";
            }
            else
            {
                this.postalCodeEditBox.CharacterCasing = CharacterCasing.Normal;
                this.postalCodeEditBox.Mask = "";
                this.ReqColor = Color.White;
            }
        }

        private void provinceCodeComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            uiCity.DisplayMember="City";
            uiCity.ValueMember="City";

            object val = uiCity.Text;
            DataTable dt = FM.Codes("vCity");
            atLogic.WhereClause whereCl = new atLogic.WhereClause();
            if (provinceCodeComboBox.SelectedValue != null && provinceCodeComboBox.SelectedValue.ToString() != "")
            {
                whereCl.Add("ProvinceCode", "=", provinceCodeComboBox.SelectedValue.ToString());
                // DataTable dt = FM.AtMng.GetGeneralRec("City", whereCl);
                uiCity.DataSource = new DataView(dt, whereCl.Filter(), "City", DataViewRowState.CurrentRows);
            }
            else
                uiCity.DataSource = null;

            uiCity.Text = val.ToString();
        }

        private void postalCodeEditBox_Validating(object sender, EventArgs e)
        {
            postalCodeEditBox.Text = postalCodeEditBox.Text.ToUpper();
        }

        private void address1EditBox_TextChanged(object sender, EventArgs e)
        {
            OnTextChanged(new EventArgs());
        }

        #region IRequiredCtl Members

            public Color ReqColor
            {
                get
                {
                    return address1EditBox.BackColor;
                }
                set
                {
                    address1EditBox.BackColor = value;
                    uiCity.BackColor = value;
                    provinceCodeComboBox.ucMcc.BackColor = value;
                    countryCodeComboBox.ucMcc.BackColor = value;
                    postalCodeEditBox.BackColor = value;
                }
            }

            public bool IsPopulated
            {
                get 
                {
                    if (countryCodeComboBox.Text == "Canada" || countryCodeComboBox.Text == "United States of America")
                    {
                        if (address1EditBox.Text != "" && uiCity.Text != "" && provinceCodeComboBox.Text != "" && postalCodeEditBox.Text != "")
                            return true;
                        else
                            return false;
                    }
                    else
                    {
                        if (address1EditBox.Text != "" && uiCity.Text != "" && countryCodeComboBox.Text != "" )
                            return true;
                        else
                            return false;
                    }
                }
            }

        #endregion



            public void RequiredAction()
            {
                
            }
    }
}