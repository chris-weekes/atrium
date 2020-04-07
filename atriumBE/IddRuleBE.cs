using System;
namespace atriumBE
{
    interface IddRuleBE
    {
        void DynAfterAdd(FileManager fm, System.Data.DataRow dr, lmDatasets.appDB.ddTableRow myDefinition);
        void DynBeforeChange(FileManager fm, System.Data.DataColumn dc, System.Data.DataRow dr, System.Collections.Generic.Dictionary<string, lmDatasets.appDB.ddFieldRow> columnMap);
        void DynBeforeDelete(FileManager fm, System.Data.DataRow dr, lmDatasets.appDB.ddTableRow myDefinition);
        void DynBeforeUpdate(FileManager fm, System.Data.DataRow dr, lmDatasets.appDB.ddTableRow myDefinition);
    }
}
