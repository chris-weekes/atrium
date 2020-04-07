using System;
using System.Data;
using System.Collections.Generic;

namespace atLogic
{
    /// <summary>
    /// 
    /// </summary>
    /// 


    public class UpdateEventArgs : EventArgs
    {
        public bool SavedOK = false;
        public DataRow[] ChangedRows;
    }
    public delegate void UpdateEventHandler(object sender, UpdateEventArgs e);

    /// <summary>
    /// The primary base class for all business objects in Atrium
    /// Enforces business rules
    /// Manages a datatable
    /// </summary>
    public class ObjectBE : IDisposable
    {

        bool isVirtual = false;
        protected internal lmDatasets.appDB.ddTableRow myDefinition;
        protected internal Dictionary<string, lmDatasets.appDB.ddFieldRow> columnMap = new Dictionary<string, lmDatasets.appDB.ddFieldRow>();
        /// <summary>
        /// Indicates if the datatable managed is in the database
        /// </summary>
        public bool IsVirtual
        {
            get { return isVirtual; }
            set { isVirtual = value; }
        }

        private bool isLoaded = false;

        /// <summary>
        /// Obsolete
        /// Indicates if datatable has been loaded
        /// </summary>
        public bool IsLoaded
        {
            get { return isLoaded; }
            set { isLoaded = value; }
        }



        private bool isDisposed = false;

        /// <summary>
        /// Returns a reference to the DAL component for this datatable
        /// Reference can be local or remoted depending on configuration
        /// </summary>
        protected internal atDAL.ObjectDAL myODAL
        {
            get
            {
                if (myMngr.AppMan.UseService)
                    return null;
                else
                {
                    if (DALName == "")
                        return myMngr.AppMan.myDALClient.ODAL(myDT.TableName + "DAL");
                    else
                        return myMngr.AppMan.myDALClient.ODAL(DALName + "DAL");
                }
            }
            set
            {

                myMngr.AppMan.myDALClient.AddDAL(value);


            }
        }

        /// <summary>
        /// Recreates DAL object if it has expired on server
        /// Only used when DAL is remoted
        /// </summary>
        public void RecoverDAL()
        {

            if (DALName == "")
                myODAL = MyMngr.AppMan.myDALClient.RecoverDAL(myDT.TableName );
            else
                myODAL = MyMngr.AppMan.myDALClient.RecoverDAL(DALName );

        }

        private BEManager myMngr;

        /// <summary>
        /// Reference to this object's manager
        /// </summary>
        public BEManager MyMngr
        {
            get { return myMngr; }
        }

        /// <summary>
        /// The datatable that this class manages
        /// </summary>
        public DataTable myDT;

        private Object thisLock = new Object();

        private bool isInEvent = false;
        private bool isFilling = false;

        protected bool AllowEdit = false;
        protected bool AllowAdd = false;
        protected bool AllowDelete = false;

        private string myUser = "";

        public event UpdateEventHandler OnUpdate;

        private System.Collections.Generic.List<string> myWarnings = new System.Collections.Generic.List<string>();

        private bool isColumnChangeMode = true;

        /// <summary>
        /// Indicates whether column change events are fired as soon as a column is changed or when the row is updated
        /// </summary>
        public bool IsColumnChangeMode
        {
            get { return isColumnChangeMode; }
            set { isColumnChangeMode = value; }
        }

        string myEntityName = "";
        /// <summary>
        /// Constructor for class
        /// </summary>
        /// <param name="mngr">The manager for this object</param>
        /// <param name="pDT">The datatable that will be managed</param>
        public ObjectBE(BEManager mngr, DataTable pDT)
        {
            myMngr = mngr;
            myEntityName = pDT.TableName;
            myDT = pDT;
            Init();
        
            myUser = mngr.AppMan.myUser;

       
            myMngr.myBEs.Add(myEntityName, this);

        }

        public ObjectBE(BEManager mngr, DataTable pDT,string entityName)
        {
            myMngr = mngr;
            myEntityName = entityName;
            myDT = pDT.Clone();
          
           
            myDT.TableName = entityName;

            myMngr.MyDS.Tables.Add(myDT);

            Init();

            myUser = mngr.AppMan.myUser;

            myMngr.myBEs.Add(entityName, this);

        }

