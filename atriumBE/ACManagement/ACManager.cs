using System;
using System.Collections.Generic;
using System.Text;
using lmDatasets;

namespace atriumBE
{
    public class ACManager : atLogic.BEManager
    {
        
        atriumManager myatMng;

        public atriumManager AtMng
        {
            get { return myatMng; }
            set { myatMng = value; }
        }

        ACBFBE myACBF;
        ACDocumentationBE myACDocumentation;
        ACConvertBE myACConvert;
        ACDependencyBE myACDependency;
        ACDisbBE myACDisb;
        ACSeriesBE myACSeries;
        ActivityFieldBE myActivityField;
        ActivityCodeBE myActivityCode;
        OfficeMandateBE myOfficeMandateBE;
        SeriesBE mySeries;
        ACFileTypeBE myACFileType;
        ACMenuBE myACMenuBE;
        ACControlTypeBE myACControlType;
        ACDependencyTypeBE myACDependencyType;
        ACTaskTypeBE myACTaskType;
        ACSeriesTypeBE myACSeriesType;
        SeriesStatusBE mySeriesStatus;
        SeriesPackageBE mySeriesPackage;

        private WFValidator myWFValidator;
        public WFValidator GeWFValidator()
        {
            if (myWFValidator == null)
            {
                myWFValidator = new WFValidator(this);
            }

            return myWFValidator;

        }
        private atLogic.ObjectBE myMenu;
        public atLogic.ObjectBE GetMenu()
        {
            if (myMenu == null)
            {
                myMenu = new MenuBE(this);
            }

            return myMenu;

        }
        private atLogic.ObjectBE myACMajor;
        public atLogic.ObjectBE GetACMajor()
        {
            if (myACMajor == null)
            {
                if (myatMng.AppMan.UseService)
                    myACMajor = GetObjectBE(null, DB.ACMajor);
                else
                    myACMajor = this.GetObjectBE(myatMng.DALMngr.GetACMajor(), DB.ACMajor);
            }

            return myACMajor;

        }

        public SeriesPackageBE GetSeriesPackage()
        {

            if (mySeriesPackage == null)
            {
                mySeriesPackage = new SeriesPackageBE(this);
            }

            return mySeriesPackage;
        }

        public SeriesStatusBE GetSeriesStatus()
        {

            if (mySeriesStatus == null)
            {
                mySeriesStatus = new SeriesStatusBE(this);
            }

            return mySeriesStatus;
        }

        public ACSeriesTypeBE GetACSeriesType()
        {

            if (myACSeriesType == null)
            {
                myACSeriesType = new ACSeriesTypeBE(this);
            }

            return myACSeriesType;
        }

        public ACTaskTypeBE GetACTaskType()
        {

            if (myACTaskType == null)
            {
                myACTaskType = new ACTaskTypeBE(this);
            }

            return myACTaskType;
        }

        public ACDependencyTypeBE GetACDependencyType()
        {

            if (myACDependencyType == null)
            {
                myACDependencyType = new ACDependencyTypeBE(this);
            }

            return myACDependencyType;
        }

        public ACControlTypeBE GetACControlType()
        {

            if (myACControlType == null)
            {
                myACControlType = new ACControlTypeBE(this);
            }

            return myACControlType;
        }

        public OfficeMandateBE GetOfficeMandate()
        {

            if (myOfficeMandateBE == null)
            {
                myOfficeMandateBE = new OfficeMandateBE(this);
            }

            return myOfficeMandateBE;
        }
        public ACDocumentationBE GetACDocumentation()
        {

            if (myACDocumentation == null)
            {
                myACDocumentation = new ACDocumentationBE(this);
            }

            return myACDocumentation;
        }
        public ACFileTypeBE GetACFileType()
        {

            if (myACFileType == null)
            {
                myACFileType = new ACFileTypeBE(this);
            }

            return myACFileType;
        }
        public ACMenuBE GetACMenu()
        {

            if (myACMenuBE == null)
            {
                myACMenuBE = new ACMenuBE(this);
            }

            return myACMenuBE;
        }


