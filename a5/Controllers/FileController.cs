using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using atriumBE;
using PagedList;
using lmDatasets;

namespace a5.Controllers
{
    [HandleError]
    public class FileController : Controller
    {
        //
        // GET: /File/
        public ActionResult Index(int fileId)
        {
            atriumManager myAtmng = Helper.Atmng();
            FileManager fm = myAtmng.GetFile(fileId);
           
            ViewBag.fm = fm;
            return View();
        }
        public ActionResult EFile(int fileId)
        {
            atriumManager myAtmng = Helper.Atmng();
            FileManager fm = myAtmng.GetFile(fileId);
            
            ViewBag.fm = fm;
            ViewBag.acSeriesId = 104038;
            return View("A5");
           
        }
        public ActionResult Opponent(int fileId, int? linkId)
        {
            atriumManager myAtmng = Helper.Atmng();
            FileManager fm = myAtmng.GetFile(fileId);

            if (linkId != null)
                ViewBag.ContextRow = fm.DB.Address.FindByAddressId((int)linkId);
          

            ViewBag.fm = fm;
            ViewBag.acSeriesId = 104039;
            return View("A5");

        }
        public ActionResult Contact(int fileId,int linkId)
        {
            atriumManager myAtmng = Helper.Atmng();
            FileManager fm = myAtmng.GetFile(fileId);

            ViewBag.fm = fm;
            ViewBag.acSeriesId = 104044;
            ViewBag.ContextRow = fm.DB.FileContact.FindByFileContactid(linkId);
            return View("A5");

        }
        public ActionResult Account(int fileId, int linkId)
        {
            atriumManager myAtmng = Helper.Atmng();
            FileManager fm = myAtmng.GetFile(fileId);

            ViewBag.fm = fm;
            ViewBag.acSeriesId = 104041;
            ViewBag.ContextRow = fm.GetCLASMng().DB.Debt.FindByDebtId(linkId);

            return View("A5");

        }
        public ActionResult Judgment(int fileId, int linkId)
        {
            atriumManager myAtmng = Helper.Atmng();
            FileManager fm = myAtmng.GetFile(fileId);

            ViewBag.fm = fm;
            ViewBag.acSeriesId = 104040;
            ViewBag.ContextRow = fm.GetCLASMng().DB.Judgment.FindByJudgmentID(linkId);
            return View("A5");

        }

        public ActionResult JudgmentAccount(int fileId, int linkId)
        {
            atriumManager myAtmng = Helper.Atmng();
            FileManager fm = myAtmng.GetFile(fileId);

            ViewBag.fm = fm;
            ViewBag.acSeriesId = 104093;
            ViewBag.ContextRow = fm.GetCLASMng().DB.JudgmentAccount.FindByJudgmentAccountID(linkId);
            return PartialView("P5");

        }

        public ActionResult Bankruptcy(int fileId, int linkId)
        {
            atriumManager myAtmng = Helper.Atmng();
            FileManager fm = myAtmng.GetFile(fileId);

            ViewBag.fm = fm;
            ViewBag.acSeriesId = 104042;
            ViewBag.ContextRow = fm.GetCLASMng().DB.Bankruptcy.FindByBankruptcyID(linkId);
            return View("A5");

        }
        public ActionResult Insolvency(int fileId, int linkId)
        {
            atriumManager myAtmng = Helper.Atmng();
            FileManager fm = myAtmng.GetFile(fileId);

            ViewBag.fm = fm;
            ViewBag.acSeriesId = 104043;
            ViewBag.ContextRow = fm.GetCLASMng().DB.Insolvency.FindByInsolvencyID(linkId);
            return View("A5");

        }
        public ActionResult Cost(int fileId, int linkId)
        {
            atriumManager myAtmng = Helper.Atmng();
            FileManager fm = myAtmng.GetFile(fileId);

            ViewBag.fm = fm;
            ViewBag.acSeriesId = 104045;
            ViewBag.ContextRow = fm.GetCLASMng().DB.Cost.FindByCostID(linkId);
            return View("A5");

        }
        public ActionResult Writ(int fileId, int linkId)
        {
            atriumManager myAtmng = Helper.Atmng();
            FileManager fm = myAtmng.GetFile(fileId);

            ViewBag.fm = fm;
            ViewBag.acSeriesId = 104048;
            ViewBag.ContextRow = fm.GetCLASMng().DB.Writ.FindByWritID(linkId);
            return View("A5");

        }
        public ActionResult FileOffice(int fileId, int linkId)
        {
            atriumManager myAtmng = Helper.Atmng();
            FileManager fm = myAtmng.GetFile(fileId);

            ViewBag.fm = fm;
            ViewBag.acSeriesId = 104047;
            ViewBag.ContextRow = fm.DB.FileOffice.FindByFileOfficeId(linkId);
            return View("A5");

        }
        public ActionResult FileHistory(int fileId, int? linkId)
        {
            atriumManager myAtmng = Helper.Atmng();
            FileManager fm = myAtmng.GetFile(fileId);

            ViewBag.fm = fm;
            ViewBag.acSeriesId = 104046;
            if(linkId!=null)
                ViewBag.ContextRow = fm.GetCLASMng().DB.FileHistory.FindByHistoryId((int)linkId);
            else
                ViewBag.ContextRow = fm.GetCLASMng().DB.FileHistory[0];

            return View("A5");

        }
        public ActionResult Activity(int fileId, int? linkId, int? page)
        {
            atriumManager myAtmng = Helper.Atmng();
            FileManager fm = myAtmng.GetFile(fileId);
            fm.InitActivityProcess();
            ViewBag.fm = fm;
            int p = 1;
            if (page != null)
                p =(int) page;
            if (linkId != null)
                ViewBag.ContextRow = fm.DB.Activity.FindByActivityId((int)linkId);

            return View(fm.DB.Activity.OrderByDescending(u => u.ActivityDate).ToPagedList(p, 12));
        }

