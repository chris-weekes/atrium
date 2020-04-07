using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lmras
{
    public partial class doc : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //get resource name
                string sdocId = Request.QueryString["docId"];
                atriumDAL.atriumDALManager atDal;
                try
                {
                    if(Session["Atmng"]!=null)
                    {
                        atriumBE.atriumManager atmng=(atriumBE.atriumManager)Session["Atmng"];
                        atDal = atmng.AppMan.DALMngrX;
                        }
                    else
                        atDal = new atriumDAL.atriumDALManager(System.Net.CredentialCache.DefaultNetworkCredentials, "DATABASE1");
                }
                catch (Exception x)
                {
                    throw new atLogic.LoginException("");

                }

                //Response.Cache.SetExpires(DateTime.Now.AddHours(1));
                //Response.Cache.SetCacheability(HttpCacheability.ServerAndPrivate);
                //Response.Cache.SetValidUntilExpires(true);
                //Response.Cache.VaryByParams["docId"] = true;

                //?  this.Response.Clear(); //is this necessary?

                this.Response.BufferOutput = true;


                if (sdocId != null)
                {
                    int DocId = System.Convert.ToInt32(sdocId);

                    //retirieve resource from db

                    lmDatasets.docDB.DocumentDataTable ddt = atDal.GetDocument().Load(DocId);
                    lmDatasets.docDB.DocumentRow ddr = ddt.FindByDocId(DocId);
                    if (ddr != null)
                    {

                        //Response.AddHeader("Accept-Ranges", "bytes");
                        //Response.AddHeader("Accept-Header", ddr.Size.ToString());
                        Response.AddHeader("content-disposition", "inline;filename=" + ddr.Name);

                        if (!ddr.IsextNull())
                        {
                            lmDatasets.docDB.FileFormatDataTable fdt = atDal.GetFileFormat().Load(ddr.ext);
                            lmDatasets.docDB.FileFormatRow fdr = fdt.FindByFileFormat(ddr.ext);
                            if(fdr!=null && !fdr.IsEncodingNull())
                                Response.ContentType = fdr.Encoding;
                            
                        }
                        atDal.GetDocContent().ReadStream(ddr.DocRefId, this.Response.OutputStream,ddr.CurrentVersion);
                    }
                    else
                    {
                        Response.StatusCode = 404;
                    }
                }
                else
                {
                    Response.StatusCode = 400;
                }
            }

            catch (atLogic.LoginException lx)
            {
                Response.StatusCode = 401;

            }
            catch (Exception x)
            {
                Response.StatusCode = 500;

            }
        }
    }
}