        public string DALName = "";
        
/// <summary>
        /// Called to clear table before reloading
        /// </summary>
        public void PreRefresh()
        {

            myDT.Clear();
            myDT.AcceptChanges();
        }

        public void RaiseWarning(WarningLevel level, string message, params object[] args)
        {
            RaiseWarning(level, String.Format(message, args));
        }

        public void RaiseWarning(WarningLevel level, string message)
        {
            string wrng = level.ToString() + message;
            if (!myWarnings.Contains(wrng))
            {
                myWarnings.Add(wrng);
                myMngr.RaiseWarning(level, message, myDT.TableName);
            }
        }


        //public static ObjectBE GetBEFromTable(DataTable dt)
        //{
        //    return (ObjectBE)dt.ExtendedProperties["BE"];
        //}


        /// <summary>
        /// Initializes all event handlers for datatable events
        /// </summary>
        /// <param name="pDT">The datatable being managed</param>
        private void Init()
        {


            if (myMngr.RuleHandler != null)
                myDefinition = myMngr.RuleHandler.GetMyDefinition(myEntityName);
            if (myDefinition != null)
            {
                foreach (lmDatasets.appDB.ddFieldRow dfr in myDefinition.GetddFieldRows())
                {

                    columnMap.Add(dfr.FieldName, dfr);
                    if (dfr.FieldName != dfr.DBFieldName)
                    {
                        columnMap.Add(dfr.DBFieldName, dfr);
                        //the extended property is used by the template writerows function
                        myDT.Columns[dfr.DBFieldName].ExtendedProperties.Add("FieldName", dfr.FieldName);
                    }
                }
            }
            //set reference so that BE objects can be pulled off datatables
            myDT.ExtendedProperties.Add("BE", this);

            //hook up events for data validation and business logic
            myDT.RowChanging += new DataRowChangeEventHandler(RowChangingEventHandler);
            myDT.RowChanged += new DataRowChangeEventHandler(RowChangedEventHandler);
            myDT.RowDeleting += new DataRowChangeEventHandler(RowChangingEventHandler);
            myDT.RowDeleted += new DataRowChangeEventHandler(RowChangedEventHandler);

            if (this.IsColumnChangeMode)
            {
                myDT.ColumnChanging += new DataColumnChangeEventHandler(ColumnChangingEventHandler);
                myDT.ColumnChanged += new DataColumnChangeEventHandler(ColumnChangedEventHandler);
            }

 
        }


        /// <summary>
        /// Loads all the records for this table from the database
        /// </summary>
        public void Load()
        {
            DataTable dt = myDT.Clone();
            if (myMngr.AppMan.UseService)
            {

                Fill(BEManager.DecompressDataTable(myMngr.AppMan.AtriumX().Load(myDT.TableName, myMngr.AppMan.AtriumXCon), dt));
              

            }
            else
            {
                try
                {

                    Fill(BEManager.DecompressDataTable(myODAL.LoadByte(), dt));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(BEManager.DecompressDataTable(myODAL.LoadByte(), dt));
                }
            }
        }


        /// <summary>
        /// Adds and returns a new datarow in the datatable being managed
        /// Will throw an exception if the user does not have permission to add records to this table
        /// AfterAdd fire when this method executes
        /// </summary>
        /// <param name="parentRow">The parent row.  If there is not one, pass null.  Used to set the main foreign key based on relations defined in the dataset.</param>
        /// <returns>The new, initalized datarow</returns>
        public virtual DataRow Add(DataRow parentRow)
        {
            if (CanAdd(parentRow))
            {
                DataRow newRow = myDT.NewRow();

                if (parentRow != null)
                {

                    foreach (DataRelation drel in myDT.ParentRelations)
                    {
                        if (parentRow.Table.TableName == drel.ParentTable.TableName)
                            newRow[drel.ChildColumns[0]] = parentRow[drel.ParentColumns[0].ToString()];
                    }
                }

                myDT.Rows.Add(newRow);

                //set defaults from dd object
                // myDD.SetDefaults(newRow);

                return newRow;
            }
            else
            {
                if (myDT.TableName == "Activity")
                    throw new AtriumException("You are not allowed to add or move activities to this file; it exists only to hold other files to give them structure.");
                else
                    throw new AtriumException("File security, meta-type or business logic does not allow you to add a new row to the " + myDT.TableName + " table.");
            }
        }

