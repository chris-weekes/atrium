
using System;
using System.IO;
//using System.ComponentModel;
//using System.Collections;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO.Compression;
using System.Runtime.Remoting.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atDAL
{
    public class SqlDatabase
    {
        private SqlConnection mySQLCon;
        public SqlDatabase(SqlConnection myCon)
        {
            mySQLCon = myCon;
        }

        public DataSet ExecuteDataSet(SqlTransaction tran, CommandType cmdType, string query)
        {
            if(mySQLCon.State!= ConnectionState.Open)
                mySQLCon.Open();
            SqlCommand cmd = new SqlCommand(query,mySQLCon);
            if (tran != null)
                cmd.Transaction = tran;
            cmd.CommandType = cmdType;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds=new DataSet();
            da.Fill(ds);
            return ds;

        }
        public DataSet ExecuteDataSet(CommandType cmdType, string query)
        {
            return ExecuteDataSet(null,cmdType,query);
        }
        public DataSet ExecuteDataSet(SqlCommand cmd)
        {
            if (mySQLCon.State != ConnectionState.Open)
                mySQLCon.Open();
            cmd.Connection = mySQLCon;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet ExecuteDataSet(SqlTransaction tran,  string spName, params  object[] parameterValues)
        {
            if (mySQLCon.State != ConnectionState.Open)
                mySQLCon.Open();
            SqlCommand cmd = new SqlCommand(spName, mySQLCon);
            if (tran != null)
                cmd.Transaction = tran;
            cmd.CommandType =  CommandType.StoredProcedure;
            SqlCommandBuilder.DeriveParameters(cmd);
            for (int i = 1, j = cmd.Parameters.Count; i < j; i++)
            {
                if (parameterValues[i - 1] == null)
                    cmd.Parameters[i].Value = System.DBNull.Value;
                else
                    cmd.Parameters[i].Value = parameterValues[i - 1];
               
            }

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet ExecuteDataSet(string spName, params  object[] parameterValues)
        {
            return ExecuteDataSet(null,spName,parameterValues);
        }

        public void ExecuteNonQuery(CommandType cmdType, string query)
        {
            ExecuteNonQuery(null, cmdType, query);
        }
        public void ExecuteNonQuery(SqlTransaction tran, CommandType cmdType, string query)
        {
            if (mySQLCon.State != ConnectionState.Open)
                mySQLCon.Open();
            SqlCommand cmd = new SqlCommand(query, mySQLCon);
            if(tran!=null)
                cmd.Transaction = tran;
            cmd.CommandType = cmdType;
            cmd.ExecuteNonQuery();
        }

        public void ExecuteNonQuery(string spName, params  object[] parameterValues)
        {
            ExecuteNonQuery(null, spName, parameterValues);
        }
        public void ExecuteNonQuery(SqlTransaction tran, string spName, params  object[] parameterValues)
        {
            if (mySQLCon.State != ConnectionState.Open)
                mySQLCon.Open();
            SqlCommand cmd = new SqlCommand(spName, mySQLCon);
            if (tran != null)
                cmd.Transaction = tran;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlCommandBuilder.DeriveParameters(cmd);
            SqlCommandBuilder.DeriveParameters(cmd);
            for (int i = 1, j = cmd.Parameters.Count; i < j; i++)
            {
                if (parameterValues[i - 1] == null)
                    cmd.Parameters[i].Value = System.DBNull.Value;
                else
                    cmd.Parameters[i].Value = parameterValues[i - 1];

            }
            cmd.ExecuteNonQuery();
        }

        public object ExecuteScalar(string spName, params  object[] parameterValues)
        {
            return ExecuteScalar(null,spName,parameterValues);
        }
        public object ExecuteScalar(SqlTransaction tran, string spName, params  object[] parameterValues)
        {
            if (mySQLCon.State != ConnectionState.Open)
                mySQLCon.Open();
            SqlCommand cmd = new SqlCommand(spName, mySQLCon);
            if (tran != null)
                cmd.Transaction = tran;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlCommandBuilder.DeriveParameters(cmd);
            SqlCommandBuilder.DeriveParameters(cmd);
            for (int i = 1, j = cmd.Parameters.Count; i < j; i++)
            {
                if (parameterValues[i - 1] == null)
                    cmd.Parameters[i].Value = System.DBNull.Value;
                else
                    cmd.Parameters[i].Value = parameterValues[i - 1];

            }
            return cmd.ExecuteScalar();
        }

        public object ExecuteScalar(CommandType cmdType,string sql)
        {
            return ExecuteScalar(null,cmdType,sql);
        }

        public object ExecuteScalar(SqlTransaction tran, CommandType cmdType, string sql)
        {
            if (mySQLCon.State != ConnectionState.Open)
                mySQLCon.Open();
            SqlCommand cmd = new SqlCommand(sql, mySQLCon);
            if (tran != null)
                cmd.Transaction = tran;
            cmd.CommandType = cmdType;
            return cmd.ExecuteScalar();
        }
    }
}
