using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atSecurity
{
	/// <summary>
	/// 
	/// </summary>
	public class secMembershipBE:atLogic.ObjectBE
	{
		SecurityManager myBEMng;
		SecurityDB.secMembershipDataTable mysecMembershipDT;
		
		internal secMembershipBE(SecurityManager pBEMng):base(pBEMng,pBEMng.DB.secMembership)
		{
			myBEMng=pBEMng;
			mysecMembershipDT=(SecurityDB.secMembershipDataTable)myDT;
            if (!myBEMng.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myBEMng.DALMngr.GetsecMembership();

        }
        public atriumDAL.secMembershipDAL myDAL
        {
            get
            {
                return (atriumDAL.secMembershipDAL)myODAL;
            }
        }


		


	



		public void LoadByUserId(int UserId)
		{
            if (myBEMng.AtMng.AppMan.UseService)
            {
                Fill(myBEMng.AtMng.AppMan.AtriumX().secMembershipLoadByUserId(UserId, myBEMng.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.LoadByUserId(UserId));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.LoadByUserId(UserId));
                }
            }
		}

        protected override void BeforeUpdate(DataRow ddr)
        {
            SecurityDB.secMembershipRow mem = (SecurityDB.secMembershipRow)ddr;
            //make sure that only SYSADMIN users add people to the Sysadmin group
            if (mem.secGroupRow.GroupName.ToUpper() == "SYSADMIN")
            {
                if (myBEMng.CanExecute(0, atSecurity.SecurityManager.Features.SysAdmin) == atSecurity.SecurityManager.ExPermissions.No)
                    throw new Exception("You do not have permission to modify the sysadmin group.");

            }
        }

		protected override void AfterAdd(DataRow ddr)
		{
			SecurityDB.secMembershipRow mem=(SecurityDB.secMembershipRow)ddr;
			mem.MembershipId=myBEMng.PKIDGet("secMembership",1);
           // mem.GroupId = 2;  //everyone don't set it as it breaks the admin module
		}


	}
}

