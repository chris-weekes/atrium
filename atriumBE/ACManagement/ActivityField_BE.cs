using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
    /// <summary>
    /// 
    /// </summary>
    public class ActivityFieldBE : atLogic.ObjectBE
    {
        ACManager myA;
        ActivityConfig.ActivityFieldDataTable myActivityFieldDT;


        internal ActivityFieldBE(ACManager pBEMng)
            : base(pBEMng, pBEMng.DB.ActivityField)
        {
            myA = pBEMng;
            myActivityFieldDT = (ActivityConfig.ActivityFieldDataTable)myDT;

        }
        public atriumDAL.ActivityFieldDAL myDAL
        {
            get
            {
                return (atriumDAL.ActivityFieldDAL)myODAL;
            }
        }

        protected override void AfterChange(DataColumn dc, DataRow dr)
        {
            ActivityConfig.ActivityFieldRow acr = (ActivityConfig.ActivityFieldRow)dr;
            switch (dc.ColumnName)
            {
                case "TaskType":
                    if (acr.TaskType == "T")
                    {
                        acr.ObjectName = "Specify Step Code in Default Value";
                        acr.ObjectAlias = "N/A";
                    }

                    break;
                case "ObjectAlias":
                    if(acr.TaskType=="F") // update ObjectName when setting ObjectAlias on RelatedField (tasktype F) row
                    {
                        ActivityConfig.ActivityFieldRow[] afrs = (ActivityConfig.ActivityFieldRow[])myA.DB.ActivityField.Select("AcSeriesId=" + acr.ACSeriesId + " and TaskType<>'F' and ObjectAlias='"+acr.ObjectAlias+"'");
                        if(afrs.Length>0)
                            acr.ObjectName = afrs[0].ObjectName;
                    }
                    break;

                case "ObjectName": //set ObjectAlias to ObjectName when ObjectAlias is null
                    if (acr.IsObjectAliasNull())
                        acr.ObjectAlias = acr.ObjectName;
                    if (acr.ObjectName == "Document")
                        acr.ObjectAlias = "Document0";
                    break;
               
            }
        }
        protected override void BeforeChange(DataColumn dc, DataRow dr)
        {
            ActivityConfig.ActivityFieldRow acr = (ActivityConfig.ActivityFieldRow)dr;
            switch (dc.ColumnName)
            {
                case "Visible":
                    //if (!acr.Visible & acr.IsDefaultValueNull())
                    //    throw new AtriumException("You must have a default value if the field is hidden.");
                    break;
            }
        }
        protected override void AfterAdd(DataRow dr)
        {

            ActivityConfig.ActivityFieldRow acr = (ActivityConfig.ActivityFieldRow)dr;

            acr.ActivityFieldID = myA.AtMng.PKIDGet("ActivityField", 1);
            //if (acr.ACSeriesRow != null)
            //    acr.ActivityCodeID = acr.ACSeriesRow.ActivityCodeID;

            if (acr.ACSeriesRow != null)
                acr.Seq = System.Convert.ToInt16(acr.ACSeriesRow.GetActivityFieldRows().Length * 10);
            else
                acr.Seq = 0;

            acr.Step = 0;
            acr.Instance =0;
            acr.TaskType = "F";
            acr.Required = true;
            acr.Visible = true;
            acr.ReadOnly = false;
        }

        public int InstanceMax(ActivityConfig.ACSeriesRow acsr, string oName)
        {
            int InstanceCount = -1;
            foreach (lmDatasets.ActivityConfig.ActivityFieldRow afr in acsr.GetActivityFieldRows())
            {
                if (!afr.IsNull("ObjectName") && afr.ObjectName == oName && afr.Instance > InstanceCount)
                    InstanceCount = afr.Instance;
            }
            return InstanceCount + 1;
        }

    }
}

