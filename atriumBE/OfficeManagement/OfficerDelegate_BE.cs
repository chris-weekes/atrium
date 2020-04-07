using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class OfficerDelegateBE:atLogic.ObjectBE
	{
		OfficeManager myA;
		officeDB.OfficerDelegateDataTable myOfficerDelegateDT;

		
		internal OfficerDelegateBE(OfficeManager pBEMng):base(pBEMng,pBEMng.DB.OfficerDelegate)
		{
			myA=pBEMng;
			myOfficerDelegateDT=(officeDB.OfficerDelegateDataTable)myDT;
            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetOfficerDelegate();
        }
        public atriumDAL.OfficerDelegateDAL myDAL
        {
            get
            {
                return (atriumDAL.OfficerDelegateDAL)myODAL;
            }
        }


        public override bool CanAdd(DataRow parent)
        {
            return base.CanAdd(parent);
        }
        public override bool CanEdit(DataRow dr)
        {
            return base.CanEdit(dr);
        }

		


		public void LoadByOfficerId(int OfficerId)
		{
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().OfficerDelegateLoadByOfficerId(OfficerId, myA.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.LoadByOfficerId(OfficerId));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.LoadByOfficerId(OfficerId));
                }
            }
		}



		public void LoadByDelegateToId(int DelegateToId)
		{
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().OfficerDelegateLoadByDelegateId(DelegateToId, myA.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.LoadByDelegateToId(DelegateToId));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.LoadByDelegateToId(DelegateToId));
                }
            }
		}

        protected override void AfterAdd(DataRow row)
        {
            officeDB.OfficerDelegateRow dr = (officeDB.OfficerDelegateRow)row;
            string ObjectName = this.myDT.TableName;

            dr.Id = this.myA.AtMng.PKIDGet(ObjectName, 1);
            dr.WorkAs = false;
            dr.AccessLevel = 0;
        }
        protected override void BeforeUpdate(DataRow dr)
        {
            officeDB.OfficerDelegateRow odr= ( officeDB.OfficerDelegateRow) dr;

        }

        protected override void AfterUpdate(DataRow dr)
        {
            //need to commit efore doing security op
           // myA.AtMng.AppMan.Commit();

            //TODO:  this code probably shouldn't be in afterupdate now that we have gone to a single web-call
            officeDB.OfficerDelegateRow odr = (officeDB.OfficerDelegateRow)dr;
            
            myLoadedDels.Remove(odr.DelegateToId);

            SetDelegateSecurity(odr);
 
        }
        public void SetDelegateSecurity(officeDB.OfficerDelegateRow odr)
        {
            if (odr.WorkAs )
            {
                officeDB.OfficerRow or = odr.OfficerRowByOfficerWorkAs;
                if (or == null)
                {
                    or = myA.AtMng.GetOfficeForOfficer(odr.DelegateToId).GetOfficer().Load(odr.DelegateToId);
                }
                SecurityDB.secUserRow sur = myA.AtMng.SecurityManager.GetsecUser().GetSecUserForOfficer(or);

                if(!odr.OfficerRow.IsMyFileIdNull())
                    myA.GetOfficer().AddUserFileRule(sur.UserId, myA.AtMng.GetFile(odr.OfficerRow.MyFileId).CurrentFile, (int)atSecurity.SpecialRules.DelegateFileRW);
            }
        }

        System.Collections.Generic.List<int> myLoadedDels = new System.Collections.Generic.List<int>();
        public officeDB.OfficerDelegateRow[] DelegatesForOfficer(int officerid)
        {
            if (!myLoadedDels.Contains(officerid))
            {
                LoadByDelegateToId(officerid);
                myLoadedDels.Add(officerid);
            }

            return (officeDB.OfficerDelegateRow[])myOfficerDelegateDT.Select("DelegateToId=" + officerid.ToString());
        }
	}
}

