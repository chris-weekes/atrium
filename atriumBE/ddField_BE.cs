using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class ddFieldBE:atLogic.ObjectBE
	{
		atriumManager myA;
		appDB.ddFieldDataTable myddFieldDT;

		
		internal ddFieldBE(atriumManager pBEMng):base(pBEMng,pBEMng.DB.ddField)
		{
			myA=pBEMng;
			myddFieldDT=(appDB.ddFieldDataTable)myDT;

            //if (myODAL == null)
            //    myODAL = myA.DALMngr.GetddField();
        }
        public atriumDAL.ddFieldDAL myDAL
        {
            get
            {
                return (atriumDAL.ddFieldDAL)myODAL;
            }
        }


    

        protected override void AfterAdd(DataRow dr)
        {
            appDB.ddFieldRow dtr = (appDB.ddFieldRow)dr;
            string ObjectName = this.myddFieldDT.TableName;

            dtr.FieldId = this.myA.PKIDGet(ObjectName, 1);
            dtr.FieldName = "New Field";
            dtr.AllowInRelatedFields = true;
            dtr.isFromView = false;
            dtr.isVirtualColumn = false;
            dtr.isMissing = false;
            
        }

        protected override void AfterChange(DataColumn dc, DataRow dr)
        {
            appDB.ddFieldRow dtr = (appDB.ddFieldRow)dr;
            switch(dc.ColumnName)
            {
                case "FieldName":
                    if (!dtr.ddTableRow.isDynamic)
                        dtr.DBFieldName = dtr.FieldName;

                    break;
            }
        }
        public void Populate(appDB.ddTableRow drTable)
        {
            DataTable dtTyped = null;
            try
            {
                atLogic.BEManager mngr = myA.GetFile(0).GetBEMngrForTable(drTable.DBTableName);
                dtTyped=mngr.MyDS.Tables[drTable.DBTableName];
            }
            catch(Exception x)
            {
                //ignore
            }

            DataTable dtViews=myA.GetGeneralRec("select * from information_schema.columns where table_schema='dbo' and table_name='v"+ drTable.DBTableName +"' ");
            DataTable dtTable = myA.GetGeneralRec("select * from information_schema.columns where table_schema='dbo' and table_name='" + drTable.DBTableName + "' ");

            if (dtTable.Rows.Count == 0)
                drTable.isDBTable = false;
            else
                drTable.isDBTable = true;

            if (dtTyped != null)
            {
                foreach (DataColumn dc in dtTyped.Columns)
                {
                    appDB.ddFieldRow drField;
                    if (myA.DB.ddField.Select("Tableid=" + drTable.TableId.ToString() + " and DBFieldName='" + dc.ColumnName + "'").Length == 0)
                    {
                        drField = (appDB.ddFieldRow)Add(drTable);
                        drField.FieldName = dc.ColumnName;
                        drField.DBFieldName = dc.ColumnName;
                        if (drTable.isDynamic)
                            drField.AllowInRelatedFields = false;
                    }
                    else
                    {
                        drField =(appDB.ddFieldRow) myA.DB.ddField.Select("Tableid=" + drTable.TableId.ToString() + " and DBFieldName='" + dc.ColumnName + "'")[0];
                    }
                    drField.isMissing = true;
                    drField.DataType = dc.DataType.Name;

                    if (drField.IsLeftEngNull())
                    {
                        drField.LeftEng =SplitCamelCase( drField.FieldName);
                        drField.LeftFre =SplitCamelCase( drField.FieldName);
                    }

                    if (dtViews.Select("Column_name='" + dc.ColumnName + "'", "").Length == 0)
                    {
                        drField.isVirtualColumn = true;
                    }
                    else
                    {
                        drField.isMissing = false; 
                        drField.isVirtualColumn = false;
                    }

                    if (!drField.isVirtualColumn && dtTable.Select("Column_name='" + dc.ColumnName + "'", "").Length == 0)
                    {
                        drField.isFromView = true;
                    }
                    else
                    {
                        drField.isMissing = false; 
                        drField.isFromView = false;
                    }
                    
                }

                //check for "obsolete" columns
                foreach (appDB.ddFieldRow drf in drTable.GetddFieldRows())
                {
                    if(!dtTyped.Columns.Contains(drf.DBFieldName))
                    {
                        drf.AllowInRelatedFields = false;
                        drf.DescEng = "OBSOLETE";
                    }
                }
            }
            else
            {
                foreach (DataRow dr in dtViews.Rows)
                {
                    if (myA.DB.ddField.Select("Tableid=" + drTable.TableId.ToString() + " and DBFieldName='" + dr["Column_name"].ToString() + "'").Length == 0)
                    {
                        appDB.ddFieldRow drField = (appDB.ddFieldRow)Add(drTable);
                        drField.FieldName = dr["Column_name"].ToString();

                        if (dtTable.Select("Column_name='" + drField.FieldName + "'", "").Length == 0)
                        {
                            drField.isFromView = true;
                            drField.isMissing = false; 

                        }
                    }
                }
            }
        }

        public static string SplitCamelCase(string input)
        {
            string newstring = "";
            bool mutli = false;
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsUpper(input[i]) &!mutli)
                {
                    mutli = true;
                    newstring += " ";
                }
                else
                {
                    mutli = false;
                }
                newstring += input[i].ToString();
            }

            return newstring.Trim();
        }

        public void DynDefaultValues(FileManager fm, DataRow dr, appDB.ddTableRow myDefinition)
        {
            //check for defined fields that have a systemdefault value
            foreach (appDB.ddFieldRow dfr in myDefinition.GetddFieldRows())
            {
                if (!dfr.IsDefaultSystemValueNull())
                {
                    dr[dfr.DBFieldName] = fm.GetDefaultValue(dfr.DefaultSystemValue);
                }
            }
        }

        public static appDB.ddFieldRow LookupDDFieldRow(atriumManager atmng, string table, string field)
        {
            appDB.ddFieldRow returnDDField = null;
            appDB.ddFieldRow[] ddFields = (appDB.ddFieldRow[])atmng.DB.ddField.Select("tablename='" + table + "' and fieldname='" + field + "'", "");
            if (ddFields.Length > 0)
                returnDDField = ddFields[0];

            return returnDDField;
        }

        public static string LookupDDFieldLabel(atriumManager atmng, int fieldID)
        {
            string returnLabel = "";
            appDB.ddFieldRow[] ddFields = (appDB.ddFieldRow[])atmng.DB.ddField.Select("fieldid=" + fieldID, "");
            if (ddFields.Length > 0 && !ddFields[0].IsLeftEngNull())
                returnLabel = ddFields[0].LeftEng;
            if (atmng.AppMan.Language.ToUpper() == "FRE" && !ddFields[0].IsLeftFreNull())
                returnLabel = ddFields[0].LeftFre;

            return returnLabel;
        }


	}

}

