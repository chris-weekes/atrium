using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using lmDatasets;

namespace atriumBE
{
    public class AdvisoryManager : atLogic.BEManager
    {
        FileManager myFM;

        public FileManager FM
        {
            get { return myFM; }
            set { myFM = value; }
        }
        atriumManager myatMng;
        public atriumManager AtMng
        {
            get { return myatMng; }
            set { myatMng = value; }
        }

     
        internal AdvisoryManager(FileManager fm)
            : base(fm.AppMan)
        {
            CurrentFileId = fm.CurrentFileId;
            Init(fm);

            LoadAll(false);
        }
     
        private void Init(FileManager fm)
        {
          //  cc = fm.cc;
          //  myDALClient = fm.AtMng.myDALClient;
            base.DAL = fm.DALMngr;

            myFM = fm;
            myatMng = fm.AtMng;
           // myUser = myatMng.myUser;

            RuleHandler = myatMng.RuleHandler;

            MyDS = new Advisory();
            MyDS.EnforceConstraints = false;

        }

        public override void LoadAll(bool refresh)
        {
            if(refresh)
                GetOpinion().PreRefresh();

            GetOpinion().LoadByFileId(myFM.CurrentFileId);
        }

        public override void Update(atLogic.BusinessProcess BP)
        {
            BP.AddForUpdate(DB.Opinion);
        }
        public Advisory DB
        {
            get
            {
                return (Advisory)MyDS; ;
            }
        }
 
        internal atriumDAL.atriumDALManager DALMngr
        {
            get
            {
                return myatMng.DALMngr;
            }
        }

        OpinionBE myOpinion;
        public OpinionBE GetOpinion()
        {

            if (myOpinion == null)
            {
                myOpinion = new OpinionBE(this);
            }

            return myOpinion;
        }

    }


}