        public ACBFBE GetACBF()
        {

            if (myACBF == null)
            {
                myACBF = new ACBFBE(this);
            }

            return myACBF;
        }
        public ACConvertBE GetACConvert()
        {

            if (myACConvert == null)
            {
                myACConvert = new ACConvertBE(this);
            }

            return myACConvert;
        }

        public ACDependencyBE GetACDependency()
        {

            if (myACDependency == null)
            {
                myACDependency = new ACDependencyBE(this);
            }

            return myACDependency;
        }


        public ACDisbBE GetACDisb()
        {

            if (myACDisb == null)
            {
                myACDisb = new ACDisbBE(this);
            }

            return myACDisb;
        }


        public ACSeriesBE GetACSeries()
        {

            if (myACSeries == null)
            {
                myACSeries = new ACSeriesBE(this);
            }

            return myACSeries;
        }


        public ActivityCodeBE GetActivityCode()
        {

            if (myActivityCode == null)
            {
                myActivityCode = new ActivityCodeBE(this);
            }

            return myActivityCode;
        }


        public ActivityFieldBE GetActivityField()
        {

            if (myActivityField == null)
            {
                myActivityField = new ActivityFieldBE(this);
            }

            return myActivityField;
        }


        public SeriesBE GetSeries()
        {

            if (mySeries == null)
            {
                mySeries = new SeriesBE(this);
            }

            return mySeries;
        }


        public ACManager(atriumManager atMng)
            : base(atMng.AppMan)
        {
            //  cc = atMng.cc;
            //  myDALClient = atMng.myDALClient;
            base.DAL = atMng.DALMngr;
            myatMng = atMng;
            //  myUser = myatMng.myUser;

            MyDS = new ActivityConfig();
            MyDS.EnforceConstraints = false;

        }
        internal atriumDAL.atriumDALManager DALMngr
        {
            get
            {
                return myatMng.DALMngr;
            }
        }

        public ActivityConfig DB
        {
            get
            {
                return (ActivityConfig)MyDS;
            }
        }

        /// <summary>
        /// This method loads all the ac config info
        /// </summary>
        public void LoadAllConfigInfo()
        {
            DB.Clear();
            DB.AcceptChanges();
            System.Data.DataSet ds;
            if (myatMng.AppMan.UseService)
                ds = DecompressDataSet(myatMng.AppMan.AtriumX().LoadACInfo(myatMng.AppMan.AtriumXCon), new lmDatasets.ActivityConfig());
            else
            ds = DecompressDataSet(DALMngr.LoadActivityConfig(),new lmDatasets.ActivityConfig());

            GetMenu().Fill(ds.Tables["Menu"]);
            GetACBF().Fill(ds.Tables["ACBF"]);
            GetACConvert().Fill(ds.Tables["ACConvert"]);
            GetACSeries().Fill(ds.Tables["ACSeries"]);
            GetACDependency().Fill(ds.Tables["ACDependency"]);
            GetSeries().Fill(ds.Tables["Series"]);
            GetActivityCode().Fill(ds.Tables["ActivityCode"]);
            GetACMajor().Fill(ds.Tables["ACMajor"]);
            GetACDisb().Fill(ds.Tables["ACDisb"]);
            GetActivityField().Fill(ds.Tables["ActivityField"]);
            GetACFileType().Fill(ds.Tables["ACFileType"]);
            GetACMenu().Fill(ds.Tables["ACMenu"]);
            GetACDocumentation().Fill(ds.Tables["ACDocumentation"]);
            GetOfficeMandate().Fill(ds.Tables["OfficeMandate"]);
            GetACControlType().Fill(ds.Tables["ACControlType"]);
            GetACDependencyType().Fill(ds.Tables["ACDependencyType"]);
            GetACSeriesType().Fill(ds.Tables["ACSeriesType"]);
            GetACTaskType().Fill(ds.Tables["ACTaskType"]);
            GetSeriesStatus().Fill(ds.Tables["SeriesStatus"]);
            GetSeriesPackage().Fill(ds.Tables["SeriesPackage"]);

        }

