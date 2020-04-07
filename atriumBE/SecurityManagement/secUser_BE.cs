using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atSecurity
{
    /// <summary>
    /// 
    /// </summary>
    public class secUserBE : atLogic.ObjectBE
    {
        SecurityManager myBEMng;
        SecurityDB.secUserDataTable mysecUserDT;

        internal secUserBE(SecurityManager pBEMng)
            : base(pBEMng, pBEMng.DB.secUser)
        {
            myBEMng = pBEMng;

            mysecUserDT = (SecurityDB.secUserDataTable)myDT;
            if (!myBEMng.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myBEMng.DALMngr.GetsecUser();

        }
        public atriumDAL.secUserDAL myDAL
        {
            get
            {
                return (atriumDAL.secUserDAL)myODAL;
            }
        }

        public SecurityDB.secUserRow Load(int UserId)
        {
            if (myBEMng.AtMng.AppMan.UseService)
            {
                Fill(myBEMng.AtMng.AppMan.AtriumX().secUserLoadByUserid(UserId, myBEMng.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.Load(UserId));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.Load(UserId));
                }
            }
            return mysecUserDT.FindByUserId(UserId);
        }

        public void Save()
        {
            try
            {
                BusinessProcess bp = myBEMng.GetBP();
                bp.AddForUpdate(this);
                bp.Update();
                //this.Update();
                //myBEMng.Commit();
                //this.mysecUserDT.AcceptChanges();
            }
            catch (Exception ex)
            {
                this.mysecUserDT.RejectChanges();
                throw ex;
            }
        }


        public SecurityDB.secUserRow Load(string UserName)
        {
            if (myBEMng.AtMng.AppMan.UseService)
            {
                Fill(myBEMng.AtMng.AppMan.AtriumX().secUserLoadByUserName(UserName, myBEMng.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.Load(UserName));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.Load(UserName));
                }
            }
            if (mysecUserDT.Select("UserName='" + UserName + "'").Length == 1)
            {
                return (SecurityDB.secUserRow)mysecUserDT.Select("UserName='" + UserName + "'")[0];
            }
            else
                return null;


        }


        public static string EncryptPassword(string password)
        {
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            System.Text.ASCIIEncoding str = new System.Text.ASCIIEncoding();
            string sPassword = "";
            string sHex = "";
            byte[] passHex;
            passHex = md5.ComputeHash(str.GetBytes(password));

            for (int i = 0; i < passHex.Length; i++)
            {
                sHex = Convert.ToString(passHex[i], 16).ToUpper();

                if (sHex.Length == 1)
                    sHex = "0" + sHex;

                sPassword += sHex;
            }
            return sPassword;
        }

        protected override void AfterAdd(DataRow ddr)
        {
            SecurityDB.secUserRow sur = (SecurityDB.secUserRow)ddr;
            sur.UserId = myBEMng.PKIDGet("secGroup", 1);
            sur.Active = true;
            sur.LockedOut = false;
            sur.Password = "obsolete";
            sur.AuthType = 0;

            myBEMng.GetsecMembership();
            SecurityDB.secMembershipRow mem = myBEMng.DB.secMembership.NewsecMembershipRow();
            myBEMng.DB.secMembership.AddsecMembershipRow(mem);

            mem.BeginEdit();
            mem.UserId = sur.UserId;
            mem.GroupId = 2;  // everyone
            mem.EndEdit();


        }

        protected override void AfterChange(DataColumn dc, DataRow dr)
        {
            SecurityDB.secUserRow sur = (SecurityDB.secUserRow)dr;
            switch (dc.ColumnName)
            {
                //case "Password":
                //    sur.Password = EncryptPassword(sur.Password);

                //    break;
                default:
                    break;
            }
        }

        protected override void BeforeChange(DataColumn dc, DataRow ddr)
        {

            SecurityDB.secUserRow sur = (SecurityDB.secUserRow)ddr;
            switch (dc.ColumnName)
            {
                //case "Password":
                //    if (sur.Password.Length <=7)
                //        throw new PasswordLengthException();
                //        //mySecMng.RaiseError(ClasMateEnum.AppErrorCodes.OffcrPwdLength);
                //    else
                //        //                        e.ProposedValue = EncryptPassword(e.ProposedValue.ToString()).ToString();

                //        break;
                case "UserName":
                    if (sur.AuthType == 0 && sur.UserName.Contains("."))
                        throw new AtriumException("SQL account cannot contain a '.'");
                    break;
            }
        }

       
        public void CreateSQLAccount(SecurityDB.secUserRow sur, string newPassword)
        {
            try
            {
                string sql = "";
                //create login
                if (!DoesSQLLoginExist(sur.UserName))
                {
                    sql += "CREATE LOGIN [" + sur.UserName + "] WITH PASSWORD ='" + newPassword + "';";
                }
                else
                {
                    if (newPassword.Length > 0)
                        sql += "ALTER LOGIN " + sur.UserName + " WITH PASSWORD ='" + newPassword + "';";
                }


          

                if (DoesSQLUserExist(sur.UserName))
                {

                    //drop group membership
                    sql += "exec sp_droprolemember 'LawmateInternal', '" + sur.UserName + "'" + ";";

                    //drop user
                    sql += "DROP USER [" + sur.UserName + "] ;";
                }

                sql += "CREATE USER [" + sur.UserName + "];";

                //make user member of lawmateinternal
                sql += "exec sp_addrolemember 'LawmateInternal', '" + sur.UserName + "'" + ";";

                if (sql.Length > 0)
                    myBEMng.AtMng.AppMan.ExecuteNonQuery(sql);
            }
            catch (Exception x)
            {
                throw new AtriumException("SQL user and login not created", x);
            }

        }
        public bool DoesSQLLoginExist(string userName)
        {
            try
            {
                //string dbname = myDAL.DAL.SqlCon.Database;
                //string sql = "USE " + dbname + "; ";
                string sql = "";

                sql += "select name from master.sys.server_principals where name ='" + userName + "'";

                string rValue = (string)myBEMng.AtMng.AppMan.ExecuteScalarSQL(sql);
                if (rValue != null)
                    return true;

                return false;
            }
            catch (Exception x)
            {
                throw new AtriumException("We're sorry, but something's gone wrong. The current user cannot check SQL accounts. Please contact an Atrium Administrator.", x);
            }
        }
        public bool DoesSQLUserExist(string userName)
        {
            try
            {
                //string dbname = myDAL.DAL.SqlCon.Database;
                //string sql = "USE " + dbname + "; ";
                string sql = "";

                sql += "select name from sys.database_principals where name ='" + userName + "'";

                string rValue = (string)myBEMng.AtMng.AppMan.ExecuteScalarSQL(sql);
                if (rValue != null)
                    return true;

                return false;
            }
            catch (Exception x)
            {
                throw new AtriumException("We're sorry, but something's gone wrong. The current user cannot check SQL accounts. Please contact an Atrium Administrator.", x);
            }
        }

        public void DeleteSQLAccount(string userName)
        {
            try
            {

                //string dbname = myDAL.DAL.SqlCon.Database;  //JL: where to find value?!?!
                //string sql = "USE " + dbname + "; ";
                string sql = "";


                if(DoesSQLUserExist(userName))
                { 
                //drop group membership
                sql += "exec sp_droprolemember 'LawmateInternal', '" + userName + "'" + ";";

                //drop user
                sql += "DROP USER [" + userName + "] ;";
            }
                if (DoesSQLLoginExist(userName))
                {
                    //drop login
                    sql += "DROP LOGIN [" + userName + "];";
                }

                myBEMng.AtMng.AppMan.ExecuteNonQuery(sql);
            }
            catch (Exception x)
            {
                throw new AtriumException("SQL user and login not deleted", x);
            }

        }
        public void ChangeSQLPassword(SecurityDB.secUserRow sur, string newPassword, string oldPassword)
        {
            try
            {
                myBEMng.AtMng.AppMan.ExecuteNonQuery("ALTER LOGIN " + sur.UserName + " WITH PASSWORD ='" + newPassword + "' OLD_PASSWORD='" + oldPassword + "'");
                if(myBEMng.AtMng.AppMan.UseService)
                {
                    myBEMng.AtMng.AppMan.myPwd = newPassword;

                }
                else
                {
                    myDAL.DAL.CreateCon(sur.UserName, newPassword);
                }
            }
            catch (Exception x)
            {
                throw new AtriumException("Make sure your old password is correct and that your new password meets the password rules.", x);
            }

        }
        public void ChangeSQLPassword(SecurityDB.secUserRow sur, string newPassword)
        {
            try
            {
                if (newPassword.Length > 0)
                    myBEMng.AtMng.AppMan.ExecuteNonQuery("ALTER LOGIN " + sur.UserName + " WITH PASSWORD ='" + newPassword + "'");
            }
            catch (Exception x)
            {
                throw new AtriumException("Password not changed", x);
            }

        }

        public SecurityDB.secUserRow GetSecUserForOfficer(officeDB.OfficerRow or)
        {
            SecurityDB.secUserRow sur;
            if (!or.IsUserNameNull())
            {
                sur = Load(or.UserName);
                if (sur == null)
                    throw new AtriumException("Officer must have an account");
            }
            else
                throw new AtriumException("Officer must have a user name");
            return sur;
        }

    }
}