        /// <summary>
        /// Merges the compressed datatable returned from the DAL into the managed datatable
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public int Fill(byte[] b)
        {
            //System.Diagnostics.Trace.WriteLine(this.GetType().ToString(), "FillDTByte");


            DataTable dt = BEManager.DecompressDataTable(b,myDT);
            return Fill(dt);
            //int i = dt.Rows.Count;
            //if (dt.Rows.Count > 0)
            //{
            //    isFilling = true;
            //    lock (thisLock)
            //    {
            //        this.myDT.BeginLoadData();
            //        this.myDT.Merge(dt, false, MissingSchemaAction.Ignore);
            //        this.myDT.EndLoadData();
            //    }
            //    isFilling = false;
            //}
            //return i;
        }

        /// <summary>
        /// Merges the datatable returned from the DAL into the managed datatable
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public virtual int Fill(DataTable dt)
        {
            //System.Diagnostics.Trace.WriteLine(this.GetType().ToString(), "FillDT");
            int i = dt.Rows.Count;
            if (dt.Rows.Count > 0)
            {

                isFilling = true;
                lock (thisLock)
                {
                    this.myDT.BeginLoadData();
                    this.myDT.Merge(dt, false, MissingSchemaAction.Ignore);
                    this.myDT.EndLoadData();
                }

                isFilling = false;
            }
            return i;
        }

        //private void Fill(DataSet ds)
        //{
        //    //not in use

        //    //could be used for 'deep load' operations
        //    //or deep load operations could be manager at the bemanager location - better idea
        //    //the problem is that all the events will fire on be objects and the isfilling variable won't be set
        //    //could move isfiling to bemanager
        //    //still have an issue with beginload and endload
        //    //could loop through returned ds and call fill on all datatables
        //    //need to ensure that all relevant be objects are loaded - could be a responsibility of caller\

        //    isFilling = true;
        //    this.myDT.BeginLoadData();
        //    this.myDT.DataSet.Merge(ds);
        //    this.myDT.EndLoadData();

        //    isFilling = false;

        //}

        protected void RaiseUpdateEvent(UpdateEventArgs e)
        {
            if (OnUpdate != null)
            {

                OnUpdate(this, e);
            }
        }
        //private void Update()
        //{
        //    try
        //    {

        //        BeforeUpdate();
        //    }
        //    catch (Exception x)
        //    {
        //        if (OnUpdate != null)
        //        {
        //            UpdateEventArgs e = new UpdateEventArgs();
        //            e.SavedOK = false;
        //            OnUpdate(this, e);
        //        }
        //        throw x;
        //    }

        //    DoUpdate();


        //}
        public void Cancel()
        {
            if (OnUpdate != null)
            {
                UpdateEventArgs e = new UpdateEventArgs();
                e.SavedOK = true;
                OnUpdate(this, e);
            }

        }

        //internal void DoUpdate()
        //{
        //    try
        //    {
        //        myWarnings.Clear();
        //        if (!myDT.HasErrors)
        //        {
        //            DataTable dt = myDT.GetChanges();
        //            if (dt != null)
        //            {
        //                dt.ExtendedProperties.Remove("BE");
        //                DataSet ds = new DataSet();
        //                ds.Tables.Add(dt);

        //                try
        //                {
        //                    Fill(myODAL.Update(ds));
        //                }
        //                catch (System.Runtime.Serialization.SerializationException x)
        //                {
        //                    RecoverDAL();
        //                    Fill(myODAL.Update(ds));
        //                }



        //                AfterUpdate();

        //                //myDT.AcceptChanges();
        //            }

        //        }
        //    }


        //    catch (System.Data.SqlClient.SqlException sqle)
        //    {
        //        //reload failed records?
        //        if (OnUpdate != null)
        //        {
        //            UpdateEventArgs e = new UpdateEventArgs();
        //            e.SavedOK = false;
        //            OnUpdate(this, e);
        //        }
        //        switch (sqle.Number)
        //        {
        //            case 2601:
        //                throw new Exception(Properties.Resources.DuplicateValueInAUniqueColumn, sqle);
        //            case 50000:
        //                throw new AtriumException(sqle.Message);
        //            default:
        //                throw sqle;
        //        }

