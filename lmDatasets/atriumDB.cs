using System.Runtime.InteropServices;
namespace lmDatasets
{


    public partial class atriumDB
    {
        partial class AttendeeDataTable
        {
        }

        partial class ActivityTimeDataTable
        {
        }

        partial class EFileDataTable
        {
        }

        public string Lang = "Eng";
        partial class IssueDataTable
        {
        }

        //public partial class AppointmentRow : System.Data.DataRow
        //{
        //    public System.DateTime StartDateLocal
        //    {
        //        get
        //        {
        //            return this.StartDate.DateTime;
        //        }
        //        set
        //        {
        //            this.StartDate = value;
        //        }
        //    }
        //    public System.DateTime EndDateLocal
        //    {
        //        get
        //        {
        //            return this.EndDate.DateTime;
        //        }
        //        set
        //        {
        //            this.EndDate = value;
        //        }

        //    }
        //}


        public partial class EFileRow : System.Data.DataRow
        {
            public string Name
            {
                get
                {
                    try
                    {
                        return ((string)(this["Name" + ((atriumDB)this.Table.DataSet).Lang.Substring(0, 1)]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'Name\' in table \'EFile\' is DBNull.", e);
                    }
                }
            }

            public string Description
            {
                get
                {
                    try
                    {
                        return ((string)(this["Description" + ((atriumDB)this.Table.DataSet).Lang.Substring(0, 1)]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'Description\' in table \'EFile\' is DBNull.", e);
                    }
                }
            }

        }

        public partial class ProcessRow : System.Data.DataRow
        {
            public string Name
            {
                get
                {
                    try
                    {
                        return ((string)(this["Name" + ((atriumDB)this.Table.DataSet).Lang.Substring(0, 1)]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'Name\' in table \'Process\' is DBNull.", e);
                    }
                }
            }


        }

        public partial class ActivityBFRow : System.Data.DataRow
        {
            public string For
            {
                get
                {
                    switch (this.BFType)
                    {
                        case 1:
                            //office
                            return "office";
                        case 2:
                            //direct
                            return this.BFOfficerCode;

                        case 3:
                            return this.ActivityRow.EFileRow.LeadParalegalCode;
                        case 4:
                            return this.ActivityRow.EFileRow.LeadLawyerCode;
                        case 5:
                            //role
                            return "role";
                        case 6:
                            //mail
                            return this.BFOfficerCode;
                        default:
                            return this.BFOfficerCode;
                    }

                }
            }


        }
    }
}
