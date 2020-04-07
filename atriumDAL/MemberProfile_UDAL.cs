using System;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;

namespace atriumDAL
{
    /// <summary>
    /// Class extends functionality of MemberProfileDAL 
    /// based on MemberProfile table 
    /// in lawmate_DEV database
    /// on 2014-02-12
    /// </summary>
    public partial class MemberProfileDAL : atDAL.ObjectDAL
    {

        public MemberManagement.WorkloadDataTable LoadTribunalMemberWorkload()
        {

            DataTable dt = myDALManager.ExecuteDataset("TribunalMemberWorkloadSelectAll").Tables[0];

            MemberManagement.WorkloadDataTable wldt = new MemberManagement.WorkloadDataTable();

            wldt.Merge(dt);
            wldt.RemotingFormat = myDALManager.RemotingFormat;

            return wldt;

        }

        //public MemberManagement.TribunalMemberAssignmentDataTable LoadTribunalMemberAssignment()
        //{

        //    DataTable dt = myDALManager.ExecuteDataset("TribunalMemberAssignment").Tables[0];

        //    MemberManagement.TribunalMemberAssignmentDataTable wlas = new MemberManagement.TribunalMemberAssignmentDataTable();

        //    wlas.Merge(dt);
        //    wlas.RemotingFormat = myDALManager.RemotingFormat;

        //    return wlas;

        //}

        public MemberManagement.OfficeSCListDataTable LoadOfficeSCList()
        {

            DataTable dt = myDALManager.ExecuteDataset("OfficeSCList").Tables[0];

            MemberManagement.OfficeSCListDataTable oscl = new MemberManagement.OfficeSCListDataTable();

            oscl.Merge(dt);
            oscl.RemotingFormat = myDALManager.RemotingFormat;

            return oscl;

        }

        public MemberManagement.MemberListAssignmentFilterDataTable LoadMemberListAssignmentFilter()
        {

            DataTable dt = myDALManager.ExecuteDataset("MemberListAssignmentFilter").Tables[0];

            MemberManagement.MemberListAssignmentFilterDataTable mlaf = new MemberManagement.MemberListAssignmentFilterDataTable();

            mlaf.Merge(dt);
            mlaf.RemotingFormat = myDALManager.RemotingFormat;

            return mlaf;

        }

        public MemberManagement.FileFlagDataTable LoadFileFlagVC()
        {

            DataTable dt = myDALManager.ExecuteDataset("FileFlagVC").Tables[0];

            MemberManagement.FileFlagDataTable ffdt = new MemberManagement.FileFlagDataTable();

            ffdt.Merge(dt);
            ffdt.RemotingFormat = myDALManager.RemotingFormat;

            return ffdt;

        }
    }
}