        //    }
        //    catch (DBConcurrencyException dbce)
        //    {
        //        //reload failed records?
        //        if (OnUpdate != null)
        //        {
        //            UpdateEventArgs e = new UpdateEventArgs();
        //            e.SavedOK = false;
        //            OnUpdate(this, e);
        //        }

        //        throw new AtriumException(String.Format(Properties.Resources.ConcurrencyError, myDT.TableName), dbce);

        //    }
        //    catch (Exception x)
        //    {
        //        if (OnUpdate != null)
        //        {
        //            UpdateEventArgs e = new UpdateEventArgs();
        //            e.SavedOK = false;
        //            OnUpdate(this, e);
        //        }
        //        throw x;
        //    }
        //}

        internal void AfterUpdate()
        {
            DataRow[] drs = myDT.Select("", "", DataViewRowState.ModifiedCurrent | DataViewRowState.Added | DataViewRowState.Deleted);
            foreach (DataRow r in drs)
            {
                try
                {
                    this.RowUpdated(r);
                }
                catch (Exception x)
                {
                    r.RowError = x.Message;
                }
            }

            if (OnUpdate != null)
            {
                UpdateEventArgs e = new UpdateEventArgs();
                e.SavedOK = true;
                e.ChangedRows = drs;
                OnUpdate(this, e);
            }

        }

        internal void BeforeUpdate()
        {
            foreach (DataRow r in myDT.Select("", "", DataViewRowState.ModifiedCurrent | DataViewRowState.Added | DataViewRowState.Deleted))
            {
                this.RowUpdating(r);
            }
        }

        protected void ColumnChangingEventHandler(object sender, DataColumnChangeEventArgs e)
        {

            if (myMngr.isMerging || isFilling || isInEvent)
            {
                return;
            }
            isInEvent = true;
            object curVal = e.Row[e.Column];
            try
            {

                if ((e.Row.RowState != DataRowState.Added & e.Row.RowState != DataRowState.Detached) & false)// && !CanEdit(e.Row))
                {
                    e.ProposedValue = e.Row[e.Column];
                    e.Row.EndEdit();
                    throw new ReadOnlyException();

                }
                else
                {
                    if (e.ProposedValue == null || String.IsNullOrEmpty(e.ProposedValue.ToString()))
                    {
                        //if(!e.Row.IsNull(e.Column))
                        e.Row[e.Column] = DBNull.Value;
                    }
                    else
                        e.Row[e.Column] = e.ProposedValue;

                    BeforeChange(e.Column, e.Row);
                    if(myMngr.RuleHandler!=null)
                        myMngr.RuleHandler.DynBeforeChange(myMngr, e.Column, e.Row, columnMap);
                    e.Row.SetColumnError(e.Column, "");

                }
            }
            catch (ReadOnlyException x)
            {
                e.Row.SetColumnError(e.Column, x.Message);
            }
            catch (Exception exc)
            {
                //e.Row[e.Column] = curVal;
                //e.ProposedValue = curVal;
                //e.Row.EndEdit();
                e.Row.SetColumnError(e.Column, exc.Message);
            }
            finally
            {
                isInEvent = false;
            }

        }

        protected void ColumnChangedEventHandler(object sender, DataColumnChangeEventArgs e)
        {
            if (myMngr.isMerging || isFilling || isInEvent || e.Row.RowState == DataRowState.Detached)
            {
                return;
            }
            isInEvent = true;

            try
            {
                //if(myMngr.IsFieldChanged(e.Column,e.Row))
                //{
                if (e.ProposedValue == null || String.IsNullOrEmpty(e.ProposedValue.ToString()))
                    e.Row[e.Column] = DBNull.Value;
                else
                    e.Row[e.Column] = e.ProposedValue;

                AfterChange(e.Column, e.Row);
                if (myMngr.RuleHandler != null)
                    myMngr.RuleHandler.DynAfterChange(myMngr, e.Column, e.Row, columnMap);

                //}
            }
            catch (Exception exc)
            {
                e.Row.SetColumnError(e.Column, exc.Message);
            }
            finally
            {
                isInEvent = false;
            }

        }