        public void ExportConfig(string file)
        {
            DB.WriteXml(file);
        }
        public void ImportConfig(string file)
        {
            //this method provides a mechanism for moving config data from one install to another

            ActivityConfig newConfig = new ActivityConfig();
            newConfig.ReadXml(file);
            if (newConfig.ACSeries.Count == 0)
                throw new atLogic.AtriumException("The file you tried to import is not an Activity Config export.");

            bool okToDelete=AtMng.GetSetting(AppBoolSetting.AllowActivityDeleteOnConfigPush);
            try
            {
                AtMng.acMng.isMerging = true;
                //process deletes
                //check for used acseries first!
                string filt = "";
                string used = "";
                foreach (ActivityConfig.ACSeriesRow trgDr in DB.ACSeries)
                {
                    if (newConfig.ACSeries.PrimaryKey[0].DataType == typeof(string))
                    { filt = newConfig.ACSeries.PrimaryKey[0].ColumnName + "='" + trgDr[newConfig.ACSeries.PrimaryKey[0].ColumnName].ToString() + "'"; }
                    else
                    { filt = newConfig.ACSeries.PrimaryKey[0].ColumnName + "=" + trgDr[newConfig.ACSeries.PrimaryKey[0].ColumnName].ToString(); }

                    System.Data.DataRow[] srcDr = newConfig.ACSeries.Select(filt, "");
                    if (srcDr.Length == 0)
                    {
                        if (trgDr.StepType == (int)atriumBE.StepType.Activity)
                        {
                            int count = (int)AtMng.DALMngr.ExecuteScalarSQL("select count(*) from vactivity where acseriesid=" + trgDr.ACSeriesId.ToString());
                            if (count > 0)
                            {
                                if (okToDelete)
                                {
                                    System.Data.DataTable dtA = AtMng.GetGeneralRec("select activityid,ts from vactivity where acseriesid=" + trgDr.ACSeriesId.ToString());
                                    foreach (System.Data.DataRow drA in dtA.Rows)
                                    {
                                        AtMng.DALMngr.ExecuteSP("ActivityDelete", drA[0], null, drA[1]);
                                    }
                                }
                                else
                                {
                                    used += trgDr.StepCode + "; ";
                                }
                            }
                        }

                        //look in officemandate and remove
                        foreach (ActivityConfig.OfficeMandateRow omr in trgDr.GetOfficeMandateRows())
                        {
                            omr.Delete();
                        }
                    }

                }

                if (used.Length > 0)
                {
                    DB.OfficeMandate.RejectChanges();
                    throw new Exception("The following steps have been used and can't be deleted:\n\r" + used);
                }

                DeleteFromTable(DB.Menu, newConfig.Menu);
                DeleteFromTable(DB.ACTaskType, newConfig.ACTaskType);
                DeleteFromTable(DB.OfficeMandate, newConfig.OfficeMandate);
                DeleteFromTable(DB.ActivityField, newConfig.ActivityField);
                DeleteFromTable(DB.ACDependency, newConfig.ACDependency);
                DeleteFromTable(DB.ACBF, newConfig.ACBF);
                DeleteFromTable(DB.ACFileType, newConfig.ACFileType);
                DeleteFromTable(DB.ACConvert, newConfig.ACConvert);
                DeleteFromTable(DB.ACMenu, newConfig.ACMenu);
                DeleteFromTable(DB.ACDisb, newConfig.ACDisb);
                DeleteFromTable(DB.ACSeries, newConfig.ACSeries);
                DeleteFromTable(DB.ActivityCode, newConfig.ActivityCode);
                DeleteFromTable(DB.Series, newConfig.Series);
                DeleteFromTable(DB.ACMajor, newConfig.ACMajor);
                DeleteFromTable(DB.ACDocumentation, newConfig.ACDocumentation);
                DeleteFromTable(DB.ACControlType, newConfig.ACControlType);
                DeleteFromTable(DB.ACDependencyType, newConfig.ACDependencyType);
                DeleteFromTable(DB.ACSeriesType, newConfig.ACSeriesType);
                DeleteFromTable(DB.SeriesPackage, newConfig.SeriesPackage);
                DeleteFromTable(DB.SeriesStatus, newConfig.SeriesStatus);

                //atLogic.BusinessProcess bpD = AtMng.GetBP();

                //bpD.AddForUpdate(DB.OfficeMandate);
                //bpD.AddForUpdate(DB.ActivityField);
                //bpD.AddForUpdate(DB.ACDependency);
                //bpD.AddForUpdate(DB.ACBF);
                //bpD.AddForUpdate(DB.ACConvert);
                //bpD.AddForUpdate(DB.ACFileType);
                //bpD.AddForUpdate(DB.ACDisb);
                //bpD.AddForUpdate(DB.ACMenu);
                //bpD.AddForUpdate(DB.ACSeries);
                //bpD.AddForUpdate(DB.ActivityCode);
                //bpD.AddForUpdate(DB.Series);
                //bpD.AddForUpdate(DB.ACMajor);
                //bpD.AddForUpdate(DB.ACDocumentation);
                //bpD.AddForUpdate(DB.ACControlType);
                //bpD.AddForUpdate(DB.ACDependencyType);
                //bpD.AddForUpdate(DB.ACSeriesType);
                //bpD.AddForUpdate(DB.ACTaskType);
                //bpD.AddForUpdate(DB.SeriesStatus);
                //bpD.AddForUpdate(DB.SeriesPackage);
                //bpD.AddForUpdate(DB.Menu);

                //bpD.Update();

                //process tables for add and update
                ImportTable(DB.Menu, newConfig.Menu);
                ImportTable(DB.ACTaskType, newConfig.ACTaskType);
                ImportTable(DB.ACMajor, newConfig.ACMajor);
                ImportTable(DB.Series, newConfig.Series);
                ImportTable(DB.ActivityCode, newConfig.ActivityCode);
                ImportTable(DB.ACSeries, newConfig.ACSeries);
                ImportTable(DB.ActivityField, newConfig.ActivityField);
                ImportTable(DB.ACBF, newConfig.ACBF);
                ImportTable(DB.ACDependency, newConfig.ACDependency);
                ImportTable(DB.ACFileType, newConfig.ACFileType);
                ImportTable(DB.ACConvert, newConfig.ACConvert);
                ImportTable(DB.ACMenu, newConfig.ACMenu);
                ImportTable(DB.ACDisb, newConfig.ACDisb);
                ImportTable(DB.OfficeMandate, newConfig.OfficeMandate);
                ImportTable(DB.ACDocumentation, newConfig.ACDocumentation);
                ImportTable(DB.ACControlType, newConfig.ACControlType);
                ImportTable(DB.ACDependencyType, newConfig.ACDependencyType);
                ImportTable(DB.ACSeriesType, newConfig.ACSeriesType);
                ImportTable(DB.SeriesPackage, newConfig.SeriesPackage);
                ImportTable(DB.SeriesStatus, newConfig.SeriesStatus);

                atLogic.BusinessProcess bp = AtMng.GetBP();

                bp.AddForUpdate(DB.Menu);
                bp.AddForUpdate(DB.ACTaskType);
                bp.AddForUpdate(DB.ACMajor);
                bp.AddForUpdate(DB.Series);
                bp.AddForUpdate(DB.ActivityCode);
                bp.AddForUpdate(DB.ACSeries);
                bp.AddForUpdate(DB.ActivityField);
                bp.AddForUpdate(DB.ACDependency);
                bp.AddForUpdate(DB.ACBF);
                bp.AddForUpdate(DB.ACConvert);
                bp.AddForUpdate(DB.ACFileType);
                bp.AddForUpdate(DB.ACDisb);
                bp.AddForUpdate(DB.ACMenu);
                bp.AddForUpdate(DB.OfficeMandate);
                bp.AddForUpdate(DB.ACDocumentation);
                bp.AddForUpdate(DB.ACControlType);
                bp.AddForUpdate(DB.ACDependencyType);
                bp.AddForUpdate(DB.ACSeriesType);
                bp.AddForUpdate(DB.SeriesStatus);
                bp.AddForUpdate(DB.SeriesPackage);

                bp.Update();

                AtMng.acMng.isMerging = false; ;

            }
            catch (Exception x)
            {
                DB.RejectChanges();
                AtMng.acMng.isMerging = false;
                throw x;
            }
        }

