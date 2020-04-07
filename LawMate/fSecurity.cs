using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawMate
{
    public partial class fSecurity : Form
    {
        atSecurity.SecurityManager mySM;
        lmDatasets.SecurityDB.secUserRow sur;
        lmDatasets.officeDB.OfficerRow myOr;
        bool secUserExistsWithoutSQLAccount = false;
        bool isNew = false;

        public fSecurity()
        {
            InitializeComponent();
        }

        public void Init(atSecurity.SecurityManager sm, lmDatasets.officeDB.OfficerRow or)
        {
            mySM = sm;
            myOr = or;

            secUserBindingSource.DataSource = mySM.DB;
            secUserBindingSource.DataMember = "secUser"; ;

            if (!or.IsUserNameNull())
                sur = mySM.GetsecUser().Load(or.UserName);
            else
                sur = null;

            if (sur == null)
            {
                isNew = true;
                sur = mySM.DB.secUser.NewsecUserRow();
                if (!or.IsUserNameNull())
                    sur.UserName = or.UserName;

                mySM.DB.secUser.AddsecUserRow(sur);
                //mySM.GetsecMembership().Add(sur);
                btnDeleteOfficerAccount.Enabled = false;
            }
            else
            {
                bool NotEnabled = true;
                if (sur.AuthType == 0)
                {
                    bool SQLAccountExists = mySM.GetsecUser().DoesSQLUserExist(sur.UserName);
                    if (!SQLAccountExists)
                    {
                        secUserExistsWithoutSQLAccount = true;
                        NotEnabled = false;
                    }
                }

                if (NotEnabled)
                {
                    isNew = false;
                    userNameEditBox.Enabled = false;
                    uiRadioButton1.Enabled = false;
                    uiRadioButton2.Enabled = false;
                }
                else
                {
                    //handle out of sync issue with atrium and sql accounts
                    MessageBox.Show("We're sorry, but something's gone wrong. It seems this user has an Atrium security account, but does not have a SQL account. Please rectify this immediately.");
                }
            }


            mySM.GetsecGroup().Load();
            mySM.GetsecMembership().LoadByUserId(sur.UserId);

            secMembershipGridEX.DropDowns["ddGroup"].SetDataBinding(mySM.DB.secGroup, "");
            secUserBindingSource.Filter = "UserId=" + sur.UserId;
        }
        private void fSecurity_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {

                secUserBindingSource.EndEdit();

                secMembershipGridEX.UpdateData();
                secMembershipBindingSource.EndEdit();

                atLogic.BusinessProcess bp = mySM.GetBP();
                bp.AddForUpdate(mySM.GetsecUser());
                bp.AddForUpdate(mySM.GetsecMembership());


                if (sur.AuthType == 0)
                {
                    if (isNew || secUserExistsWithoutSQLAccount)
                        mySM.GetsecUser().CreateSQLAccount(sur, passwordEditBox.Text);
                    else
                        mySM.GetsecUser().ChangeSQLPassword(sur, passwordEditBox.Text);
                }
                bp.Update();
                myOr.UserName = sur.UserName;

                this.Close();
            }
            catch (Exception x)
            {

                UIHelper.HandleUIException(x);

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            mySM.DB.RejectChanges();
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            mySM.GetsecMembership().Add(sur);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (sur != null)
                {
                    string user = sur.UserName;
                    int authType = sur.AuthType;
                    sur.Delete();

                    //TODO: check trans
                    atLogic.BusinessProcess bp = mySM.GetBP();

                    //  bp.AddForUpdate(mySM.GetsecFileRule());
                    bp.AddForUpdate(mySM.GetsecMembership());
                    bp.AddForUpdate(mySM.GetsecUser());

                    if (authType == 0 )
                    {
                        mySM.GetsecUser().DeleteSQLAccount(user);
                    }
                    bp.Update();
                    myOr.UserName = 'u' + myOr.OfficerId.ToString();
                    this.Close();
                }
            }
            catch (Exception x)
            {

                UIHelper.HandleUIException(x);
            }
        }
    }
}
