using System;
using System.Collections.Generic;
using System.Text;
using atriumBE;
using lmDatasets;
using System.Data;
using System.Windows.Forms;

 namespace LawMate
{
    public class Search
    {
        atriumManager AtMng;
        BindingSource Bs;
        public Search(atriumManager atmng, BindingSource bs)
        {
            AtMng = atmng;
            Bs = bs;
        }

        public int DoSearch(atLogic.WhereClause wc, atLogic.WhereClause wcContact, atLogic.WhereClause wcCaseStatus, bool includeXrefs)
        {
            appDB.EFileSearchDataTable dt;
            dt = this.AtMng.FileSearch(wc,wcContact,wcCaseStatus, includeXrefs);

            Bs.DataSource = dt;

            return dt.Rows.Count;
        }

        public int DoSearch(string userName,DateTime dateStart, DateTime dateEnd)
        {
            appDB.EFileSearchDataTable dt;
            dt = AtMng.FileSearchByRecentFiles(userName, dateStart, dateEnd);

            Bs.DataSource = dt;

            return dt.Rows.Count;
        }
        public int DoSearch(int contactId, string contactType)
        {
            appDB.EFileSearchDataTable dt;
            dt = AtMng.FileSearchByContact(contactId, contactType);

            System.Diagnostics.Trace.WriteLine("searchc", "bind");

            Bs.DataSource = dt;

            return dt.Rows.Count;
        }
        public int DoSearch(string searchCriteria, string searchForType)
        {
            appDB.EFileSearchDataTable dt;
            switch (searchForType)
            {
                case OfficerPrefsBE.qsiCaseFileNumber:
                    dt = AtMng.FileSearchByICASE(searchCriteria);
                    break;
                case OfficerPrefsBE.qsSIN:
                    dt = AtMng.FileSearchBySIN(searchCriteria);
                    break;
                case OfficerPrefsBE.qsOfficeFileNumber:
                    dt = AtMng.FileSearchByOfficeFileNum(searchCriteria);
                    break;
                case OfficerPrefsBE.qsLastName:
                    dt = AtMng.FileSearchByLastName(searchCriteria);
                    break;
                case OfficerPrefsBE.qsFileNumber:
                    dt = AtMng.FileSearchByFileNumber(searchCriteria);
                    break;
                case OfficerPrefsBE.qsFullFileNumber:
                    dt = AtMng.FileSearchByFullFileNumber(searchCriteria);
                    break;
                case "qsFileName":
                case OfficerPrefsBE.qsFileNameEng:
                case OfficerPrefsBE.qsFileNameFre:
                    dt = AtMng.FileSearchByKeyword(searchCriteria);
                    break;
                case OfficerPrefsBE.qsFullFileName:
                    dt = AtMng.FileSearchByFullFileName(searchCriteria);
                    break;
                default:
                    dt = null;
                    break;
            }
            System.Diagnostics.Trace.WriteLine("search", "bind");

            Bs.DataSource = dt;

            Bs.MoveFirst();

            return dt.Rows.Count;

        }
    }
}