        public ActionResult A5(int fileId,int acSeriesId)
        {
            atriumManager myAtmng = Helper.Atmng();
            FileManager fm = myAtmng.GetFile(fileId);
       
            ViewBag.fm = fm;
            ViewBag.acSeriesId = acSeriesId;
            return View();
       
        }

        public ActionResult ActivityBF(int fileId, int? linkId)
        {
            atriumManager myAtmng = Helper.Atmng();
            FileManager fm = myAtmng.GetFile(fileId);

            ViewBag.fm = fm;
            ViewBag.acSeriesId = 104062;
            if (linkId != null)
                ViewBag.ContextRow = fm.DB.ActivityBF.FindByActivityBFId((int)linkId);
            return View("A5");

        }
        public ActionResult Document(int fileId, int? linkId)
        {
            atriumManager myAtmng = Helper.Atmng();
            FileManager fm = myAtmng.GetFile(fileId);

            ViewBag.fm = fm;
            ViewBag.acSeriesId = 104061;
            if(linkId!=null)
                ViewBag.ContextRow = fm.GetDocMng().DB.Document.FindByDocId((int)linkId);
            return View("A5");
        }
        public ActionResult IRP(int fileId, int? linkId)
        {
            atriumManager myAtmng = Helper.Atmng();
            FileManager fm = myAtmng.GetFile(fileId);

            ViewBag.fm = fm;
            ViewBag.acSeriesId = 104063;
            if (linkId != null)
                ViewBag.ContextRow = fm.DB.IRP.FindByIRPId((int)linkId);
            else
                ViewBag.ContextRow = fm.DB.IRP[0];
            return View("A5");
        }
        public ActionResult FileTaxing(int fileId, int? linkId)
        {
            atriumManager myAtmng = Helper.Atmng();
            FileManager fm = myAtmng.GetFile(fileId);

            ViewBag.fm = fm;
            ViewBag.acSeriesId = 104064;
            if (linkId != null)
                ViewBag.ContextRow = fm.GetCLASMng().DB.Taxing.FindByTaxingID((int)linkId);
            return View("A5");
        }
        public ActionResult OfficeTaxing(int fileId, int? linkId)
        {
            atriumManager myAtmng = Helper.Atmng();
            FileManager fm = myAtmng.GetFile(fileId);
            //may need to load data here
            //as we are not loading by fileid

            ViewBag.fm = fm;
            ViewBag.acSeriesId = 104060;
            if (linkId != null)
                ViewBag.ContextRow = fm.GetCLASMng().DB.Taxing.FindByTaxingID((int)linkId);
            return View("A5");
        }
        public ActionResult Office(int fileId, int? linkId)
        {
            atriumManager myAtmng = Helper.Atmng();
            FileManager fm = myAtmng.GetFile(fileId);

            ViewBag.fm = fm;
            ViewBag.acSeriesId = 104053;
            if (linkId != null)
                ViewBag.ContextRow = fm.LeadOfficeMng.DB.Office.FindByOfficeId((int)linkId);
            return View("A5");
        }
        public ActionResult Officer(int fileId, int? linkId)
        {
            atriumManager myAtmng = Helper.Atmng();
            FileManager fm = myAtmng.GetFile(fileId);

            ViewBag.fm = fm;
            ViewBag.acSeriesId = 104054;
            if (linkId != null)
                ViewBag.ContextRow = fm.LeadOfficeMng.DB.Officer.FindByOfficerId((int)linkId);
            return View("A5");
        }
        public ActionResult CashBlotter(int fileId, int? linkId)
        {
            atriumManager myAtmng = Helper.Atmng();
            FileManager fm = myAtmng.GetFile(fileId);

            ViewBag.fm = fm;
            ViewBag.acSeriesId = 104055;
            if (linkId != null)
                ViewBag.ContextRow = fm.GetCLASMng().DB.CashBlotter.FindByCashBlotterID((int)linkId);
            return View("A5");
        }
        public ActionResult OfficeAccount(int fileId, int? linkId)
        {
            atriumManager myAtmng = Helper.Atmng();
            FileManager fm = myAtmng.GetFile(fileId);

            ViewBag.fm = fm;
            ViewBag.acSeriesId = 104059;
            if (linkId != null)
                ViewBag.ContextRow = fm.GetCLASMng().DB.OfficeAccount.FindByOfficeAccountID((int)linkId);
            return View("A5");
        }
        public ActionResult SRP(int fileId, int? linkId)
        {
            atriumManager myAtmng = Helper.Atmng();
            FileManager fm = myAtmng.GetFile(fileId);

            ViewBag.fm = fm;
            ViewBag.acSeriesId = 104056;
            if (linkId != null)
                ViewBag.ContextRow = fm.DB.SRP.FindBySRPID((int)linkId);
            return View("A5");
        }
        public ActionResult SRPDetail(int fileId, int? linkId)
        {
            atriumManager myAtmng = Helper.Atmng();
            FileManager fm = myAtmng.GetFile(fileId);
            //need to load data by srpid

            ViewBag.fm = fm;
            ViewBag.acSeriesId = 104057;
            if (linkId != null)
                ViewBag.ContextRow = fm.DB.IRP.FindByIRPId((int)linkId);
            return View("A5");
        }
        public ActionResult BillingReview(int fileId, int? linkId)
        {
            atriumManager myAtmng = Helper.Atmng();
            FileManager fm = myAtmng.GetFile(fileId);
            //need to load data by srpid

            ViewBag.fm = fm;
            ViewBag.acSeriesId = 104058;
            if (linkId != null)
                ViewBag.ContextRow = fm.DB.IRP.FindByIRPId((int)linkId);
            return View("A5");
        }
        public ActionResult Hardship(int fileId, int? linkId)
        {
            atriumManager myAtmng = Helper.Atmng();
            FileManager fm = myAtmng.GetFile(fileId);

            ViewBag.fm = fm;
            ViewBag.acSeriesId = 104066;
            if (linkId != null)
                ViewBag.ContextRow = fm.GetCLASMng().DB.Hardship.FindByHardshipId((int)linkId);
            return View("A5");
        }
        public ActionResult CBDetail(int fileId, int? linkId)
        {
            atriumManager myAtmng = Helper.Atmng();
            FileManager fm = myAtmng.GetFile(fileId);

            ViewBag.fm = fm;
            ViewBag.acSeriesId = 104065;
            if (linkId != null)
                ViewBag.ContextRow = fm.GetCLASMng().DB.CBDetail.FindByCashBlotterDetailID((int)linkId);
            else
                ViewBag.ContextRow = fm.GetCLASMng().DB.CBDetail[0];
            return View("A5");
        }

