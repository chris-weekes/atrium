using System;
using System.Collections.Generic;

namespace atLogic
{
    /// <summary>
    /// This class is used for coordinating updates to the database
    /// It allows objects to be grouped and sequenced for a transaction
    /// </summary>
    /// 
    public class BusinessProcess
    {
        BEManager myMng;
        public BusinessProcess(BEManager mng)
        {
            myMng = mng;
        }

        private List<ObjectBE> updateList = new List<ObjectBE>();

        private int FindOBE(string before)
        {
            foreach (ObjectBE ob in updateList)
            {
                if (ob.myDT.TableName == before)
                    return updateList.IndexOf(ob);
            }
            return updateList.Count;

        }
        public void AddForUpdate(ObjectBE obe, string before)
        {
            int i = FindOBE(before);

            updateList.Insert(i, obe);
        }
        public void AddForUpdate(ObjectBE obe)
        {
            updateList.Add(obe);
        }
        public void AddForUpdate(System.Data.DataTable dt)
        {
            if (dt.ExtendedProperties["BE"] != null)
            {
                updateList.Add((atLogic.ObjectBE)dt.ExtendedProperties["BE"]);
            }

        }
        public void AddForUpdate(System.Data.DataTable dt, string before)
        {
            if (dt.ExtendedProperties["BE"] != null)
            {
                int i = FindOBE(before);

                updateList.Insert(i, (atLogic.ObjectBE)dt.ExtendedProperties["BE"]);
            }

        }
        public void Clear()
        {
            updateList.Clear();
        }
        public void Update()
        {

            Update(myMng.AppMan.AtriumXURL);
        }
        private void Update(string address)
        {
            ObjectBE[] copy = updateList.ToArray();
            updateList.Clear();


            foreach (ObjectBE obe in copy)
            {
                try
                {
                    obe.BeforeUpdate();
                }
                catch (Exception x1)
                {
                    throw new AtriumException("Update stopped on " + obe.myDT.TableName + ".  Reject changes will restore Datatables consistency with database.\r\n", x1);
                }
                if (obe.myDT.HasErrors)
                    throw new AtriumException("Update stopped on " + obe.myDT.TableName + ".  Reject changes will restore Datatables consistency with database.\r\n" + obe.ErrorsForTable(obe.myDT));
            }
            string tableNm = "";
            System.Data.DataSet dsDown = null;
            try
            {
                System.Data.DataSet dsUp = new System.Data.DataSet();

                List<string> tables = new List<string>();
                foreach (ObjectBE obe in copy)
                {
                    System.Data.DataTable dt = obe.myDT.GetChanges();
                    if (dt != null)
                    {
                        dt.ExtendedProperties.Remove("BE");
                        if (!obe.IsVirtual)
                        {
                            //extend this scheme to include the obe.MyMNg.CurrentFileid
                            //this way we can put the returned datatable into the right obe object
                            //we will need to rename the datatables in the server code to include this info
                            if (obe.DALName == "")
                                tables.Add(dt.TableName);
                            else
                                tables.Add(dt.TableName + "." + obe.DALName);
                        }

                        if (!dsUp.Tables.Contains(dt.TableName))
                        {
                            //TFS#51279 CJW 2013-8-30 - Deal with time zone off sets set by web service
                            foreach (System.Data.DataColumn column in dt.Columns)
                            {
                                if (column.DataType == typeof(DateTime))
                                {
                                    //column.DateTimeMode = System.Data.DataSetDateTime.Unspecified;
                                }
                            }
                            //End TFS #51279
                            dsUp.Tables.Add(dt);
                        }
                    }
                }

                if (myMng.AppMan.Compression) //compression on
                {
                    byte[] byteUp = BEManager.CompressData(dsUp);

                    //dsUp.Dispose();
                    //dsUp = null;
                    dsUp.Clear();
                    dsUp.AcceptChanges();

                    if (!myMng.AppMan.UseService)
                    {
                        byteUp = this.myMng.DAL.Update(tables, byteUp);
                    }
                    else
                    {


                        byteUp = myMng.AppMan.AtriumX().UpdateComp(myMng.AppMan.Connect, myMng.AppMan.myPwd, myMng.AppMan.myUser, tables.ToArray(), byteUp);



                    }
                    dsDown = BEManager.DecompressDataSet(byteUp, dsUp);
                }
                else //compression ffn
                {
                    if (!myMng.AppMan.UseService)
                    {
                        dsDown = this.myMng.DAL.Update(tables, dsUp);
                    }
                    else
                    {

                        dsUp.RemotingFormat = System.Data.SerializationFormat.Binary;

                        dsDown = myMng.AppMan.AtriumX().Update(myMng.AppMan.Connect, myMng.AppMan.myPwd, myMng.AppMan.myUser, tables.ToArray(), dsUp);

                    }

                }
            }

            catch (Exception x)
            {
                if (x.InnerException != null)
                {
                    if (x.InnerException.GetType() == typeof(System.Data.SqlClient.SqlException))
                    {
                        System.Data.SqlClient.SqlException sqle = (System.Data.SqlClient.SqlException)x.InnerException;
                        switch (sqle.Number)
                        {
                            case 2601:
                                throw new Exception(Properties.Resources.DuplicateValueInAUniqueColumn, sqle);
                            case 50000:
                                throw new AtriumException(sqle.Message);
                            default:
                                throw sqle;
                        }
                    }
                    else if (x.InnerException.GetType() == typeof(System.Data.DBConcurrencyException))
                    {
                        System.Data.DBConcurrencyException dbce = (System.Data.DBConcurrencyException)x.InnerException;
                        throw new ConcurrencyException(String.Format(Properties.Resources.ConcurrencyError, ""), x);

                    }
                    else
                    {
                        throw x;
                    }

                }
                else
                {
                    throw new UpdateFailedException("Update failed on " + tableNm + ".  Datatables need to be reloaded as acceptchanges/merge has been called on them.\r\n", x);
                }

            }

            //TFS#51508 CJW 2013-09-19 
            //all updates have succeeded
            //merge data back into client datasets
            //and accept changes
            bool isError = false;
            Exception x5 = null;
            foreach (ObjectBE obe in copy)
            {
                tableNm = obe.myDT.TableName;
                if (dsDown.Tables.Count > 0 && dsDown.Tables.Contains(tableNm))
                {

                    try
                    {
                        //hack required because we remove the Contents column on the server to speed up the download
                        //if we leave it in it gets blanked
                        if (tableNm.ToLower() == "doccontent")
                        {
                            dsDown.Tables[tableNm].Columns.Remove("Contents");
                        }//end of hack

                        if (!obe.IsVirtual)
                            obe.Fill(dsDown.Tables[tableNm]);
                        obe.AfterUpdate();
                    }
                    catch (System.InvalidOperationException x)
                    {
                        //trap for Corrupt datatable index '5'
                        isError = true;
                        x5 = x;
                    }
                    //acceptchanges must be called last so that afterupdate knows which rows o process
                    obe.myDT.AcceptChanges();
                }

            }

            if (isError)
                throw new AtriumException("An unexpected error has occurred.  Please close and restart Atrium.", x5);
        }
    }
}
