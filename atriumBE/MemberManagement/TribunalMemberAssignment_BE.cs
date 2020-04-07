using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
    /// <summary>
    /// 
    /// </summary>
    public class TribunalMemberAssignmentBE : atLogic.ObjectBE
    {
        MemberManager myA;
        MemberManagement.TribunalMemberAssignmentDataTable myTribunalMemberAssignmentDT;


        internal TribunalMemberAssignmentBE(MemberManager pBEMng)
            : base(pBEMng, pBEMng.DB.TribunalMemberAssignment)
        {
            myA = pBEMng;
            myTribunalMemberAssignmentDT = (MemberManagement.TribunalMemberAssignmentDataTable)myDT;
            if (myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetTribunalMemberAssignment();

        }

        public atriumDAL.TribunalMemberAssignmentDAL myDAL
        {
            get
            {
                return (atriumDAL.TribunalMemberAssignmentDAL)myODAL;
            }
        }


        protected override void BeforeChange(DataColumn dc, DataRow dr)
        {
            MemberManagement.TribunalMemberAssignmentRow sdr = (MemberManagement.TribunalMemberAssignmentRow)dr;
           
        }

   


        protected override void AfterAdd(DataRow row)
        {
           

        }

        protected override void AfterChange(DataColumn dc, DataRow dr)
        {
            MemberManagement.TribunalMemberAssignmentRow sdr = (MemberManagement.TribunalMemberAssignmentRow)dr;
         
        }

       

        protected override void BeforeUpdate(DataRow dr)
        {
            MemberManagement.TribunalMemberAssignmentRow sdr = (MemberManagement.TribunalMemberAssignmentRow)dr;
         
        }

    
    }
}

