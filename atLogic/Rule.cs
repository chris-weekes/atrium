using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atLogic
{
    public interface IRuleHandler
    {
        void DynAfterAdd(BEManager  fm, System.Data.DataRow dr, lmDatasets.appDB.ddTableRow myDefinition);
        void DynAfterDelete(BEManager fm, System.Data.DataRow dr, lmDatasets.appDB.ddTableRow myDefinition);
        void DynAfterUpdate(BEManager fm, System.Data.DataRow dr, lmDatasets.appDB.ddTableRow myDefinition);
        void DynAfterChange(BEManager fm, System.Data.DataColumn dc, System.Data.DataRow dr, System.Collections.Generic.Dictionary<string, lmDatasets.appDB.ddFieldRow> columnMap);
        void DynBeforeChange(BEManager fm, System.Data.DataColumn dc, System.Data.DataRow dr, System.Collections.Generic.Dictionary<string, lmDatasets.appDB.ddFieldRow> columnMap);
        void DynBeforeAdd(BEManager fm, System.Data.DataRow dr, lmDatasets.appDB.ddTableRow myDefinition);
        void DynBeforeDelete(BEManager fm, System.Data.DataRow dr, lmDatasets.appDB.ddTableRow myDefinition);
        void DynBeforeUpdate(BEManager fm, System.Data.DataRow dr, lmDatasets.appDB.ddTableRow myDefinition, System.Collections.Generic.Dictionary<string, lmDatasets.appDB.ddFieldRow> columnMap);
        lmDatasets.appDB.ddTableRow GetMyDefinition(string entityName);
        
    }

    public interface ICodeRule
    {
        
        void ExecuteRule(BEManager fm, lmDatasets.appDB.ddRuleRow thisRule, System.Data.DataRow rowToCheck, System.Data.DataColumn columnToCheck,string msg);
    }

    public interface ICodeAction
    {

        void ExecuteRule(BEManager fm, lmDatasets.appDB.ddRuleRow thisRule, System.Data.DataRow rowToCheck, System.Data.DataColumn columnToCheck);
    }
}