        protected void RowChangingEventHandler(object sender, DataRowChangeEventArgs e)
        {
            if (myMngr.isMerging || isFilling || isInEvent || (e.Row.RowState == DataRowState.Detached & e.Action != DataRowAction.Add))
            {
                return;
            }

            //e.Row.ClearErrors();
            switch (e.Action)
            {
                case DataRowAction.Add:
                    //if (e.Row.Table.Columns.Contains("entryDate"))
                    //{
                    //    e.Row.BeginEdit();
                    //    e.Row["entryDate"] = DateTime.Now;
                    //    e.Row["entryUser"] = myUser;
                    //    e.Row["updateDate"] = DateTime.Now;
                    //    e.Row["updateUser"] = myUser;
                    //    e.Row.EndEdit();
                    //}
                    BeforeAdd(e.Row);
                    if (myMngr.RuleHandler != null)
                        myMngr.RuleHandler.DynBeforeAdd(myMngr, e.Row, myDefinition);
                    break;
                case DataRowAction.Delete:
                    try
                    {
                        if (!CanDelete(e.Row))
                        {
                            e.Row.RejectChanges();
                            throw new DeleteException(myDT.TableName);
                        }
                        else
                        {
                            BeforeDelete(e.Row);
                            if (myMngr.RuleHandler != null)
                                myMngr.RuleHandler.DynBeforeDelete(myMngr, e.Row, myDefinition);
                        }
                    }
                    catch (Exception exc2)
                    {
                        e.Row.RowError += exc2.Message;
                    }
                    break;
                case DataRowAction.Change:
                    if (!this.IsColumnChangeMode)
                    {

                        foreach (DataColumn dc in myDT.Columns)
                        {
                            System.Diagnostics.Debug.WriteLine(dc.ColumnName);
                            System.Diagnostics.Debug.WriteLine("C- " + e.Row[dc, DataRowVersion.Current].ToString());
                            System.Diagnostics.Debug.WriteLine("P- " + e.Row[dc, DataRowVersion.Proposed].ToString());
                            if (!dc.ReadOnly)
                            {
                                if (!e.Row[dc, DataRowVersion.Current].Equals(e.Row[dc, DataRowVersion.Proposed]))
                                {
                                    try
                                    {
                                        BeforeChange(dc, e.Row);

                                    }
                                    catch (Exception exc)
                                    {
                                        e.Row.SetColumnError(dc, exc.Message);
                                    }
                                }
                            }
                        }
                    }
                    //					try
                    //					{
                    //						BeforeUpdate(e.Row);
                    //					}
                    //					catch(Exception exc1)
                    //					{
                    //						e.Row.RowError+=exc1.Message;
                    //					}
                    break;
            }
        }

