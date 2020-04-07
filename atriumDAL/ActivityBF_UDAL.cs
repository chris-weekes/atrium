using System;
using System.Collections.Generic;
using System.Text;
using lmDatasets;

namespace atriumDAL
{
    public partial class ActivityBFDAL : atDAL.ObjectDAL
    {
        public atriumDB.ActivityBFDataTable LoadByFileId(int FileId)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[ActivityBFSelectByFileIdM]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FileId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters["@FileId"].Value = FileId;
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lstActivityEdit", System.Data.SqlDbType.SmallDateTime, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters["@lstActivityEdit"].Value = myLastEdit;
            sqlSelect.CommandTimeout = 30;
            atriumDB.ActivityBFDataTable dt = new atriumDB.ActivityBFDataTable();
            Fill(dt);
            return dt;
        }
        public atriumDB.ActivityBFDataTable LoadByDirect(int officerId, DateTime date)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[ActivityBFSelectByDirect]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OfficerId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@date", System.Data.SqlDbType.SmallDateTime, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters["@officerId"].Value = officerId;
            this.sqlSelect.Parameters["@date"].Value = date;
            sqlSelect.CommandTimeout = 30;
            atriumDB.ActivityBFDataTable dt = new atriumDB.ActivityBFDataTable();
            Fill(dt);
            return dt;
        }
        public atriumDB.ActivityBFDataTable LoadByCompleted(int officerId, DateTime fromDate, DateTime toDate)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[ActivityBFSelectCompleted]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OfficerId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fromdt", System.Data.SqlDbType.SmallDateTime, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@todt", System.Data.SqlDbType.SmallDateTime, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters["@officerId"].Value = officerId;
            this.sqlSelect.Parameters["@fromdt"].Value = fromDate;
            this.sqlSelect.Parameters["@todt"].Value = toDate;

            atriumDB.ActivityBFDataTable dt = new atriumDB.ActivityBFDataTable();
            Fill(dt);
            return dt;
        }

        public atriumDB.ActivityBFDataTable LoadByRole(int officerId, DateTime date)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[ActivityBFSelectByRoleNew]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OfficerId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@date", System.Data.SqlDbType.SmallDateTime, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters["@officerId"].Value = officerId;
            this.sqlSelect.Parameters["@date"].Value = date;

            atriumDB.ActivityBFDataTable dt = new atriumDB.ActivityBFDataTable();
            Fill(dt);
            return dt;
        }

        public atriumDB.ActivityBFDataTable LoadByRoleFile(int officerId, DateTime date)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[ActivityBFSelectByRoleFile]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OfficerId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@date", System.Data.SqlDbType.SmallDateTime, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters["@officerId"].Value = officerId;
            this.sqlSelect.Parameters["@date"].Value = date;

            atriumDB.ActivityBFDataTable dt = new atriumDB.ActivityBFDataTable();
            Fill(dt);
            return dt;
        }

        public atriumDB.ActivityBFDataTable LoadByRoleGlobal(int officerId, DateTime date)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[ActivityBFSelectByRoleGlobal]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OfficerId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@date", System.Data.SqlDbType.SmallDateTime, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters["@officerId"].Value = officerId;
            this.sqlSelect.Parameters["@date"].Value = date;

            atriumDB.ActivityBFDataTable dt = new atriumDB.ActivityBFDataTable();
            Fill(dt);
            return dt;
        }

        public atriumDB.ActivityBFDataTable LoadByDirectForOffice(int officeId, DateTime date)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[ActivityBFSelectByDirectForOffice]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OfficeId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@date", System.Data.SqlDbType.SmallDateTime, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters["@officeId"].Value = officeId;
            this.sqlSelect.Parameters["@date"].Value = date;

            atriumDB.ActivityBFDataTable dt = new atriumDB.ActivityBFDataTable();
            Fill(dt);
            return dt;
        }
        public atriumDB.ActivityBFDataTable LoadByRoleForOffice(int officeId, DateTime date)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[ActivityBFSelectByRoleNewForOffice]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OfficeId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@date", System.Data.SqlDbType.SmallDateTime, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters["@officeId"].Value = officeId;
            this.sqlSelect.Parameters["@date"].Value = date;

            atriumDB.ActivityBFDataTable dt = new atriumDB.ActivityBFDataTable();
            Fill(dt);
            return dt;
        }

        //public atriumDB.ActivityBFDataTable LoadByLawyer(int officerId, DateTime date)
        //{
        //    this.sqlDa.SelectCommand = sqlSelect;
        //    this.sqlSelect.Parameters.Clear();
        //    this.sqlSelect.CommandText = "[ActivityBFSelectByLawyer]";
        //    this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
        //    this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OfficerId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
        //    this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@date", System.Data.SqlDbType.SmallDateTime, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
        //    this.sqlSelect.Parameters["@officerId"].Value = officerId;
        //    this.sqlSelect.Parameters["@date"].Value = date;

        //    atriumDB.ActivityBFDataTable dt = new atriumDB.ActivityBFDataTable();
        //    Fill(dt);
        //    return dt;
        //}
        //public atriumDB.ActivityBFDataTable LoadByPL(int officerId, DateTime date)
        //{
        //    this.sqlDa.SelectCommand = sqlSelect;
        //    this.sqlSelect.Parameters.Clear();
        //    this.sqlSelect.CommandText = "[ActivityBFSelectByPL]";
        //    this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
        //    this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OfficerId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
        //    this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@date", System.Data.SqlDbType.SmallDateTime, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
        //    this.sqlSelect.Parameters["@officerId"].Value = officerId;
        //    this.sqlSelect.Parameters["@date"].Value = date;

        //    atriumDB.ActivityBFDataTable dt = new atriumDB.ActivityBFDataTable();
        //    Fill(dt);
        //    return dt;
        //}

        //public System.Data.DataTable LoadByMail(int officerId, DateTime date)
        //{
        //    this.sqlDa.SelectCommand = sqlSelect;
        //    this.sqlSelect.Parameters.Clear();
        //    this.sqlSelect.CommandText = "[ActivityBFSelectByMail]";
        //    this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
        //    this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OfficerId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
        //    this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@date", System.Data.SqlDbType.SmallDateTime, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
        //    this.sqlSelect.Parameters["@officerId"].Value = officerId;
        //    this.sqlSelect.Parameters["@date"].Value = date;

        //    System.Data.DataTable dt = new System.Data.DataTable();
        //    Fill(dt);
        //    return dt;
        //}
        //public atriumDB.ActivityBFDataTable LoadByOffice(int officeId, DateTime date)
        //{
        //    this.sqlDa.SelectCommand = sqlSelect;
        //    this.sqlSelect.Parameters.Clear();
        //    this.sqlSelect.CommandText = "[ActivityBFSelectByOffice]";
        //    this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
        //    this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OfficeId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
        //    this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@date", System.Data.SqlDbType.SmallDateTime, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
        //    this.sqlSelect.Parameters["@officeId"].Value = officeId;
        //    this.sqlSelect.Parameters["@date"].Value = date;

        //    atriumDB.ActivityBFDataTable dt = new atriumDB.ActivityBFDataTable();
        //    Fill(dt);
        //    return dt;
        //}

        public byte[] LoadBF(int officeId, int officerId, DateTime date, bool officerBF, Int64 tmpLastEdit)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();

            //System.DateTime tmpLastEdit = myLastEdit;

            System.Data.DataSet ds = new System.Data.DataSet();
            atriumDB.ActivityBFDataTable dt = new atriumDB.ActivityBFDataTable();
            ds.RemotingFormat = System.Data.SerializationFormat.Binary;


            if (!officerBF)
            {
                //select office bfs
                dt.Merge(LoadByDirectForOffice(officeId, date));
                dt.Merge(LoadByRoleForOffice(officeId, date));
            }
            else
            {
                atriumDALManager Dal = (atriumDALManager)myDALManager;

                //select direct bfs
                dt.Merge(LoadByDirect(officerId, date));

                //select role bfs
                dt.Merge(LoadByRoleFile(officerId, date));
                lmDatasets.officeDB.OfficerRoleDataTable dtor = Dal.GetOfficerRole().LoadByOfficerID(officerId);
                if (dtor.Rows.Count > 0)
                {
                    dt.Merge(LoadByRoleGlobal(officerId, date));
                }

                //load access level 1 delegate bfs
                lmDatasets.officeDB.OfficerDelegateDataTable dto = Dal.GetOfficerDelegate().LoadByDelegateToId(officerId);

                foreach (officeDB.OfficerDelegateRow odr in dto.Rows)
                {
                    if (odr.AccessLevel == 1)
                    {
                        dt.Merge(LoadByDirect(odr.OfficerId, date));
                        dt.Merge(LoadByRoleFile(odr.OfficerId, date));
                        lmDatasets.officeDB.OfficerRoleDataTable dtor1 = Dal.GetOfficerRole().LoadByOfficerID(odr.OfficerId);
                        if (dtor1.Rows.Count > 0)
                        {
                            dt.Merge(LoadByRoleGlobal(odr.OfficerId, date));
                        }
                    }
                }
            }


            if (tmpLastEdit != null)
            {

                System.Data.DataView dv = new System.Data.DataView(dt, "ver>" + tmpLastEdit.ToString(), "", System.Data.DataViewRowState.CurrentRows);

                //if (dt.Rows.Count > 0 & dt.Columns.Contains("UpdateDate"))
                //{
                //    myLastEdit = (DateTime)dt.Select("", "UpdateDate desc")[0]["UpdateDate"];
                //}

                atriumDB.ActivityBFDataTable dt1 = new atriumDB.ActivityBFDataTable();
                dt1.Merge(dv.ToTable());
                //dt =(atriumDB.ActivityBFDataTable) dv.ToTable();
                dt1.AcceptChanges();
                ds.Tables.Add(dt1);
                FixTZDSIssue(ds);
                return atriumDALManager.CompressData(ds);
            }
            else
            {
                ds.Tables.Add(dt);
                FixTZDSIssue(ds);
                return atriumDALManager.CompressData(ds);
            }
        }

    }
}
