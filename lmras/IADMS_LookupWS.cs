using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;

namespace lmras
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IADMS_LookupWS" in both code and config file together.
    [ServiceContract]
    public interface IADMS_Lookup
    {
        [OperationContract]
         DataSet Get_ADMS_SST_Info(int ADMSRecordNumber,string SIN ,string BusinessNumber )  ;

  
    }
}