        protected void RowChangedEventHandler(object sender, System.Data.DataRowChangeEventArgs e)
        {

            if (myMngr.isMerging || isFilling || isInEvent)
            {
                return;
            }
            isInEvent = true;
            try
            {

                switch (e.Action)
                {
                    case DataRowAction.Add:
                        if (e.Row.Table.Columns.Contains("entryDate"))
                        {
                            e.Row.BeginEdit();
                            e.Row["entryDate"] = DateTime.Now.ToUniversalTime();
                            if (myUser.Length > 20)
                            {
                                e.Row["entryUser"] = myUser.Substring(myUser.Length - 20, 20);
                                e.Row["updateUser"] = myUser.Substring(myUser.Length - 20, 20);
                            }
                            else
                            {
                                e.Row["entryUser"] = myUser;
                                e.Row["updateUser"] = myUser;
                            }
                            if (!myMngr.isMerging)
                                e.Row["updateDate"] = DateTime.Now.ToUniversalTime();
                            e.Row.EndEdit();
                        }
                        AfterAdd(e.Row);
                        if (myMngr.RuleHandler != null)
                            myMngr.RuleHandler.DynAfterAdd(myMngr, e.Row, myDefinition);
                        break;
                    case DataRowAction.Delete:
                        AfterDelete(e.Row);
                        if (myMngr.RuleHandler != null)
                            myMngr.RuleHandler.DynAfterDelete(myMngr, e.Row, myDefinition);
                        break;
                    case DataRowAction.Change:
                        if (!this.IsColumnChangeMode)
                        {

                            //						foreach(DataColumn dc in myDT.Columns)
                            //						{	
                            //							if(e.Row.RowState==DataRowState.Added)
                            //							{
                            //								//this accounts for after change events that make calculations
                            //								//it does not catch things if the value is set to null
                            //								if(!e.Row.IsNull(dc))
                            //									AfterChange(dc,e.Row);
                            //							}
                            //							else
                            //							{
                            //
                            //								if(e.Row.HasVersion(DataRowVersion.Original))
                            //								{
                            //									if(!e.Row[dc,DataRowVersion.Current].Equals(e.Row[dc,DataRowVersion.Original]))
                            //									{
                            //										AfterChange(dc,e.Row);
                            //									}
                            //								}
                            //							}
                            //						}
                            //if(e.Row.Table.Columns.Contains("entryDate"))
                            //{
                            //    e.Row.BeginEdit();
                            //    e.Row["updateDate"]=DateTime.Now;
                            //    e.Row["updateUser"] = myUser;
                            //    e.Row.EndEdit();
                            //}
                        }

                        //						AfterUpdate(e.Row);
                        break;

                }
            }
            catch (Exception exc)
            {
                e.Row.RowError += exc.Message;
                System.Diagnostics.Debug.WriteLine(exc.Message);
            }
            finally
            {
                if (e.Row.HasErrors)
                {
                    foreach (DataColumn dc in e.Row.GetColumnsInError())
                    {
                        //e.Row[dc]=e.Row[dc,DataRowVersion.Original];
                    }
                }
                isInEvent = false;
            }
        }



        protected internal virtual void BeforeChange(DataColumn dc, DataRow dr)
        {
           
        }

        protected internal void BeforeChange(string columnName, DataRow dr)
        {
            BeforeChange(dr.Table.Columns[columnName], dr);
        }

        protected internal virtual void AfterChange(DataColumn dc, DataRow dr)
        { }

        protected internal virtual void BeforeAdd(DataRow dr)
        { }

        protected internal virtual void AfterAdd(DataRow dr)
        { }

        protected internal virtual void BeforeDelete(DataRow dr)
        { }

        protected internal virtual void AfterDelete(DataRow dr)
        { }

        protected internal virtual void BeforeUpdate(DataRow dr)
        {
            
        }
        public virtual void Validate(DataRow dr)
        {

        }
        protected internal void Validate(string columnName, DataRow dr)
        {
            try
            {
                BeforeChange(dr.Table.Columns[columnName], dr);
                dr.SetColumnError(columnName, "");
            }
            catch(Exception x)
            {
                dr.SetColumnError(columnName, x.Message);
            }
        }
        protected internal virtual void AfterUpdate(DataRow dr)
        { }

        public virtual DataRow[] GetCurrentRow()
        {
            if (myDT.Rows.Count > 0)
                return myDT.Select();
            else
                return null;
        }

        //public virtual DataRow[] GetCurrentRow(DataRow dr)
        //{
        //    if (myDT.Rows.Count > 0)
        //        return myDT.Select();
        //    else
        //        return null;
        //}

        //public virtual DataRow[] GetParentRow()
        //{ return null; }

        public virtual string PromptColumnName()
        {
            return myDT.PrimaryKey[0].ColumnName;
        }
        public virtual string PromptFormat()
        {
            return null;
        }

        public virtual string FriendlyName()
        {
            return myDT.TableName;
        }

        public virtual string BestFKName()
        {
            return "FileId";
        }

        public virtual bool CanEdit(DataRow dr)
        {
            return true;
        }

        public virtual bool CanAdd(DataRow parent)
        {
            return true;
        }

        public virtual bool CanDelete(DataRow dr)
        {
            return true;
        }

        public virtual bool CanRead(DataRow dr)
        {
            return true;
        }

        //public virtual void FixLookups(DataRow dr)
        //{ }