        public string A5JSONUpdatex()
        {
            return "hi";
        }
        private Dictionary<string, object> deserializeToDictionary(string jo)
        {
            var values =Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(jo);
            var values2 = new Dictionary<string, object>();
            foreach (KeyValuePair<string, object> d in values)
            {
                // if (d.Value.GetType().FullName.Contains("Newtonsoft.Json.Linq.JObject"))
                if (d.Value is Newtonsoft.Json.Linq.JObject || d.Value.GetType() == typeof(Array))
                {
                    values2.Add(d.Key, deserializeToDictionary(d.Value.ToString()));
                }
                else
                {
                    values2.Add(d.Key, d.Value);
                }
            }
            return values2;
        }
        public string A5JSONUpdate(int fileId, int acSeriesId,string json)
        {
            atriumManager myAtmng = Helper.Atmng();
            FileManager fm = myAtmng.GetFile(fileId);

            lmDatasets.ActivityConfig.ACSeriesRow acsr = fm.AtMng.acMng.DB.ACSeries.FindByACSeriesId(acSeriesId);

            atriumBE.ACEngine MyACE = new ACEngine(fm);
            MyACE.myAcSeries = acsr;
            MyACE.myActivityCode = acsr.ActivityCodeRow;
            MyACE.DoRelFields();
            MyACE.DoStep(ACEngine.Step.RelatedFields0, true);
            MyACE.DoStep(ACEngine.Step.RelatedFields1, true);
            MyACE.DoStep(ACEngine.Step.RelatedFields2, true);
            MyACE.DoStep(ACEngine.Step.RelatedFields3, true);
            MyACE.DoStep(ACEngine.Step.RelatedFields4, true);
            MyACE.DoStep(ACEngine.Step.RelatedFields5, true);
            MyACE.DoStep(ACEngine.Step.RelatedFields6, true);

         

            Newtonsoft.Json.Linq.JObject data = Newtonsoft.Json.Linq.JObject.Parse(json);
           
          
        
            //foreach (ActivityConfig.ActivityFieldRow arf in fm.AtMng.acMng.DB.ActivityField.Select("ACSeriesId=" + acSeriesId.ToString() + " and TaskType in ('F','T')", "objectalias,fieldname"))
            foreach(string curobj in MyACE.relTables.Keys)
            {
               
                    var table = data[curobj].Children().ToList();
                    MyACE.relTables[curobj].Sort = MyACE.relTables[curobj].Table.PrimaryKey[0].ColumnName;
                    foreach (var row in table)
                    {
                        int rid =(int) row["atrid"];
                        int pos= MyACE.relTables[curobj].Find(row["atrid"]);
                        DataRowView dvr = MyACE.relTables[curobj][pos];
                        //need to match up rows
                        foreach (ActivityConfig.ActivityFieldRow arfRow in fm.AtMng.acMng.DB.ActivityField.Select("ObjectAlias='" + curobj + "' and ACSeriesId=" + acSeriesId.ToString() + " and TaskType in ('F','T')", "objectalias,fieldname"))
                        {
                            System.Diagnostics.Debug.WriteLine("{0}, {1}", dvr.Row[arfRow.DBFieldName], data[curobj][0][arfRow.FieldName]);
                        }
                     
                    }
                 
             
            }
            return null;
        }

