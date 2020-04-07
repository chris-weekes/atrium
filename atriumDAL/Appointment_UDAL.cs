using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;

namespace atriumDAL
{
    public partial class AppointmentDAL : atDAL.ObjectDAL
    {
        public atriumDB.AppointmentDataTable LoadByContactId(int ContactId)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[AppointmentSelectByContactId]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ContactId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters["@ContactId"].Value = ContactId;

            atriumDB.AppointmentDataTable dt = new atriumDB.AppointmentDataTable();
            Fill(dt);
            return dt;
        }
        // not used AC - Mar 27, 2014
        //public atriumDB.TimeLineDataTable LoadByAllFileContactDates(int FileId, DateTime startDate, DateTime endDate)
        //{
        //    this.sqlDa.SelectCommand = sqlSelect;
        //    this.sqlSelect.Parameters.Clear();
        //    this.sqlSelect.CommandText = "[AppointmentSelectByAllFileContactDates]";
        //    this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
        //    this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FileId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
        //    this.sqlSelect.Parameters["@FileId"].Value = FileId;
        //    this.sqlSelect.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.DateTime, 24, "StartDate"));
        //    this.sqlSelect.Parameters["@StartDate"].Value = startDate;
        //    this.sqlSelect.Parameters.Add(new SqlParameter("@EndDate", SqlDbType.DateTime, 24, "EndDate"));
        //    this.sqlSelect.Parameters["@EndDate"].Value = endDate;

        //    atriumDB.TimeLineDataTable dt = new atriumDB.TimeLineDataTable();
        //    Fill(dt);
        //    return dt;
        //}
        public atriumDB.TimeLineDataTable LoadByContactIdDates(int ContactId, DateTime startDate, DateTime endDate)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[AppointmentSelectByContactIdDates]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ContactId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters["@ContactId"].Value = ContactId;
            this.sqlSelect.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.DateTime, 24, "StartDate"));
            this.sqlSelect.Parameters["@StartDate"].Value = startDate;
            this.sqlSelect.Parameters.Add(new SqlParameter("@EndDate", SqlDbType.DateTime, 24, "EndDate"));
            this.sqlSelect.Parameters["@EndDate"].Value = endDate;

            atriumDB.TimeLineDataTable dt = new atriumDB.TimeLineDataTable();
            Fill(dt);
            return dt;
        }

        public byte[] LoadAllForOfficer(int officerId)
        {
            atriumDALManager aDAL = (atriumDALManager)this.DAL;
            DataSet ds = new DataSet();
          
            ds.RemotingFormat = SerializationFormat.Binary;

            ds.Merge(this.LoadByContactId(officerId));
            ds.Merge(aDAL.GetAttendee().LoadByContactId(officerId));
            //ds.Merge(aDAL.GetApptRecurrence().loadb(fileId));
 
            FixTZDSIssue(ds);
            return atriumDALManager.CompressData(ds);
        }
    }
}
