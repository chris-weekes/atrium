using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Configuration;

namespace lmras
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ADMS_LookupWS" in code, svc and config file together.
    public class ADMS_Lookup : IADMS_Lookup
    {
        public DataSet Get_ADMS_SST_Info(int ADMSRecordNumber, string SIN, string BusinessNumber) 
        {
            DataSet ds = new DataSet();

            string f = @"d:\webs\lmrasT\adms.txt";
            switch(ADMSRecordNumber.ToString().Trim().Substring(0,1))
            {
                case "1":
                    f = @"d:\webs\lmrasT\adms1.txt";
                    break;
                case "2":
                    f = @"d:\webs\lmrasT\adms2.txt";
                    break;
            }
            ds.ReadXml(f, XmlReadMode.ReadSchema);
            return ds;
        }

    

       
    }
}