        public ActionResult A5Test()
        {
            return View("A5Test");
        }
        public string A5JSON(int fileId, int acSeriesId)
        {
            atriumManager myAtmng = Helper.Atmng();
            FileManager fm = myAtmng.GetFile(fileId);

            lmDatasets.ActivityConfig.ACSeriesRow acsr = fm.AtMng.acMng.DB.ACSeries.FindByACSeriesId(acSeriesId);

            atriumBE.ACEngine MyACE = new ACEngine(fm);
            MyACE.myAcSeries = acsr;
            MyACE.myActivityCode = acsr.ActivityCodeRow;
            MyACE.DoRelFields();
            MyACE.DoStep(ACEngine.Step.RelatedFields0, true);
            MyACE.DoStep(ACEngine.Step.RelatedFields1, true);
            MyACE.DoStep(ACEngine.Step.RelatedFields2, true);
            MyACE.DoStep(ACEngine.Step.RelatedFields3, true);
            MyACE.DoStep(ACEngine.Step.RelatedFields4, true);
            MyACE.DoStep(ACEngine.Step.RelatedFields5, true);
            MyACE.DoStep(ACEngine.Step.RelatedFields6, true);

            string curobj = "";
            string json = "{";
            foreach (ActivityConfig.ActivityFieldRow arf in fm.AtMng.acMng.DB.ActivityField.Select("ACSeriesId=" + acSeriesId.ToString() + " and TaskType in ('F','T')", "objectalias,fieldname"))
            {
                if(curobj!=arf.ObjectAlias)
                {
                    //start new row
                    curobj = arf.ObjectAlias;
                    json += "'" + arf.ObjectAlias + "':[";

                    foreach (DataRowView dvr in MyACE.relTables[curobj])
                    {
                        json += "{";
                        json += "'atrid':" + Newtonsoft.Json.JsonConvert.ToString(dvr.Row[dvr.Row.Table.PrimaryKey[0]]) + ",";
                        foreach (ActivityConfig.ActivityFieldRow arfRow in fm.AtMng.acMng.DB.ActivityField.Select("ObjectAlias='" + curobj + "' and ACSeriesId=" + acSeriesId.ToString() + " and TaskType in ('F','T')", "objectalias,fieldname"))
                        {
                            json += "'" + arfRow.FieldName + "':" + Newtonsoft.Json.JsonConvert.ToString(dvr.Row[arfRow.DBFieldName]) + ",";
                        }
                        json=json.TrimEnd(',');
                        json += "},";
                    }
                    json=json.TrimEnd(',');
                    json += "]";
                }
                else
                { }
            }
            return json+"}";
           // DataSet ds = new DataSet();
           // foreach(DataView dv in MyACE.relTables.Values)
           // {
           //     ds.Tables.Add(dv.ToTable());
           // }

           // return Newtonsoft.Json.JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
           //// return Json(ds,JsonRequestBehavior.AllowGet);

        }

        public ActionResult Update()
        {
            return View("A5");
        }
	}
}