        public static void DeleteFromTable(System.Data.DataTable targetDT, System.Data.DataTable srcDT)
        {
            string filt = "";
            foreach (System.Data.DataRow trgDr in targetDT.Rows)
            {
                if (srcDT.PrimaryKey[0].DataType == typeof(string))
                { filt = srcDT.PrimaryKey[0].ColumnName + "='" + trgDr[srcDT.PrimaryKey[0].ColumnName].ToString() + "'"; }
                else
                { filt = srcDT.PrimaryKey[0].ColumnName + "=" + trgDr[srcDT.PrimaryKey[0].ColumnName].ToString(); }

                System.Data.DataRow[] srcDr = srcDT.Select(filt, "");
                if (srcDr.Length == 0)
                {
                    //delete
                    trgDr.Delete();
                }

            }
        }

        public static void ImportTable(System.Data.DataTable targetDT, System.Data.DataTable srcDT)
        {
            string filt = "";
            foreach (System.Data.DataRow srcDr in srcDT.Rows)
            {
                if (targetDT.PrimaryKey[0].DataType == typeof(string))
                { filt = targetDT.PrimaryKey[0].ColumnName + "='" + srcDr[targetDT.PrimaryKey[0].ColumnName].ToString() + "'"; }
                else
                { filt = targetDT.PrimaryKey[0].ColumnName + "=" + srcDr[targetDT.PrimaryKey[0].ColumnName].ToString(); }

                System.Data.DataRow[] trgDr = targetDT.Select(filt, "");
                if (trgDr.Length == 0)
                {
                    //add
                    System.Data.DataRow newTrgDr = targetDT.NewRow();
                    targetDT.Rows.Add(newTrgDr);
                    ImportRow(newTrgDr, srcDr);
                }
                else
                {
                    //update
                    //date check removed on 2015-3-25 by CJW 
                    //to prevent issues where data didn't get copied to another vertical because it was editted directly in the database
                    if (DateTime.Compare((DateTime)srcDr["UpdateDate"], (DateTime)trgDr[0]["UpdateDate"]) != 0)

                    ImportRow(trgDr[0], srcDr);
                }
            }
        }

