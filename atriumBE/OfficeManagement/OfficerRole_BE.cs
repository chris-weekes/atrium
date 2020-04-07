using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class OfficerRoleBE:atLogic.ObjectBE
	{
		OfficeManager myA;
		officeDB.OfficerRoleDataTable myOfficerRoleDT;

		
		internal OfficerRoleBE(OfficeManager pBEMng):base(pBEMng,pBEMng.DB.OfficerRole)
		{
			myA=pBEMng;
            myOfficerRoleDT = (officeDB.OfficerRoleDataTable)myDT;
            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetOfficerRole();
        }
        public atriumDAL.OfficerRoleDAL myDAL
        {
            get
            {
                return (atriumDAL.OfficerRoleDAL)myODAL;
            }
        }


        protected override void BeforeChange(DataColumn dc, DataRow ddr)
        {
            officeDB.OfficerRoleRow dr = (officeDB.OfficerRoleRow)ddr;
            switch (dc.ColumnName)
            {
                case "RoleCode" :
                    if(!dr.RoleCode.StartsWith("G"))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dr.Table.TableName, "Role Code");
                    break;
            }
        }
       


		public void LoadByOfficerID(int OfficerID)
		{
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().OfficerRoleLoad(OfficerID, myA.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.LoadByOfficerID(OfficerID));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.LoadByOfficerID(OfficerID));
                }
            }
		}



	


        protected override void AfterAdd(DataRow row)
        {
            officeDB.OfficerRoleRow dr = (officeDB.OfficerRoleRow)row;
            string ObjectName = this.myDT.TableName;

            dr.OfficerRoleID = this.myA.AtMng.PKIDGet(ObjectName, 1);
            dr.Mod = 1;
            dr.ModResult = 0;
            
        }

	}
}

