using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class MemberProfileBE:atLogic.ObjectBE
	{
        OfficeManager myA;
        officeDB.MemberProfileDataTable myMemberProfileDT;


        internal MemberProfileBE(OfficeManager pBEMng)
            : base(pBEMng, pBEMng.DB.MemberProfile)
		{
			myA=pBEMng;
            myMemberProfileDT = (officeDB.MemberProfileDataTable)myDT;
            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetMemberProfile();
	
		}

        public atriumDAL.MemberProfileDAL myDAL
        {
            get
            {
                return (atriumDAL.MemberProfileDAL)myODAL;
            }
        }

        public officeDB.MemberProfileRow Load(int OfficerId)
		{
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().MemberProfileLoad(OfficerId, myA.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.Load(OfficerId));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.Load(OfficerId));
                }
            }
			return myMemberProfileDT.FindByOfficerId(OfficerId);
		}



        protected override void AfterAdd(DataRow row)
        {
            officeDB.MemberProfileRow dr = (officeDB.MemberProfileRow)row;
            string ObjectName = this.myMemberProfileDT.TableName;

            dr.CanHearEI = false;
            dr.CanHearIS = false;
            dr.CanHearEng = false;
            dr.CanHearFre = false;

            dr.TrainedCharter = false;
            dr.TrainedCPP = false;
            dr.TrainedEI = false;
            dr.TrainedOAS = false;
        }

	}
}

