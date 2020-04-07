using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using lmDatasets;
using atriumBE.Properties;
using atLogic;


namespace atriumBE
{
    public class OfficeManager : atLogic.BEManager
    {
        private int myCurrentOfficeId;
        private int myOfficerLoggedOnId;

        public officeDB.OfficerRow CurrentOfficer
        {
            get { return DB.Officer.FindByOfficerId (myOfficerLoggedOnId); }
        }

        public officeDB.OfficeRow CurrentOffice
        {
            get { return DB.Office.FindByOfficeId( myCurrentOfficeId); }
        }


        public OfficeManager(atriumManager atMng)
            : base(atMng.AppMan)
        {
            base.DAL = atMng.DALMngr;
            myatMng = atMng;
            RuleHandler = atMng.RuleHandler;

            MyDS = new officeDB();
            MyDS.EnforceConstraints = false;
            GetOffice();

        }

        public override void Update(BusinessProcess BP)
        {
            
            BP.AddForUpdate(DB.Office,"FileOffice");
            BP.AddForUpdate(DB.ServiceCentre);
            BP.AddForUpdate(DB.Officer);
        }
      
        
        public officeDB DB
        {
            get
            {
                return (officeDB)MyDS;
            }
        }

        atriumManager myatMng;
        public atriumManager AtMng
        {
            get { return myatMng; }
            set { myatMng = value; }
        }

        ServiceCentreBE myServiceCentre;
        public ServiceCentreBE GetServiceCentre()
        {

            if (myServiceCentre == null)
            {
                myServiceCentre = new ServiceCentreBE(this);
            }

            return myServiceCentre;
        }

        private OfficerPrefsBE myOfficerPrefs;
        public OfficerPrefsBE GetOfficerPrefs()
        {

            if (myOfficerPrefs == null)
            {
                myOfficerPrefs = new OfficerPrefsBE(this);
            }

            return myOfficerPrefs;
        }

        private OfficeBE myOffice;
        public OfficeBE GetOffice()
        {

            if (myOffice == null)
            {
                myOffice = new OfficeBE(this);
            }

            return myOffice;
        }

        private ContactEmailBE myContactEmail;
        public ContactEmailBE GetContactEmail()
        {

            if (myContactEmail == null)
            {
                myContactEmail = new ContactEmailBE(this);
            }

            return myContactEmail;
        }

        private MemberProfileBE myMemberProfile;
        public MemberProfileBE GetMemberProfile()
        {
            if (myMemberProfile == null)
            {
                myMemberProfile = new MemberProfileBE(this);
            }
            return myMemberProfile;
        }

        private OfficerBE myOfficer;
        public OfficerBE GetOfficer()
        {

            if (myOfficer == null)
            {
                myOfficer = new OfficerBE(this);
            }

            return myOfficer;
        }

        private OfficerDelegateBE myOfficerDelegate;
        public OfficerDelegateBE GetOfficerDelegate()
        {

            if (myOfficerDelegate == null)
            {
                myOfficerDelegate = new OfficerDelegateBE(this);
            }

            return myOfficerDelegate;
        }

        private OfficerRoleBE myOfficerRole;
        public OfficerRoleBE GetOfficerRole()
        {

            if (myOfficerRole == null)
            {
                myOfficerRole = new OfficerRoleBE(this);
            }

            return myOfficerRole;
        }

        internal officeDB.OfficeRow GetOfficeForOfficer(string user)
        {
            OfficerBE off = GetOfficer();

            myOfficerLoggedOnId = off.Load(user).OfficerId ;
            if (CurrentOfficer == null)
                throw new AtriumException(Resources.BadUserName);


            myCurrentOfficeId = GetOffice(CurrentOfficer.OfficeId).OfficeId;
            if (CurrentOffice == null)
                throw new AtriumException(Resources.NoOffice);

            //is this needed it slows down the log in
            //off.Load();

            return CurrentOffice;
        }
        internal officeDB.OfficeRow GetOfficeForOfficer(int officerId)
        {
            OfficerBE off = GetOfficer();

            off.Load(officerId);

            myOfficerLoggedOnId = officerId ;
            if (CurrentOfficer == null)
                throw new AtriumException(Resources.BadUserName);


            myCurrentOfficeId  = GetOffice(CurrentOfficer.OfficeId).OfficeId ;
            if (CurrentOffice == null)
                throw new AtriumException(Resources.NoOffice);

            //is this needed it slows down the log in
            //off.Load();

            return CurrentOffice;
        }


        internal officeDB.OfficeRow GetOffice(string officeCode)
        {
            GetOffice();
            officeDB.OfficeRow drOff = this.myOffice.Load(officeCode);

            try
            {
                if (drOff == null)
                {
                    throw new AtriumException(Resources.BadOfficeCode);
                }

                myCurrentOfficeId  = drOff.OfficeId ;
                return drOff;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        internal officeDB.OfficeRow GetOffice(int officeID)
        {

            GetOffice();
            officeDB.OfficeRow drOff;
            try
            {
                drOff = myOffice.Load(officeID);
                if (drOff == null)
                {
                    throw new AtriumException(Resources.NoOffice);
                }

               
   
                myCurrentOfficeId = drOff.OfficeId ;
                return drOff;
            }

            catch (Exception exc)
            {
                throw exc;
            }
        }


    
        internal atriumDAL.atriumDALManager DALMngr
        {
            get
            {
                return myatMng.DALMngr;
            }
        }

   
        private atLogic.ObjectBE myOffice2JDBE;

        public atLogic.ObjectBE GetOffice2JD()
        {
            if (myOffice2JDBE == null)
            {
                if(myatMng.AppMan.UseService)
                    myOffice2JDBE = this.GetObjectBE(null, DB.Office2JD);
                else
                    myOffice2JDBE = this.GetObjectBE(DALMngr.GetOffice2JD(), DB.Office2JD);
            }

            return myOffice2JDBE;
        }

    }
}
