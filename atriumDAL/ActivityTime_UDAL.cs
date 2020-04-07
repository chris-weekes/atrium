using System;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;


namespace atriumDAL
{
    /// <summary>
    /// </summary>

    public partial class ActivityTimeDAL : atDAL.ObjectDAL
    {
        public atriumDB.ActivityTimeDataTable LoadByFileId(int fileId)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[ActivityTimeSelectByFileId]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FileId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters["@FileId"].Value = fileId;


            atriumDB.ActivityTimeDataTable dt = new atriumDB.ActivityTimeDataTable();
            Fill(dt);
            return dt;
        }


        public appDB.SRPClientDataTable LoadSRPClientByOfficerId(int SRPID, int officerId, DateTime startDate, DateTime endDate)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[SRPCLientByOfficerID]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SRPID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OfficerId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@startdate", System.Data.SqlDbType.SmallDateTime, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@enddate", System.Data.SqlDbType.SmallDateTime, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters["@SRPID"].Value = SRPID;
            this.sqlSelect.Parameters["@OfficerId"].Value = officerId;
            this.sqlSelect.Parameters["@startdate"].Value = startDate;
            this.sqlSelect.Parameters["@enddate"].Value = endDate;

            appDB.SRPClientDataTable dt = new appDB.SRPClientDataTable();
            Fill(dt);
            return dt;
        }

        public appDB.TimeSlipDataTable LoadByOfficerId(int officerId, DateTime startDate, DateTime endDate, int shortcutsForId )
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[ActivityTimeSelectByOfficerId]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OfficerId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@startdate", System.Data.SqlDbType.SmallDateTime, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@enddate", System.Data.SqlDbType.SmallDateTime, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters["@OfficerId"].Value = officerId;
            this.sqlSelect.Parameters["@startdate"].Value = startDate;
            this.sqlSelect.Parameters["@enddate"].Value = endDate;
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@shortcutsForId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters["@shortcutsForId"].Value = shortcutsForId;

            appDB.TimeSlipDataTable dt = new appDB.TimeSlipDataTable();
            Fill(dt);
            return dt;
        }

        public appDB.SRPClientDataTable LoadSRPClientBySRPID(int srpId)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[SRPClientBySRPID]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SRPID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters["@SRPID"].Value = srpId;

            appDB.SRPClientDataTable dt = new appDB.SRPClientDataTable();
            Fill(dt);
            return dt;
        }

        public appDB.TimeSlipDataTable LoadBySRPID(int srpId, int shortcutsForId)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[ActivityTimeSelectBySRPID]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SRPID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters["@SRPID"].Value = srpId;
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@shortcutsForId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters["@shortcutsForId"].Value = shortcutsForId;


            appDB.TimeSlipDataTable dt = new appDB.TimeSlipDataTable();
            Fill(dt);
            return dt;
        }

        public appDB.TimeSlipBranchDataTable LoadBranchBySRPID(int srpId)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[TimeSlipBranchBySRPID]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SRPID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters["@SRPID"].Value = srpId;


            appDB.TimeSlipBranchDataTable dt = new appDB.TimeSlipBranchDataTable();
            Fill(dt);
            return dt;
        }

        public appDB.TimeSlipBranchDataTable LoadBranchByOfficerId(int officerId, DateTime startDate, DateTime endDate)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[TimeSlipBranchByOfficerId]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OfficerId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@startdate", System.Data.SqlDbType.SmallDateTime, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@enddate", System.Data.SqlDbType.SmallDateTime, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters["@OfficerId"].Value = officerId;
            this.sqlSelect.Parameters["@startdate"].Value = startDate;
            this.sqlSelect.Parameters["@enddate"].Value = endDate;

            appDB.TimeSlipBranchDataTable dt = new appDB.TimeSlipBranchDataTable();
            Fill(dt);
            return dt;
        }

    }
}
