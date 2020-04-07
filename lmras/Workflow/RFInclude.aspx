<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RFInclude.aspx.cs" Inherits="lmras.Workflow.RFInclude" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Included Related Fields Data</title>
    <link href="../Deskbook/wet20/css/base.css" rel="stylesheet" type="text/css" />
	 
    <!-- clf2-nsi2 theme begins / Début du thème clf2-nsi2 -->
	<link href="../Deskbook/wet20/theme-clf2-nsi2/css/theme-clf2-nsi2.css" rel="stylesheet" type="text/css" />
  
    <!-- clf2-nsi2 theme ends / Fin du thème clf2-nsi2 -->
    <!-- CSS Grid System begins / Début du système de grille de CSS -->
    
	<link rel="stylesheet" href="../Deskbook/wet20/grids/css/grid-small.css" media="screen" type="text/css" id="grid_framework" />
	<link rel="stylesheet" href="../Deskbook/wet20/grids/css/grid.css" media="screen" type="text/css" />
	<link rel="stylesheet" href="../Deskbook/wet20/grids/css/grid-module.css" media="screen" type="text/css" />
    <link rel="stylesheet" href="css/wfstyles.css" media="screen" type="text/css" />

    <script src="../Deskbook/wet20/js/lib/jquery.min.js" type="text/javascript"></script>
    <script src="../Deskbook/common/js/script.js" type="text/javascript"></script>
</head>
<body  id="b1">
    <form id="form1" runat="server">
    <div>
    <%
        lmDatasets.ActivityConfig.ActivityFieldRow[] InitiateFlds = (lmDatasets.ActivityConfig.ActivityFieldRow[])myWF.myACM.DB.ActivityField.Select("ACSeriesId=" + acs.ACSeriesId.ToString() + " and step=-10", "Seq");
         if (InitiateFlds.Length > 0)
            {%>
            <div class="stpLnk2"><a name="InitBlock"></a><img alt="" src="images/relFields.png" /><strong>Included <%:acs.StepCode %> Records for <%:hostAcs.StepCode %></strong></div>
            <div class="clear"></div>
            <div class="bx">
            <table class="module-versatile2"><tr><th>Task</th><th>Table</th><th>Field</th><th>Object Alias</th><th>Parent Row</th><th>Default Value</th></tr>
            <% 
                foreach (lmDatasets.ActivityConfig.ActivityFieldRow afr in InitiateFlds)
                {
                      Response.Write(myWF.UsedRecordsHTMLOutput(afr));
                }%>
                </table></div><div class="clear"></div><br />
            <%}
    %>
    
    </div>
    </form>
</body>
</html>
