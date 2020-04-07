using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Configuration;


namespace lmras
{
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class Atrium 
    {
        [WebGet(UriTemplate="/Doc/{id}", BodyStyle= WebMessageBodyStyle.Bare)]
        public Stream GetDoc(string id)
        {
            atriumDAL.atriumDALManager atDal = new atriumDAL.atriumDALManager(ConfigurationManager.AppSettings["DBConnUserName"], ConfigurationManager.AppSettings["DBConnPassword"], "DATABASE1");

            int postId;

            if (!Int32.TryParse(id, out postId))
            {

                return null;
            }

            lmDatasets.docDB.DocumentDataTable docDt= atDal.GetDocument().Load(postId);
            if (docDt.Rows.Count == 1)
            {
                lmDatasets.docDB.DocContentDataTable dt = atDal.GetDocContent().LoadDT(postId, docDt[0].CurrentVersion);

                //write resource to stream
                //Response.ContentType = GetMimeType(dt[0]);
                WebOperationContext.Current.OutgoingResponse.ContentType = GetMimeType(dt[0]);

                MemoryStream ms = new MemoryStream(dt[0].Contents);
                return ms;
            }
            else
                return null;
        }

        public static string GetMimeType(lmDatasets.docDB.DocContentRow doc)
        {
            switch (doc.Ext.ToLower())
            {
                case ".txt":
                    return "text/plain";
                case ".rtf":
                    return "application/msword";
                case ".htm":
                case ".html":
                    return "text/html";
                case ".xml":
                    return "text/xml";
                case ".pdf":
                    return "application/pdf";

                case ".xlx":
                case ".xls":
                    return "application/vnd.ms-excel";
                case ".ppt":
                case ".pptx":
                    return "application/vnd.ms-powerpoint";
                case ".docx":
                    return "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                case ".doc":
                    return "application/msword";
                case ".gif":
                    return "image/gif";
                case ".jpg":
                case ".jpeg":
                    return "image/jpeg";
                case ".tif":
                case ".tiff":
                    return "image/tiff";

                default:
                    return System.Net.Mime.MediaTypeNames.Application.Octet;


            }
        }
    }
}
