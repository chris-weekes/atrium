namespace lmDatasets
{


    partial class appDB
    {
        partial class ddFieldDataTable
        {
        }

        partial class EFileSearchThreadDataTable
        {
        }

        partial class SRPClientDataTable
        {
        }

        partial class ContactSearchDataTable
        {
        }

        partial class EFileSearchDataTable
        {
            public string Lang = "Eng";

        }


        public partial class EFileSearchRow : System.Data.DataRow
        {
            public string Name
            {
                get
                {
                    try
                    {
                        return ((string)(this["Name" + (this.tableEFileSearch).Lang.Substring(0, 1)]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'Name\' in table \'EFile\' is DBNull.", e);
                    }
                }
            }

        }
    }
}