        public static void ImportRow(System.Data.DataRow trgDR, System.Data.DataRow srcDR)
        {
            foreach (System.Data.DataColumn dc in trgDR.Table.Columns)
            {
                bool ok = true;
                if (trgDR.RowState != System.Data.DataRowState.Added)
                {
                    if (trgDR.Table.TableName.ToUpper() == "APPSETTING")//never update appsettings
                        ok = false;

                    string tf = trgDR.Table.TableName + dc.ColumnName;
                    switch (tf.ToUpper())
                    {
                        case "TEMPLATEFLAGFOREXPORT":
                        case "TEMPLATEEXPORTEDDATE":
                            ok = false;
                            break;
                        case "TEMPLATEIMPORTEDDATE":
                            trgDR[dc.ColumnName] = DateTime.Now;
                            ok = false;
                            break;
                        case "SERIESCONTAINERFILEID":
                            ok = false;
                            break;
                        case "ACTIVITYFIELDDEFAULTVALUE":
                            ActivityConfig.ActivityFieldRow afr = (ActivityConfig.ActivityFieldRow)srcDR;

                            switch (afr.ObjectName.ToUpper() + afr.FieldName.ToUpper())
                            {
                                case "FILECONTACTCONTACTID":
                                    if (!afr.IsDefaultValueNull() )
                                        ok = false;
                                    break;
                                case "DOCTRANSFERSHAREFOLDER":
                                case "ISSUEPRIMARYISSUEID":
                                    ok = false;
                                    break;

                                case "RECIPIENTADDRESS":
                                    if (!afr.IsDefaultValueNull() && afr.DefaultValue.Contains("@"))
                                        ok = false;
                                    break;

                            }

                            break;
                    }
                }

                if (!dc.ReadOnly && ok)
                    trgDR[dc.ColumnName] = srcDR[dc.ColumnName];
            }
        }
    }
}
