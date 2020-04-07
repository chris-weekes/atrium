using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using lmDatasets;

namespace atriumBE
{
    public class MemberManager : atLogic.BEManager
    {

        atriumManager myatMng;
        FileManager myFM;

        public atriumManager AtMng
        {
            get { return myatMng; }
            set { myatMng = value; }
        }

        public MemberManagement DB
        {
            get
            {
                return (MemberManagement)MyDS;
            }
        }

        public atriumDAL.atriumDALManager DALMngr
        {
            get
            {
                return myatMng.DALMngr;
            }
        }

        internal MemberManager(atriumManager atMng)
            : base(atMng.AppMan)
        {
            Init(atMng);

            LoadOfficeSCList();
        }

        private void Init(atriumManager atMng)
        {
            base.DAL = atMng.DALMngr;
            myatMng = atMng;

            MyDS = new MemberManagement();
            MyDS.EnforceConstraints = false;

            FixTZDSIssue(MyDS);

            myFM = myatMng.GetFile();
        }

        TribunalMemberAssignmentBE myTribunalMemberAssignmentBE;
        public TribunalMemberAssignmentBE GetTribunalMemberAssignment()
        {
            if (myTribunalMemberAssignmentBE == null)
            {
                myTribunalMemberAssignmentBE = new TribunalMemberAssignmentBE(this);
            }

            return myTribunalMemberAssignmentBE;
        }

        //FileFlagBE myFileFlagBE;
        //public FileFlagBE GetFileFlag()
        //{
        //    if (myFileFlagBE == null)
        //    {
        //        myFileFlagBE = new FileFlagBE(myFM);
        //    }

        //    return myFileFlagBE;
        //}

        public static void FixTZDSIssue(DataSet myDS)
        {
            foreach (DataTable table in myDS.Tables)
            {
                foreach (DataColumn column in table.Columns)
                {
                    if (column.DataType == typeof(DateTime))
                    {
                        column.DateTimeMode = DataSetDateTime.Unspecified;
                    }
                }
            }
        }

        public MemberManagement.WorkloadDataTable LoadTribunalMemberWorkload()
        {
            try
            {
                return DALMngr.GetMemberProfile().LoadTribunalMemberWorkload();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public MemberManagement.WorkloadDataTable LoadTribunalMemberWorkByLevelProgram(int appealLevelId, int programId)
        {
            try
            {
                return DALMngr.GetMemberProfile().LoadTribunalMemberWorkload();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public MemberManagement.TribunalMemberAssignmentDataTable LoadTribunalMemberAssignment()
        {
            try
            {
                DB.TribunalMemberAssignment.Clear();
                DB.TribunalMemberAssignment.AcceptChanges();

                GetTribunalMemberAssignment().Load();
                CalcSC();
                DB.TribunalMemberAssignment.AcceptChanges();

                return DB.TribunalMemberAssignment;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public MemberManagement.FileFlagDataTable LoadFileFlagVC()
        {
            try
            {
                DB.FileFlag.Clear();
                DB.FileFlag.AcceptChanges();
                DB.FileFlag.Merge(DALMngr.GetMemberProfile().LoadFileFlagVC(), false, MissingSchemaAction.Ignore);
               // GetFileFlag().Load();
                DB.FileFlag.AcceptChanges();

                return DB.FileFlag;
                //return DALMngr.GetMemberProfile().LoadFileFlagVC();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        private void CalcSC()
        {
            foreach (MemberManagement.TribunalMemberAssignmentRow tmar in DB.TribunalMemberAssignment)
            {
                // set closest SC to appellant
                int officeId = 0;

                if (!tmar.IsLatitudeNull())
                    officeId = GetClosestSCC(tmar.Latitude,tmar.Longitude);

                if (officeId > 0)
                    tmar.OfficeId = officeId;
            }
        }

        public int GetClosestSCC(decimal latitude, decimal longitude)
        {
            double distanceCalculated = 0;
            double distanceShortest = 0;
            int officeId = 0;

            foreach (MemberManagement.OfficeSCListRow osclr in DB.OfficeSCList)
            {

                if (!osclr.IsLatitudeNull() && !osclr.IsLongitudeNull())
                {

                    distanceCalculated = myatMng.GetPostalCodeLocation().CalculateDistance((double)latitude, (double)longitude, (double)osclr.Latitude, (double)osclr.Longitude);
                    if (officeId == 0 && distanceCalculated >= 0) // first time around
                    {
                        officeId = osclr.OfficeId;
                        distanceShortest = distanceCalculated;
                    }
                    else if (distanceCalculated >= 0)
                    {
                        if (distanceCalculated < distanceShortest)
                        {
                            officeId = osclr.OfficeId;
                            distanceShortest = distanceCalculated;
                        }
                    }
                }
            }

            return officeId;
        }

        public MemberManagement.OfficeSCListDataTable LoadOfficeSCList()
        {
            try
            {
                DB.OfficeSCList.Clear();
                DB.OfficeSCList.AcceptChanges();

                DB.OfficeSCList.Merge(DALMngr.GetMemberProfile().LoadOfficeSCList(), false, MissingSchemaAction.Ignore);
               
                DB.OfficeSCList.AcceptChanges();

                return DB.OfficeSCList;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public MemberManagement.MemberListAssignmentFilterDataTable LoadMemberListAssignmentFilter()
        {
            try
            {
                return DALMngr.GetMemberProfile().LoadMemberListAssignmentFilter();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void CreateBatchRecord(List<DataRow> rowList)
        {
            foreach (DataRow dr in rowList)
            {
                MemberManagement.TribunalMemberAssignmentRow tmar = (MemberManagement.TribunalMemberAssignmentRow)dr;
                if (!tmar.IsTentativeMemberIdNull())
                {
                    tmar.ReadyToAssignDate = DateTime.Now;

                    lmDatasets.appDB.BatchRow br = (lmDatasets.appDB.BatchRow)AtMng.GetBatch().Add(null);
                    br.JobName = "CreateAC";
                    br.Parameters = String.Format("{0},{1},{2},{3},{4}", tmar.FileId, AtMng.GetSetting(AppIntSetting.AssignedVCAcId),DateTime.Today.ToString("yyyy-MM-dd"),"SSTDecision",tmar.SSTDecisionId);
                }
            }

            atLogic.BusinessProcess bp = AtMng.GetBP();
            bp.AddForUpdate(AtMng.GetBatch());
            bp.AddForUpdate(GetTribunalMemberAssignment());
            bp.Update();

        }
    }
}