        private void RowUpdating(DataRow r)
        {
            try
            {
                if (r.RowState == DataRowState.Modified && !CanEdit(r))
                    throw new ReadOnlyException();

                if (r.RowState != DataRowState.Deleted)
                {
                    BeforeUpdate(r);
                    if (myMngr.RuleHandler != null)
                        myMngr.RuleHandler.DynBeforeUpdate(myMngr, r, myDefinition,columnMap);

                    if (r.Table.Columns.Contains("entryDate"))
                    {
                        r.BeginEdit();
                        if (myUser.Length > 20)
                        {

                            r["updateUser"] = myUser.Substring(myUser.Length - 20, 20);
                        }
                        else
                        {

                            r["updateUser"] = myUser;
                        }
                        if (!myMngr.isMerging)
                            r["updateDate"] = DateTime.Now.ToUniversalTime();
                        r.EndEdit();
                    }


                }
            }
            catch (Exception exc1)
            {

                //e.Status=UpdateStatus.SkipCurrentRow;
                //do we need errors on the row? - they 
                //hard to determine if they need 
                //clearing
                // r.RowError+=exc1.Message;
                throw new Exception(exc1.Message + "\r\n on " + r.Table.TableName + " at pkid=" + r[r.Table.PrimaryKey[0]].ToString(), exc1);
            }


        }

        public virtual System.Collections.Generic.List<int> Accounts(int id)
        {
            return new System.Collections.Generic.List<int>();
        }
        private void RowUpdated(DataRow r)
        {
            if (r.RowState != DataRowState.Deleted)
            {
                AfterUpdate(r);
                if (myMngr.RuleHandler != null)
                    myMngr.RuleHandler.DynAfterUpdate(myMngr, r, myDefinition);

            }
        }

        /// <summary>
        /// Returns a string that lists all the row and column errors currently in the datatable
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public string ErrorsForTable(DataTable dt)
        {
            string err = "";
            if (dt.HasErrors)
            {
                foreach (DataRow dr in dt.GetErrors())
                {
                    err += String.Format("{0} Row Error: {1}\n\r", dt.TableName, dr.RowError);
                    foreach (DataColumn dc in dr.GetColumnsInError())
                    {
                        err += String.Format("Column {0} error: {1}\n\r", dc.ColumnName, dr.GetColumnError(dc));
                    }
                }
            }
            return err;

        }
        #region IDisposable Members

        // Implement IDisposable.
        // Do not make this method virtual.
        // A derived class should not be able to override this method.
        public void Dispose()
        {
            Dispose(true);
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue 
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        // Dispose(bool disposing) executes in two distinct scenarios.
        // If disposing equals true, the method has been called directly
        // or indirectly by a user's code. Managed and unmanaged resources
        // can be disposed.
        // If disposing equals false, the method has been called by the 
        // runtime from inside the finalizer and you should not reference 
        // other objects. Only unmanaged resources can be disposed.
        private void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.isDisposed)
            {
                // If disposing equals true, dispose all managed 
                // and unmanaged resources.
                if (disposing)
                {
                    OnUpdate = null;

                    // Dispose managed resources.
                    //myODAL.Dispose();
                    //if (pulse != null)
                    //{
                    //    if (pulse!=null) pulse.Elapsed -= pulseHndl;
                    //    if (pulse != null) pulse.Stop();
                    //    if (pulse != null) pulse.Enabled = false;

                    //    if (pulse != null) pulse.Dispose();
                    //    pulse = null;
                    //}

                    if (myDT != null)
                    {
                        //disconnect all events
                        if (myDT != null) myDT.RowChanging -= new DataRowChangeEventHandler(RowChangingEventHandler);
                        if (myDT != null) myDT.RowChanged -= new DataRowChangeEventHandler(RowChangedEventHandler);
                        if (myDT != null) myDT.RowDeleting -= new DataRowChangeEventHandler(RowChangingEventHandler);
                        if (myDT != null) myDT.RowDeleted -= new DataRowChangeEventHandler(RowChangedEventHandler);

                        if (this.IsColumnChangeMode)
                        {
                            if (myDT != null) myDT.ColumnChanging -= new DataColumnChangeEventHandler(ColumnChangingEventHandler);
                            if (myDT != null) myDT.ColumnChanged -= new DataColumnChangeEventHandler(ColumnChangedEventHandler);
                        }

                        if (myDT != null) myDT.ExtendedProperties.Clear();
                        myDT = null;
                    }
                    myMngr = null;
                }

            }
            isDisposed = true;
        }

        ~ObjectBE()
        {
            Dispose(false);
        }
        #endregion

    }
}
