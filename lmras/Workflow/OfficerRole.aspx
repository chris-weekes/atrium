<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OfficerRole.aspx.cs" Inherits="lmras.Workflow.OfficerRole" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Role Members</title>
    <link href="../Deskbook/wet20/css/base.css" rel="stylesheet" type="text/css" />
	 
    <!-- clf2-nsi2 theme begins / Début du thème clf2-nsi2 -->
	<link href="../Deskbook/wet20/theme-clf2-nsi2/css/theme-clf2-nsi2.css" rel="stylesheet" type="text/css" />
  
    <!-- clf2-nsi2 theme ends / Fin du thème clf2-nsi2 -->
    <!-- CSS Grid System begins / Début du système de grille de CSS -->
    
	<link rel="stylesheet" href="../Deskbook/wet20/grids/css/grid-small.css" media="screen" type="text/css" id="grid_framework" />
	<link rel="stylesheet" href="../Deskbook/wet20/grids/css/grid.css" media="screen" type="text/css" />
	<link rel="stylesheet" href="../Deskbook/wet20/grids/css/grid-module.css" media="screen" type="text/css" />
     <style type="text/css">
    body{background-image:none;background-color:white;padding:8px;}
    img{padding-right:3px;position:relative;bottom:-2px;}
    a{color:Blue;}
    a:hover{color:Blue;}
    a:link{color:Blue;}
    a:visited{color:Blue;}
    </style>
    <script src="../Deskbook/wet20/js/lib/jquery.min.js" type="text/javascript"></script>
    <script src="../Deskbook/common/js/script.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1><% Response.Write(wTitle()); %> Global Role Members</h1>
    <table class="module-versatile2"><tr><th>Officer Code</th><th>Name</th><th>Office</th></tr>
    <%
        foreach (lmDatasets.officeDB.OfficerRoleRow offr in OrDt())
        {
            
            lmDatasets.officeDB.OfficerRow or = myWF.myACM.AtMng.GetOffice().GetOfficer().Load(offr.OfficerID);
            %>
            <tr>
                <td><%Response.Write(or.OfficerCode); %></td>
                <td><% Response.Write(or.FirstName + " " + or.LastName); %></td>
                <td><%
                    lmDatasets.officeDB.OfficeRow officeRow = myWF.myACM.AtMng.GetOffice().GetOffice().Load(or.OfficeId);
                    Response.Write("(" + officeRow.OfficeCode + ") " + officeRow.OfficeName);
                    %></td>
            </tr>
            <%
        }    
         %>

    </table>
    </div>
    </form>
</body>
</html>
