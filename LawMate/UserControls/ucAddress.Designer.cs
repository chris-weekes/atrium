 namespace LawMate.UserControls
{
    partial class ucAddress
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                address1EditBox.DataBindings.Clear();
                address2EditBox.DataBindings.Clear();
                address3EditBox.DataBindings.Clear();
                postalCodeEditBox.DataBindings.Clear();
                provinceCodeComboBox.DataBindings.Clear();
                countryCodeComboBox.DataBindings.Clear();

                errorProvider2.DataSource = null;
                FM = null;
                this.countryCodeComboBox.ASelectedValueChanged -= new System.EventHandler(this.countryCodeComboBox_SelectedValueChanged);
                this.provinceCodeComboBox.ASelectedValueChanged -= new System.EventHandler(this.provinceCodeComboBox_SelectedValueChanged);

                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label countryCodeLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucAddress));
            System.Windows.Forms.Label address1Label;
            System.Windows.Forms.Label address2Label;
            System.Windows.Forms.Label address3Label;
            System.Windows.Forms.Label cityLabel;
            this.provinceCodeLabel = new System.Windows.Forms.Label();
            this.postalCodeLabel = new System.Windows.Forms.Label();
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.uiCity = new Janus.Windows.EditControls.UIComboBox();
            this.address1EditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.address2EditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.address3EditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.postalCodeEditBox = new Janus.Windows.GridEX.EditControls.MaskedEditBox();
            this.provinceCodeComboBox = new LawMate.UserControls.ucMultiDropDown();
            this.countryCodeComboBox = new LawMate.UserControls.ucMultiDropDown();
            countryCodeLabel = new System.Windows.Forms.Label();
            address1Label = new System.Windows.Forms.Label();
            address2Label = new System.Windows.Forms.Label();
            address3Label = new System.Windows.Forms.Label();
            cityLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // countryCodeLabel
            // 
            resources.ApplyResources(countryCodeLabel, "countryCodeLabel");
            countryCodeLabel.Name = "countryCodeLabel";
            // 
            // address1Label
            // 
            resources.ApplyResources(address1Label, "address1Label");
            address1Label.Name = "address1Label";
            // 
            // address2Label
            // 
            resources.ApplyResources(address2Label, "address2Label");
            address2Label.Name = "address2Label";
            // 
            // address3Label
            // 
            resources.ApplyResources(address3Label, "address3Label");
            address3Label.Name = "address3Label";
            // 
            // cityLabel
            // 
            resources.ApplyResources(cityLabel, "cityLabel");
            cityLabel.Name = "cityLabel";
            // 
            // provinceCodeLabel
            // 
            resources.ApplyResources(this.provinceCodeLabel, "provinceCodeLabel");
            this.provinceCodeLabel.Name = "provinceCodeLabel";
            // 
            // postalCodeLabel
            // 
            resources.ApplyResources(this.postalCodeLabel, "postalCodeLabel");
            this.postalCodeLabel.Name = "postalCodeLabel";
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // uiCity
            // 
            resources.ApplyResources(this.uiCity, "uiCity");
            this.uiCity.Name = "uiCity";
            this.uiCity.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.uiCity.TextChanged += new System.EventHandler(this.address1EditBox_TextChanged);
            // 
            // address1EditBox
            // 
            resources.ApplyResources(this.address1EditBox, "address1EditBox");
            this.address1EditBox.Name = "address1EditBox";
            this.address1EditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.address1EditBox.TextChanged += new System.EventHandler(this.address1EditBox_TextChanged);
            // 
            // address2EditBox
            // 
            resources.ApplyResources(this.address2EditBox, "address2EditBox");
            this.address2EditBox.Name = "address2EditBox";
            this.address2EditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // address3EditBox
            // 
            resources.ApplyResources(this.address3EditBox, "address3EditBox");
            this.address3EditBox.Name = "address3EditBox";
            this.address3EditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // postalCodeEditBox
            // 
            resources.ApplyResources(this.postalCodeEditBox, "postalCodeEditBox");
            this.postalCodeEditBox.Mask = "L0L 0L0";
            this.postalCodeEditBox.Name = "postalCodeEditBox";
            this.postalCodeEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.postalCodeEditBox.TextChanged += new System.EventHandler(this.address1EditBox_TextChanged);
            // 
            // provinceCodeComboBox
            // 
            this.provinceCodeComboBox.BackColor = System.Drawing.Color.Transparent;
            this.provinceCodeComboBox.Column1 = "ProvinceCode";
            resources.ApplyResources(this.provinceCodeComboBox, "provinceCodeComboBox");
            this.provinceCodeComboBox.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
            this.provinceCodeComboBox.DataSource = null;
            this.provinceCodeComboBox.DDColumn1Visible = true;
            this.provinceCodeComboBox.DropDownColumn1Width = 100;
            this.provinceCodeComboBox.DropDownColumn2Width = 300;
            this.provinceCodeComboBox.Name = "provinceCodeComboBox";
            this.provinceCodeComboBox.ReadOnly = false;
            this.provinceCodeComboBox.ReqColor = System.Drawing.SystemColors.Window;
            this.provinceCodeComboBox.SelectedValue = null;
            this.provinceCodeComboBox.ValueMember = "ProvinceCode";
            this.provinceCodeComboBox.ASelectedValueChanged += new System.EventHandler(this.provinceCodeComboBox_SelectedValueChanged);
            // 
            // countryCodeComboBox
            // 
            this.countryCodeComboBox.BackColor = System.Drawing.Color.Transparent;
            this.countryCodeComboBox.Column1 = "CountryCode";
            resources.ApplyResources(this.countryCodeComboBox, "countryCodeComboBox");
            this.countryCodeComboBox.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
            this.countryCodeComboBox.DataSource = null;
            this.countryCodeComboBox.DDColumn1Visible = true;
            this.countryCodeComboBox.DropDownColumn1Width = 100;
            this.countryCodeComboBox.DropDownColumn2Width = 300;
            this.countryCodeComboBox.Name = "countryCodeComboBox";
            this.countryCodeComboBox.ReadOnly = false;
            this.countryCodeComboBox.ReqColor = System.Drawing.SystemColors.Window;
            this.countryCodeComboBox.SelectedValue = null;
            this.countryCodeComboBox.ValueMember = "CountryCode";
            this.countryCodeComboBox.ASelectedValueChanged += new System.EventHandler(this.countryCodeComboBox_SelectedValueChanged);
            // 
            // ucAddress
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.postalCodeEditBox);
            this.Controls.Add(this.address3EditBox);
            this.Controls.Add(this.address2EditBox);
            this.Controls.Add(this.address1EditBox);
            this.Controls.Add(this.uiCity);
            this.Controls.Add(this.provinceCodeComboBox);
            this.Controls.Add(this.countryCodeComboBox);
            this.Controls.Add(countryCodeLabel);
            this.Controls.Add(this.provinceCodeLabel);
            this.Controls.Add(address1Label);
            this.Controls.Add(address2Label);
            this.Controls.Add(address3Label);
            this.Controls.Add(cityLabel);
            this.Controls.Add(this.postalCodeLabel);
            resources.ApplyResources(this, "$this");
            this.Name = "ucAddress";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider2;
        private lmDatasets.atriumDB atriumDB;
        private ucMultiDropDown provinceCodeComboBox;
        private ucMultiDropDown countryCodeComboBox;
        private Janus.Windows.EditControls.UIComboBox uiCity;
        private Janus.Windows.GridEX.EditControls.EditBox address3EditBox;
        private Janus.Windows.GridEX.EditControls.EditBox address2EditBox;
        private Janus.Windows.GridEX.EditControls.EditBox address1EditBox;
        private System.Windows.Forms.Label provinceCodeLabel;
        private System.Windows.Forms.Label postalCodeLabel;
        private Janus.Windows.GridEX.EditControls.MaskedEditBox postalCodeEditBox;
    }
}
