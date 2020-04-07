using System;
using System.Collections;
using lmDatasets;


namespace atriumBE
{
    /// <summary>
    /// 
    /// </summary>
    public class HelpManager : atLogic.BEManager
    {
       

        atriumBE.atriumManager myatMng;
        public atriumBE.atriumManager AtMng
        {
            get { return myatMng; }
            set { myatMng = value; }
        }

        public HelpManager(atriumBE.atriumManager atmng)
            : base(atmng.AppMan)
        {
            base.DAL = atmng.DALMngr;
            myatMng = atmng;


            MyDS = new HelpDB();
            MyDS.EnforceConstraints = false;
         
           
        }

        public override void LoadAll(bool refresh)
        {
            if (refresh)
            {
                GethlpImage().PreRefresh();
                GethlpPage().PreRefresh();
                GethlpXml().PreRefresh();
            }
            GethlpImage().Load();
            GethlpPage().Load();
            GethlpXml().Load();
        }

        internal atriumDAL.atriumDALManager DALMngr
        {
            get
            {
                return myatMng.DALMngr;

            }

        }

        public HelpDB DB
        {
            get
            {
                return (HelpDB)MyDS;
            }
        }


        public hlpImageBE myhlpImage;

        public hlpPageBE myhlpPage;

        public hlpXmlBE myhlpXml;
        public hlpImageBE GethlpImage()
        {

            if (myhlpImage == null)
            {
                myhlpImage = new hlpImageBE(this);
            }

            return myhlpImage;
        }


        public hlpPageBE GethlpPage()
        {

            if (myhlpPage == null)
            {
                myhlpPage = new hlpPageBE(this);
            }

            return myhlpPage;
        }


        public hlpXmlBE GethlpXml()
        {

            if (myhlpXml == null)
            {
                myhlpXml = new hlpXmlBE(this);
            }

            return myhlpXml;
        }

        public void Import(string path)
        {


            //load xml into dataset
            lmDatasets.HelpDB hlpDS = new HelpDB();
            hlpDS.ReadXml(path);

            //loop through page table
            foreach (lmDatasets.HelpDB.hlpPageRow hpr in hlpDS.hlpPage)
            {
                lmDatasets.HelpDB.hlpPageRow curr_hpr = DB.hlpPage.FindByFileNameLang(hpr.FileName, hpr.Lang);


                if (curr_hpr == null)
                {
                    //if record does not -add
                    curr_hpr = DB.hlpPage.NewhlpPageRow();
                    CopyRow(hpr, curr_hpr);
                    DB.hlpPage.AddhlpPageRow(curr_hpr);
                }
                else
                {
                    CopyRow(hpr, curr_hpr);
                }



            }
            //GethlpPage().Update();

            //myatMng.AppMan.Commit();
            //DB.hlpPage.AcceptChanges();

            //loop through image table
            foreach (lmDatasets.HelpDB.hlpImageRow hpr in hlpDS.hlpImage)
            {
                lmDatasets.HelpDB.hlpImageRow curr_hpr = DB.hlpImage.FindByFileName(hpr.FileName);


                if (curr_hpr == null)
                {
                    //if record does not -add
                    curr_hpr = DB.hlpImage.NewhlpImageRow();
                    CopyRow(hpr, curr_hpr);
                    DB.hlpImage.AddhlpImageRow(curr_hpr);
                }
                else
                {
                    CopyRow(hpr, curr_hpr);
                }

                //GethlpImage().Update();

                //myatMng.AppMan.Commit();
                //DB.hlpImage.AcceptChanges();


            }

            //loop through Xml table
            foreach (lmDatasets.HelpDB.hlpXmlRow hpr in hlpDS.hlpXml)
            {
                lmDatasets.HelpDB.hlpXmlRow curr_hpr = DB.hlpXml.FindByFileName(hpr.FileName);


                if (curr_hpr == null)
                {
                    //if record does not -add
                    curr_hpr = DB.hlpXml.NewhlpXmlRow();
                    CopyRow(hpr, curr_hpr);
                    DB.hlpXml.AddhlpXmlRow(curr_hpr);
                }
                else
                {
                    CopyRow(hpr, curr_hpr);
                }



            }
            //GethlpXml().Update();

            //myatMng.AppMan.Commit();
            //DB.hlpXml.AcceptChanges();

            atLogic.BusinessProcess bp = GetBP();
            bp.AddForUpdate(GethlpPage());
            bp.AddForUpdate(GethlpXml());
            bp.AddForUpdate(GethlpImage());
            bp.Update();

          
        }

        private void CopyRow(System.Data.DataRow drOrig, System.Data.DataRow drTrg)
        {
            foreach (System.Data.DataColumn dc in drTrg.Table.Columns)
            {
                if (!dc.ReadOnly)
                {
                    drTrg[dc.ColumnName] = drOrig[dc.ColumnName];
                }
            }
        }

        public void Dump(string path, bool includePages, bool includeImages)
        {

            HelpDB tmp = new HelpDB();
            System.Data.DataTable dt;

            if (includePages)
            {
                dt = DB.hlpPage.GetChanges();
                if (dt != null)
                    tmp.hlpPage.Merge(dt);
                else
                    tmp.hlpPage.Merge(DB.hlpPage);
            }
            if (includeImages)
            {
                dt = DB.hlpImage.GetChanges();
                if (dt != null)
                    tmp.hlpImage.Merge(dt);
                else
                    tmp.hlpImage.Merge(DB.hlpImage);
            }

            tmp.hlpXml.Merge(DB.hlpXml);
            tmp.WriteXml(path);

        }

        public void DumpFiles(string path)
        {

          


            foreach (HelpDB.hlpPageRow dr in DB.hlpPage)
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(path, dr.Lang));

                string fil = System.IO.Path.Combine(path, dr.Lang, dr.FileName);
                if(!dr.IsContentsNull())
                    System.IO.File.WriteAllText(fil, dr.Contents);
            }

            foreach (HelpDB.hlpXmlRow dr in DB.hlpXml)
            {
              //  System.IO.Directory.CreateDirectory(System.IO.Path.Combine(path, dr.Lang));

                string fil = System.IO.Path.Combine(path, dr.FileName);
                if (!dr.IsContentsNull())
                    System.IO.File.WriteAllText(fil, dr.Contents);
            }
        }
    }
}
