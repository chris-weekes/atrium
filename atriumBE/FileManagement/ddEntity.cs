using System;
using System.Data;
using System.Collections.Generic;
using atLogic;
using lmDatasets;

namespace atriumBE
{
    /// <summary>
    /// 
    /// </summary>
    public class ddEntityBE : atLogic.ObjectBE
    {
        FileManager myA;
        atriumDB.ddEntityDataTable myddEntityDT;
       


        

        internal ddEntityBE(FileManager pBEMng, string entityName)
            : base(pBEMng, pBEMng.DB.ddEntity, entityName)
        {



            myA = pBEMng;

            DALName = "ddEntity";

            myddEntityDT = (atriumDB.ddEntityDataTable)myDT;


            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetddEntity();
         

        }

        public atriumDAL.ddEntityDAL myDAL
        {
            get
            {
                return (atriumDAL.ddEntityDAL)myODAL;
            }
        }

        public atriumDB.ddEntityRow Load(int Id)
        {
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().ddEntityLoad(Id, myA.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.Load(Id));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.Load(Id));
                }
            }

            return myddEntityDT.FindById(Id);
        }

       

        protected override void AfterAdd(DataRow row)
        {
            atriumDB.ddEntityRow dr = (atriumDB.ddEntityRow)row;
            string ObjectName = "ddEntity";

            dr.Id = myA.AtMng.PKIDGet(ObjectName, 10);
            dr.TableId = myDefinition.TableId;
            dr.FileId = myA.CurrentFileId;

            dr.AFlag = false;
            dr.BFlag = false;
            dr.CFlag = false;
            dr.DFlag = false;
            dr.EFlag = false;
            dr.FFlag = false;
            dr.GFlag = false;
            dr.HFlag = false;
            dr.IFlag = false;
            dr.JFlag = false;

       
           // myA.AtMng.GetddRule().DynAfterAdd(myA, dr, myDefinition);
        }

        public object this[atriumDB.ddEntityRow entRow, string fieldName]
        {
            get
            {
                return entRow[columnMap[fieldName].DBFieldName];
            }
            set
            {
                entRow[columnMap[fieldName].DBFieldName] = value;
            }

        }
        public override void Validate(DataRow dr)
        {
            base.Validate(dr);
        }

        protected override void AfterChange(DataColumn dc, DataRow dr)
        {
            
        }
        protected override void BeforeChange(DataColumn dc, DataRow dr)
        {
           // myA.RuleHandler.DynBeforeChange(myA, dc, dr,columnMap);
        }
        protected override void BeforeAdd(DataRow dr)
        {
          //  base.BeforeAdd(dr);
        }
        protected override void BeforeUpdate(DataRow dr)
        {
          //  myA.AtMng.GetddRule().DynBeforeUpdate(myA, dr, myDefinition,columnMap);
        }
        protected override void BeforeDelete(DataRow dr)
        {

         //   myA.AtMng.GetddRule().DynBeforeDelete(myA, dr,myDefinition);
        }
        
        public override bool CanAdd(DataRow parent)
        {
            return base.CanAdd(parent);
        }
        public override bool CanRead(DataRow dr)
        {
            return base.CanRead(dr);
        }
        public override bool CanDelete(DataRow dr)
        {
            return base.CanDelete(dr);
        }
        public override bool CanEdit(DataRow row)
        {
            atriumDB.ddEntityRow dr = (atriumDB.ddEntityRow)row;
            if (!myDefinition.IsFeatureIdNull())
            {
                atSecurity.SecurityManager.LevelPermissions perm = myA.AtMng.SecurityManager.CanUpdate(dr.FileId, (atSecurity.SecurityManager.Features)myDefinition.FeatureId);
                return AllowEdit | perm > atSecurity.SecurityManager.LevelPermissions.No;
            }
            else
                return true;
        }
    
    }
}

