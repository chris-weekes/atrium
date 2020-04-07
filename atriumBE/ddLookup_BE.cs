using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
    /// <summary>
    /// 
    /// </summary>
    public class ddLookupBE : atLogic.ObjectBE
    {
        atriumManager myA;
        appDB.ddLookupDataTable myddLookupDT;


        internal ddLookupBE(atriumManager pBEMng)
            : base(pBEMng, pBEMng.DB.ddLookup)
        {
            myA = pBEMng;
            myddLookupDT = (appDB.ddLookupDataTable)myDT;
            //if (myODAL == null)
            //    myODAL = myA.DALMngr.GetddLookup();

        }

        public atriumDAL.ddLookupDAL myDAL
        {
            get
            {
                return (atriumDAL.ddLookupDAL)myODAL;
            }
        }

       

     
        protected override void AfterAdd(DataRow row)
        {
            appDB.ddLookupRow dr = (appDB.ddLookupRow)row;
            string ObjectName = this.myddLookupDT.TableName;

            dr.LookupId = myA.PKIDGet(ObjectName, 10);
            dr.LookupType = "GEN";
            dr.Cache = true;
            dr.IncludeObsolete = false;
            dr.UseFileContext = false;
        }

        public DataTable Codes(string name,FileManager fm)
        {
            if (myddLookupDT.Count == 0)
                Load();

            appDB.ddLookupRow[] dlrs = (appDB.ddLookupRow[])myddLookupDT.Select("LookupName='" + name + "'");
            if (dlrs.Length == 1)
            {
                DataTable dtList;
                appDB.ddLookupRow dlr = dlrs[0];

                string sListname = name + myA.AppMan.Language;

                if (dlr.Cache && myA.myColCodes.ContainsKey(sListname))
                    return (DataTable)myA.myColCodes[sListname];

                WhereClause wc = new WhereClause();
                if (dlr.UseFileContext && fm!=null && !fm.IsVirtualFM)
                {
                    wc.Add("Fileid","=", fm.CurrentFileId);
                }
                if (!dlr.IncludeObsolete)
                {
                    wc.Add("Obsolete", "=", 0);
                }
                if (!dlr.IsWhereClauseNull())
                {
                    wc.And(dlr.WhereClause);
                }
                switch (dlr.LookupType)
                {
                    case "SP":
                        if (dlr.UseFileContext && fm != null && !fm.IsVirtualFM)
                        {
                            dtList = myA.AppMan.ExecuteDataset(dlr.Source,fm.CurrentFileId).Tables[0];
                        }
                        else
                            dtList=myA.AppMan.ExecuteDataset(dlr.Source,System.DBNull.Value).Tables[0];
                        break;
                    case "SQL":
                        dtList = myA.GetGeneralRec(dlr.Source);
                        break;
                    case "VIEW":
                    case "TABLE":

                        dtList = myA.GetGeneralRec(dlr.Source, wc);
                  
                        break;
                    case "GEN":
                    default:
                        wc.Add("LookupId", "=", dlr.LookupId);

                        DataView dv = new DataView(myA.DB.ddGeneric, wc.Filter(), "", DataViewRowState.CurrentRows);
                        dtList = dv.ToTable();
                        dtList.Columns.Remove("LookupId");
                        dtList.Columns.Remove("ParentId");
                        dtList.PrimaryKey = new DataColumn[] { dtList.Columns["GenericId"] };
                        //dtList = myA.GetGeneralRec("vddGenericList",wc);
                        break;
                }

                string sort = "";
                if (!dlr.IsSortcolumnsNull())
                    sort = dlr.Sortcolumns;
                else
                    sort = dtList.Columns[0].ColumnName;

                DataView dv1 = new DataView(dtList, "", sort, DataViewRowState.CurrentRows);
                dtList = dv1.ToTable();

                if (dtList.PrimaryKey.Length == 0)
                {
                    if (!dlr.IsPKNameNull())
                    {
                        dtList.PrimaryKey = new DataColumn[] { dtList.Columns[dlr.PKName] };
                    }
                    else
                    {
                        dtList.PrimaryKey = new DataColumn[] { dtList.Columns[0] };
                    }
                }

                if (dlr.Cache)
                    myA.myColCodes.Add(sListname, dtList);

                return dtList;
            }
            else
            {
                throw new AtriumException(name+" is not a valid lookup table");
            }
        }
    }
}

