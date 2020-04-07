using System;
using System.Data;
using System.Data.SqlClient;


namespace atDAL
{
	/// <summary>
	/// Summary description for ObjectDAL.
	/// </summary>
	public class ObjectDAL:MarshalByRefObject,IDisposable
	{

		protected DALManager myDALManager;

		protected SqlDataAdapter sqlDa;
		protected SqlCommand sqlSelect;
		protected SqlCommand sqlSelectAll;
		protected SqlCommand sqlInsert;
		protected SqlCommand sqlUpdate;
		protected SqlCommand sqlDelete;

		 bool isFilling =false;
        public DateTime myLastEdit = new DateTime(1900, 1, 1);

        public void PreRefresh()
        {
            myLastEdit = new DateTime(1900, 1, 1);
        }

		protected internal ObjectDAL(DALManager pDALManager)
		{
            System.Diagnostics.Trace.WriteLine(this.GetType().ToString(), "CreateDAL");
			myDALManager=pDALManager;

			this.sqlDa = new SqlDataAdapter();
			this.sqlSelect = new SqlCommand();
			this.sqlSelectAll = new SqlCommand();
			this.sqlInsert = new SqlCommand();
			this.sqlUpdate = new SqlCommand();
			this.sqlDelete = new SqlCommand();

			
			// 
			// sqlDa
			// 
			this.sqlDa.DeleteCommand = this.sqlDelete;
			this.sqlDa.UpdateCommand = this.sqlUpdate;
			this.sqlDa.InsertCommand = this.sqlInsert;
			this.sqlDa.SelectCommand = this.sqlSelect;

		}

		public DALManager DAL
		{
			get
			{
				return myDALManager;
			}
		}

        public virtual DataTable Update(DataTable myData)
		{
            System.Diagnostics.Trace.WriteLine(myData.TableName, "DALUpdate");
			if(!myData.HasErrors)
			{
				this.myDALManager.OpenCon();

                sqlDa.UpdateCommand.Connection = myDALManager.SqlCon;
                sqlDa.InsertCommand.Connection =myDALManager.SqlCon;
                sqlDa.DeleteCommand.Connection = myDALManager.SqlCon;

				System.Data.SqlClient.SqlTransaction tran=myDALManager.GetTrans();

				this.sqlDa.UpdateCommand.Transaction=tran;
				this.sqlDa.DeleteCommand.Transaction=tran;
				this.sqlDa.InsertCommand.Transaction=tran;

				isFilling=true;
                try
                {
                    this.sqlDa.Update(myData);
                }
               catch (Exception e)
                {
                    isFilling = false;
                    System.Diagnostics.Trace.WriteLine(e.Message, "Atrium");
                    //string msg = "Could not update table: {0}";
                    //throw new ApplicationException(String.Format(msg, myData.TableName), e);
                    throw e;
                }
				finally
				{
					isFilling=false;
				}

				this.myDALManager.CloseCon();

                return myData;

			}
			else
			{
				throw new Exception("Table Errors");
			}
		}

        public DataTable Update(DataSet myData)
        {
            System.Diagnostics.Trace.WriteLine(this.GetType().ToString(), "DALUpdate");

            if (!myData.HasErrors)
            {
                this.myDALManager.OpenCon();

                System.Data.SqlClient.SqlTransaction tran = myDALManager.GetTrans();

                this.sqlDa.UpdateCommand.Transaction = tran;
                this.sqlDa.DeleteCommand.Transaction = tran;
                this.sqlDa.InsertCommand.Transaction = tran;

                isFilling = true;
                try
                {
                    this.sqlDa.Update(myData);
                }
                catch (Exception e)
                {
                    isFilling = false;
                    System.Diagnostics.Trace.WriteLine(e.Message, "Atrium");
                    throw e;
                }
                finally
                {
                    isFilling = false;
                }

                this.myDALManager.CloseCon();

                return myData.Tables[0];

            }
            else
            {
                throw new Exception("Table Errors");
            }
        }

        protected void Fill(DataTable myData)
		{
			isFilling=true;

           // System.Diagnostics.Trace.WriteLine(this.GetType().ToString(), "FillDAL");

            
            myData.RemotingFormat = myDALManager.RemotingFormat; 
     

            
			try
			{
				this.myDALManager.OpenCon();

				myData.BeginLoadData();

                sqlDa.SelectCommand.Connection = myDALManager.SqlCon;

				if(this.myDALManager.myTrans!=null)
					this.sqlDa.SelectCommand.Transaction=this.myDALManager.myTrans;
				else
					this.sqlDa.SelectCommand.Transaction=null;

				this.sqlDa.Fill(myData);


				myData.EndLoadData();
                //if (myData.Rows.Count > 0 & myData.Columns.Contains("UpdateDate"))
                //{
                //    myLastEdit = (DateTime)myData.Select("", "UpdateDate desc")[0]["UpdateDate"];
                //}

                //TFS#51279 TAC 2013-8-29 - Deal with time zone off sets set by web service
                foreach (DataColumn column in myData.Columns)
                {
                    if (column.DataType == typeof(DateTime))
                    {
                        column.DateTimeMode = DataSetDateTime.Unspecified;
                    }
                }
                //End TFS #51279

				this.myDALManager.CloseCon();
			}
			catch(Exception e)
			{
				throw e;
			}
			finally
			{
				isFilling=false;
			}

		}
        protected void Fill(DataSet myDS)
        {
            isFilling = true;

            //System.Diagnostics.Trace.WriteLine(this.GetType().ToString(), "FillDS");

            myDS.RemotingFormat = myDALManager.RemotingFormat;

            try
            {
                this.myDALManager.OpenCon();


                sqlDa.SelectCommand.Connection = myDALManager.SqlCon;

                if (this.myDALManager.myTrans != null)
                    this.sqlDa.SelectCommand.Transaction = this.myDALManager.myTrans;
                else
                    this.sqlDa.SelectCommand.Transaction = null;

                this.sqlDa.Fill(myDS);

                //if (myData.Rows.Count > 0 & myData.Columns.Contains("UpdateDate"))
                //{
                //    myLastEdit = (DateTime)myData.Select("", "UpdateDate desc")[0]["UpdateDate"];
                //}
                //TFS#51279 TAC 2013-9-3 - Deal with time zone off sets set by web service
                FixTZDSIssue(myDS);
                //End TFS #51279

                this.myDALManager.CloseCon();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                isFilling = false;
            }

        }

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
        public virtual DataTable Load()
        {
            string tblNm = sqlDa.TableMappings[0].DataSetTable;
            this.sqlDa.SelectCommand = sqlSelectAll;
            DataTable dt = new DataTable(tblNm);
            Fill(dt);
            return dt;
        }
        public virtual byte[] LoadByte()
        {
            return DALManager.CompressData(Load());
        }
		public string User
		{
			get
			{
				return this.myDALManager.User;
			}
		}



        #region IDisposable Members

        public void Dispose()
        {
            sqlDa.Dispose();
            sqlDelete.Dispose();
            sqlSelect.Dispose();
            sqlSelectAll.Dispose();
            sqlInsert.Dispose();
            sqlUpdate.Dispose();
        }

        #endregion
    }
}
