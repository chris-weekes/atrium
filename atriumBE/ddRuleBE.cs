using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
    /// <summary>
    /// 
    /// </summary>
    public class ddRuleBE : atLogic.ObjectBE, atLogic.IRuleHandler
    {
        atriumManager myA;
        appDB.ddRuleDataTable myddRuleDT;

        public DataTable dtEvents;

        public DataTable dtRuleTypes;

        Dictionary<string, ICodeRule> myCodeRules = new Dictionary<string, ICodeRule>();
        Dictionary<string, ICodeAction> myCodeActions = new Dictionary<string, ICodeAction>();

        internal ddRuleBE(atriumManager pBEMng)
            : base(pBEMng, pBEMng.DB.ddRule)
        {
            myA = pBEMng;
            myddRuleDT = (appDB.ddRuleDataTable)myDT;

            dtEvents = new DataTable("dtEvents");
            dtEvents.Columns.Add("Id", typeof(int));
            dtEvents.Columns.Add("Text", typeof(string));
            dtEvents.Rows.Add(1, "Before Change");
            dtEvents.Rows.Add(2, "Before Update");
            dtEvents.Rows.Add(3, "Before Delete");
            dtEvents.Rows.Add(4, "After Add");
            dtEvents.Rows.Add(5, "Before Save New record");
            dtEvents.Rows.Add(6, "Before Add*");
            dtEvents.Rows.Add(7, "After Change");
            dtEvents.Rows.Add(8, "After Update*");
            dtEvents.Rows.Add(9, "After Delete*");
            dtEvents.Rows.Add(10, "Before Change and Update");

            dtRuleTypes = new DataTable("dtRuleTypes");
            dtRuleTypes.Columns.Add("Id", typeof(int));
            dtRuleTypes.Columns.Add("Text", typeof(string));
            dtRuleTypes.Rows.Add(0, "Program Rule");
            dtRuleTypes.Rows.Add(1, "Required");
            dtRuleTypes.Rows.Add(2, "W/F Rule");
            dtRuleTypes.Rows.Add(3, "Domain");
            dtRuleTypes.Rows.Add(4, "Pre-req field");
            dtRuleTypes.Rows.Add(5, "Domain(old)");
            dtRuleTypes.Rows.Add(6, "Valid Date");
            dtRuleTypes.Rows.Add(7, "Numeric Range");
            dtRuleTypes.Rows.Add(8, "String length range");
            dtRuleTypes.Rows.Add(99, "W/F Action");
            dtRuleTypes.Rows.Add(100, "Action Program");

            //load all rule singletons
            var instances = from t in System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                            where t.GetInterfaces().Contains(typeof(ICodeRule))
                                     && t.GetConstructor(Type.EmptyTypes) != null
                            select Activator.CreateInstance(t) as ICodeRule;

            foreach (var instance in instances)
            {
                myCodeRules.Add(instance.GetType().ToString(), instance);
            }

            var actions = from t in System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                            where t.GetInterfaces().Contains(typeof(ICodeAction))
                                     && t.GetConstructor(Type.EmptyTypes) != null
                        select Activator.CreateInstance(t) as ICodeAction;

            foreach (var instance in actions)
            {
                myCodeActions.Add(instance.GetType().ToString(), instance);
            }
        }



        protected override void AfterAdd(DataRow dr)
        {
            appDB.ddRuleRow dtr = (appDB.ddRuleRow)dr;
            string ObjectName = this.myddRuleDT.TableName;

            dtr.RuleId = this.myA.PKIDGet(ObjectName, 1);
            dtr.Enabled = false;
            if (dtr.ddFieldRow != null)
                dtr.TableId = dtr.ddFieldRow.TableId;


        }


        public void DynBeforeChange(BEManager be, DataColumn dc, DataRow dr, Dictionary<string, appDB.ddFieldRow> ruleColumnMap)
        {

            //find row in ddfield
            if (ruleColumnMap.ContainsKey(dc.ColumnName))
            {
                FileManager fm = GetFMFromBE(be);

                appDB.ddFieldRow dfr = ruleColumnMap[dc.ColumnName];
                //find rules for field 
                foreach (appDB.ddRuleRow ddr in dfr.GetddRuleRows())
                {
                    //for "beforechange" event
                    if ((ddr.EventId == 1 | ddr.EventId == 10) && ddr.Enabled)
                    {
                        //check rules
                        RunRule(dc, dr, ruleColumnMap, fm, dfr, ddr);
                    }
                }
            }
        }


        public void DynBeforeUpdate(BEManager be, DataRow dr, appDB.ddTableRow ruleDefinition, Dictionary<string, appDB.ddFieldRow> ruleColumnMap)
        {

            if (ruleDefinition == null)
                return;

            FileManager fm = GetFMFromBE(be);

            foreach (appDB.ddRuleRow ddr in ruleDefinition.GetddRuleRows())
            {
                //for "beforeupdate" event
                if (ddr.EventId == 2 && ddr.Enabled)
                {
                    //check rules
                    RunRule(null, dr, null, fm, null, ddr);

                }
                if (ddr.EventId == 10 && ddr.Enabled)
                {
                    //check rules
                    //needs to run for column
                    //need columnmap
                    DataColumn dc=dr.Table.Columns[ ddr.ddFieldRow.DBFieldName];
                    appDB.ddFieldRow dfr = ruleColumnMap[dc.ColumnName];
                    RunRule(dc, dr, ruleColumnMap, fm, dfr, ddr);

                }
                if (ddr.EventId == 5 && ddr.Enabled && dr.RowState == DataRowState.Added)
                {
                    //check rules
                    RunRule(null, dr, null, fm, null, ddr);

                }
            }
        }
        public void DynBeforeDelete(BEManager be, DataRow dr, appDB.ddTableRow ruleDefinition)
        {
            if (ruleDefinition == null)
                return;

            FileManager fm = GetFMFromBE(be);

            //find rules for field 
            foreach (appDB.ddRuleRow ddr in ruleDefinition.GetddRuleRows())
            {
                //for "beforedelete" event
                if (ddr.EventId == 3 && ddr.Enabled)
                {
                    //check rules
                    RunRule(null, dr, null, fm, null, ddr);

                }
            }
        }
        public void DynAfterAdd(BEManager be, DataRow dr, appDB.ddTableRow ruleDefinition)
        {
            if (ruleDefinition == null)
                return;

            FileManager fm = GetFMFromBE(be);
            
            //set defaults
            myA.GetddField().DynDefaultValues(fm, dr, ruleDefinition);

            foreach (appDB.ddRuleRow ddr in ruleDefinition.GetddRuleRows())
            {
                //for "beforeupdate" event
                if (ddr.EventId == 4 && ddr.Enabled)
                {
                    //check rules
                    RunRule(null, dr, null, fm, null, ddr);

                }
            }
        }


        public void DynAfterUpdate(BEManager be, DataRow dr, appDB.ddTableRow ruleDefinition)
        {
            if (ruleDefinition == null)
                return;

            //rarely used except for toc  xml which is obsolete
            FileManager fm = GetFMFromBE(be);

            //find rules for field 
            foreach (appDB.ddRuleRow ddr in ruleDefinition.GetddRuleRows())
            {
                //for "afterupdate" event
                if (ddr.EventId == 8 && ddr.Enabled)
                {
                    //check rules
                    RunRule(null, dr, null, fm, null, ddr);

                }
            }
        }

        public void DynAfterChange(BEManager be, DataColumn dc, DataRow dr, Dictionary<string, appDB.ddFieldRow> ruleColumnMap)
        {
            //used for calculating values
            //find row in ddfield
            if (ruleColumnMap.ContainsKey(dc.ColumnName))
            {
                FileManager fm = GetFMFromBE(be);

                appDB.ddFieldRow dfr = ruleColumnMap[dc.ColumnName];
                //find rules for field 
                foreach (appDB.ddRuleRow ddr in dfr.GetddRuleRows())
                {
                    //for "afterchange" event
                    if (ddr.EventId == 7 && ddr.Enabled)
                    {
                        //check rules
                        RunRule(dc, dr, ruleColumnMap, fm, dfr, ddr);

                    }
                }
            }

        }

        public void DynBeforeAdd(BEManager be, DataRow dr, appDB.ddTableRow ruleDefinition)
        {
            if (ruleDefinition == null)
                return;

            //rarely or never used
        }

        public void DynAfterDelete(BEManager be, DataRow dr, appDB.ddTableRow ruleDefinition)
        {
            if (ruleDefinition == null)
                return;

            //never used as the record is effectively gone
        }

        private void RunRule(DataColumn columnToCheck, DataRow rowToCheck, Dictionary<string, appDB.ddFieldRow> ruleColumnMap, FileManager fm, appDB.ddFieldRow fieldDefinition, appDB.ddRuleRow ruleToRun)
        {
            string Left = "Left" + myA.AppMan.Language;

            switch (ruleToRun.RuleTypeId)
            {
                case 0://code based
                    ExecuteCodeRule(columnToCheck, rowToCheck, fm, ruleToRun);
                    break;
                case 1://required
                    if (rowToCheck.IsNull(columnToCheck))
                        throw new RequiredException(fieldDefinition[Left].ToString());
                    break;
                case 2://acseries based
                    EvaluateRule(fm, ruleToRun, rowToCheck);
                    break;
                case 3://domain
                    if (!rowToCheck.IsNull(columnToCheck))
                    {
                        if (!fm.Codes(ruleToRun.Val1).Rows.Contains(rowToCheck[columnToCheck]))
                            throw new AtriumException(atriumBE.Properties.Resources.IsNotValid, fieldDefinition[Left].ToString());
                    }
                    break;
                case 4://related - must be field on same record
                    if (rowToCheck.IsNull(ruleToRun.Val1))
                        throw new RelatedException(fieldDefinition.LeftEng, ruleColumnMap[ruleToRun.Val1][Left].ToString());

                    break;
                case 5://old domain check
                    if (!rowToCheck.IsNull(columnToCheck))
                    {
                        if (!myA.CheckDomain(rowToCheck[columnToCheck].ToString(), fm.Codes(ruleToRun.Val1)))
                            throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, fieldDefinition[Left].ToString(), fieldDefinition.ddTableRow["Description" + myA.AppMan.Language].ToString(), ruleToRun.Val1);
                    }
                    break;
                case 6://valid date 
                    if (!rowToCheck.IsNull(columnToCheck))
                    {
                        DateTime beginDate;
                        DateTime endDate;
                        DateTime dateValue = (DateTime)rowToCheck[columnToCheck];
                        string name1 = ruleToRun.Val1;
                        string name2 = ruleToRun.Val2;

                        if (ruleColumnMap.ContainsKey(ruleToRun.Val1))
                        {
                            beginDate = (DateTime)rowToCheck[ruleColumnMap[ruleToRun.Val1].DBFieldName];
                            name1 = ruleColumnMap[ruleToRun.Val1][Left].ToString();
                        }
                        else
                            beginDate = (DateTime)fm.GetDefaultValue(ruleToRun.Val1);

                        if (ruleColumnMap.ContainsKey(ruleToRun.Val2))
                        {
                            endDate = (DateTime)rowToCheck[ruleColumnMap[ruleToRun.Val1].DBFieldName];
                            name2 = ruleColumnMap[ruleToRun.Val2][Left].ToString();
                        }
                        else
                            endDate = (DateTime)fm.GetDefaultValue(ruleToRun.Val2);


                        if (dateValue < beginDate || dateValue > endDate)
                            throw new DateBetweenException(fieldDefinition[Left].ToString(), name1, beginDate.ToShortDateString(), name2, endDate.ToShortDateString());

                    }
                    break;
                case 7://numeric range
                    if (!rowToCheck.IsNull(columnToCheck))
                    {
                        int v1, v2, thisVal;
                        if (ruleColumnMap.ContainsKey(ruleToRun.Val1))
                            v1 =  System.Convert.ToInt32(rowToCheck[ruleColumnMap[ruleToRun.Val1].DBFieldName]);
                        else
                            v1 = System.Convert.ToInt32(fm.GetDefaultValue(ruleToRun.Val1));

                        if (ruleColumnMap.ContainsKey(ruleToRun.Val2))
                            v2 = System.Convert.ToInt32(rowToCheck[ruleColumnMap[ruleToRun.Val1].DBFieldName]);
                        else
                            v2 =  System.Convert.ToInt32(fm.GetDefaultValue(ruleToRun.Val2));

                        thisVal = System.Convert.ToInt32(rowToCheck[columnToCheck]);

                        if (thisVal < v1 || thisVal > v2)
                            throw new AtriumException("Outside numeric range");

                    }
                    break;
                case 8://string length range
                    if (!rowToCheck.IsNull(columnToCheck))
                    {
                        int v1, v2, thisVal;
                        if (ruleColumnMap.ContainsKey(ruleToRun.Val1))
                            v1 = (int)rowToCheck[ruleColumnMap[ruleToRun.Val1].DBFieldName];
                        else
                            v1 = (int)fm.GetDefaultValue(ruleToRun.Val1);

                        if (ruleColumnMap.ContainsKey(ruleToRun.Val2))
                            v2 = (int)rowToCheck[ruleColumnMap[ruleToRun.Val1].DBFieldName];
                        else
                            v2 = (int)fm.GetDefaultValue(ruleToRun.Val2);

                        thisVal = rowToCheck[columnToCheck].ToString().Length;

                        if (thisVal < v1 || thisVal > v2)
                            throw new AtriumException("Length out of range");

                    }
                    break;
                case 99://action
                    if (!ruleToRun.IsACSeriesIdNull())
                        ExecuteAction(fm, ruleToRun, rowToCheck);
                    break;
                case 100://action program
                    ExecuteCodeAction(columnToCheck, rowToCheck, fm, ruleToRun);
                    break;
                default:
                    throw new AtriumException("Not a valid rule");
            }
        }

        private void ExecuteCodeRule(DataColumn columnToCheck, DataRow rowToCheck, FileManager fm, appDB.ddRuleRow ruleToRun)
        {

            string msg = "";
            if(!ruleToRun.IsMsgIdNull())
                msg = myA.acMng.DB.ACDocumentation.FindByACDocId(ruleToRun.MsgId)[myA.Translate("TextEng")].ToString();
            
            myCodeRules[ruleToRun.Val1].ExecuteRule(fm, ruleToRun, rowToCheck, columnToCheck,msg);
          
        }

        private void ExecuteCodeAction(DataColumn columnToCheck, DataRow rowToCheck, FileManager fm, appDB.ddRuleRow ruleToRun)
        {
                       

            myCodeActions[ruleToRun.Val1].ExecuteRule(fm, ruleToRun, rowToCheck, columnToCheck);

        }

        public void ExecuteAction(FileManager fm, appDB.ddRuleRow ddrr, DataRow dr2Validate)
        {
            //can't handle document right now
            //can't have associated data

            ActivityConfig.ACSeriesRow acsr = myA.acMng.DB.ACSeries.FindByACSeriesId(ddrr.ACSeriesId);
            ExecuteAction(fm, dr2Validate, acsr);
        }

        public void ExecuteAction(FileManager fm, DataRow dr2Validate, ActivityConfig.ACSeriesRow acsr)
        {
            dr2Validate.EndEdit();

            ACEngine MyACE = new ACEngine(fm);
            MyACE.myAcSeries = acsr;
            MyACE.myActivityCode = acsr.ActivityCodeRow;

            MyACE.AddToRelTables(dr2Validate, "CONTEXT");

            MyACE.DoRelFields();
            if (MyACE.HasRel0)
                MyACE.DoStep(ACEngine.Step.RelatedFields0, true);
            if (MyACE.HasRel1)
                MyACE.DoStep(ACEngine.Step.RelatedFields1, true);
            if (MyACE.HasRel2)
                MyACE.DoStep(ACEngine.Step.RelatedFields2, true);
            if (MyACE.HasRel3)
                MyACE.DoStep(ACEngine.Step.RelatedFields3, true);
            if (MyACE.HasRel4)
                MyACE.DoStep(ACEngine.Step.RelatedFields4, true);
            if (MyACE.HasRel5)
                MyACE.DoStep(ACEngine.Step.RelatedFields5, true);
            if (MyACE.HasRel6)
                MyACE.DoStep(ACEngine.Step.RelatedFields6, true);
            if (MyACE.HasRel7)
                MyACE.DoStep(ACEngine.Step.RelatedFields7, true);
            if (MyACE.HasRel8)
                MyACE.DoStep(ACEngine.Step.RelatedFields8, true);
            if (MyACE.HasRel9)
                MyACE.DoStep(ACEngine.Step.RelatedFields9, true);
            if (MyACE.HasTimeline)
                MyACE.DoStep(ACEngine.Step.Timeline, true);
            //if (MyACE.HasDoc)
            //{
            //    docDB.DocumentRow dr = (docDB.DocumentRow)MyACE.relTables["Document0"][0].Row;

            //    MyACE.DocumentDefaults(0 != 0);

            //}
            if (MyACE.HasBilling)
                MyACE.DoStep(ACEngine.Step.Billing, true);

        }


        //rules
        public void EvaluateRule(FileManager fm, appDB.ddRuleRow ddrr, DataRow dr2Validate)
        {


            ActivityConfig.ACSeriesRow acsr = fm.AtMng.acMng.DB.ACSeries.FindByACSeriesId(ddrr.ACSeriesId);

            //we need to endedit on the current record so that it can be evaluated by datatable.select operations
            dr2Validate.EndEdit();

            ACEngine MyACE = new ACEngine(fm);
            MyACE.myAcSeries = acsr;
            MyACE.myActivityCode = acsr.ActivityCodeRow;

            MyACE.AddToRelTables(dr2Validate, "CONTEXT");

            //MyACE.LoadDataForStep(-10, acsr.ACSeriesId);
            MyACE.DoRelFields();
            //consider the blocks as short-circuited or's
            //eg  A || B || C
            //we succeed on the first successful block


            if (MyACE.HasRel0)
            {
                MyACE.LoadDataForStep(0, acsr.ACSeriesId);
                if (!MyACE.skipBlock)
                    return;
            }
            if (MyACE.HasRel1)
            {
                MyACE.LoadDataForStep(1, acsr.ACSeriesId);
                if (!MyACE.skipBlock)
                    return;
            }
            if (MyACE.HasRel2)
            {
                MyACE.LoadDataForStep(2, acsr.ACSeriesId);
                if (!MyACE.skipBlock)
                    return;
            }
            if (MyACE.HasRel3)
            {
                MyACE.LoadDataForStep(3, acsr.ACSeriesId);
                if (!MyACE.skipBlock)
                    return;
            }
            if (MyACE.HasRel4)
            {
                MyACE.LoadDataForStep(4, acsr.ACSeriesId);
                if (!MyACE.skipBlock)
                    return;
            }
            if (MyACE.HasRel5)
            {
                MyACE.LoadDataForStep(5, acsr.ACSeriesId);
                if (!MyACE.skipBlock)
                    return;
            }

            //rule failed

            string msg = myA.acMng.DB.ACDocumentation.FindByACDocId(ddrr.MsgId)[myA.Translate("TextEng")].ToString();
            throw new AtriumException(msg);


        }


        private FileManager GetFMFromBE(BEManager be)
        {
            FileManager fm;
            if (be.GetType() == typeof(FileManager))
                fm = (FileManager)be;
            else
                fm = myA.GetFile(be.CurrentFileId);
            return fm;
        }




        public appDB.ddTableRow GetMyDefinition(string entityName)
        {
            DataRow[] drs = myA.DB.ddTable.Select("TableName='" + entityName + "'");
            if (drs.Length == 1)
                return (appDB.ddTableRow)drs[0];
            else
                return null;
        }



    }

    public class testRule : ICodeRule
    {
        public void ExecuteRule(BEManager fm, appDB.ddRuleRow thisRule, DataRow rowToCheck, DataColumn columnToCheck,string msg)
        {
            if (rowToCheck.IsNull(columnToCheck))
                throw new AtriumException(msg);
        }
    }

    public class ContactTypeOncePerFile : ICodeRule
    {
        public void ExecuteRule(BEManager _fm, appDB.ddRuleRow thisRule, DataRow rowToCheck, DataColumn columnToCheck, string msg)
        {
            FileManager fm = (FileManager)_fm;
            atriumDB.FileContactRow dr = (atriumDB.FileContactRow)rowToCheck;
            //if contact type is once per file see if it it on any other records
            bool once = false;
            once = (bool)fm.Codes("ContactType").Select("ContactTypeCode='" + dr.ContactType + "'")[0]["OncePerFile"];
            if (once)
            {
                foreach (atriumDB.FileContactRow fcr1 in dr.Table.Rows)
                {
                    if (!fcr1.IsNull("ContactType") && fcr1.ContactType == dr.ContactType && dr.FileContactid != fcr1.FileContactid)
                        throw new AtriumException(msg, dr.ContactType);
                }
            }
        }
    }

    public class SetPKID : ICodeRule
    {
        public void ExecuteRule(BEManager _fm, appDB.ddRuleRow thisRule, DataRow rowToCheck, DataColumn columnToCheck, string msg)
        {
            FileManager fm = (FileManager)_fm;
            string pkid = rowToCheck.Table.PrimaryKey[0].ColumnName;
            
            int increm = 10;
            if (!thisRule.IsVal2Null())
                increm = System.Convert.ToInt32(thisRule.Val2);
            string objectNm=rowToCheck.Table.TableName;
            if (!thisRule.IsVal1Null())
                objectNm = thisRule.Val1;

            rowToCheck[pkid] = fm.AtMng.PKIDGet(objectNm, increm);
        }
    }
}

