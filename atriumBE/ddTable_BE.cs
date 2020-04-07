using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
    /// <summary>
    /// 
    /// </summary>
    public class ddTableBE : atLogic.ObjectBE
    {
        atriumManager myA;
        appDB.ddTableDataTable myddTableDT;


        internal ddTableBE(atriumManager pBEMng)
            : base(pBEMng, pBEMng.DB.ddTable)
        {
            myA = pBEMng;
            myddTableDT = (appDB.ddTableDataTable)myDT;

            //if (myODAL == null)
            //    myODAL = myA.DALMngr.GetddTable();
        }
        public atriumDAL.ddTableDAL myDAL
        {
            get
            {
                return (atriumDAL.ddTableDAL)myODAL;
            }
        }


     
        protected override void AfterAdd(DataRow dr)
        {
            appDB.ddTableRow dtr = (appDB.ddTableRow)dr;
            string ObjectName = this.myddTableDT.TableName;

            dtr.TableId = this.myA.PKIDGet(ObjectName, 1);
            dtr.TableName = "New Table";
            dtr.isLookup = false;
            dtr.isDBTable = false;
            dtr.AllowInRelatedFields = true;
            dtr.isDynamic = false;
            dtr.ShowInTOC = false;

        }

        protected override void AfterChange(DataColumn dc, DataRow dr)
        {
            appDB.ddTableRow dtr = (appDB.ddTableRow)dr;
            switch (dc.ColumnName)
            {
                case "isDynamic":
                    if (dtr.isDynamic)
                    {
                        dtr.DBTableName = "ddEntity";
                        dtr.tblType = "atriumDB";
                    }
                    else
                    {
                        dtr.DBTableName = dtr.TableName;
                    }
                    dtr.EndEdit();
                    break;
                case "TableName":
                    if (!dtr.isDynamic)
                        dtr.DBTableName = dtr.TableName;
                    break;
            }
        }

        public string CreateSQLView(appDB.ddTableRow dtr)
        {
            string sql = "DROP VIEW dbo.vdde" + dtr.TableName + Environment.NewLine;
            sql += "CREATE VIEW dbo.vdde" + dtr.TableName + Environment.NewLine + "AS SELECT " + Environment.NewLine;

            foreach (appDB.ddFieldRow dfr in dtr.GetddFieldRows())
            {
                if (dfr.AllowInRelatedFields)
                    sql += dfr.DBFieldName + " AS " + dfr.FieldName + ", " + Environment.NewLine;

            }
            sql += "entryUser,entryDate,updateUser,updateDate " + Environment.NewLine;
            sql += "FROM dbo.[ddEntity] " + Environment.NewLine;
            sql += "WHERE tableid=" + dtr.TableId.ToString() + Environment.NewLine;
            sql += "GO" + Environment.NewLine;
            sql += "GRANT SELECT ON dbo.vdde" + dtr.TableName + " TO LAWMATEINTERNAL";

            return sql;
        }
    }
}

