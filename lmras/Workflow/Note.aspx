<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Note.aspx.cs" Inherits="lmras.Workflow.Note" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <base target="_self" />
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
    div.frm fieldset{width:750px;}
    div.frm fieldset label{display:block;text-align:center;font-weight:bold;padding:3px;margin-left:5px;background-color:#f0f0f0;font-family:tahoma;font-size:0.9em;width:52px;border:1px solid #9a9a9a;border-bottom:none;}
    div.frm fieldset textarea{width:98%;height:120px;border:1px solid #9a9a9a;font-size:0.95em;}
    div.inn{padding-top:15px;}
    .btn{width:100px;font-size:0.9em;margin-right:12px;}
    </style>
    <script src="../Deskbook/wet20/js/lib/jquery.min.js" type="text/javascript"></script>
    <script src="../Deskbook/common/js/script.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function confirmForBdone() {
            if (confirm("You are about to delete a Documentation Note. \n\nPress OK to delete, or Cancel to return to the page without deleting the note.")) {
                document.all.oDlt.value = "1";
                document.forms[0].submit();
            }
            else {
                window.returnValue = "N";
                self.close();
            }
            
        }
        function bdone() {
            window.returnValue = "Y";
            self.close();
        }

        function Cancel() {
            window.returnValue = "N";
            self.close();
        }
        function Disable(btn) {
            document.all.oSaving.style.display = "";
            btn.disabled = true;
            document.forms[0].submit();
            return true;
        }
    </script>
  
</head>
<body>
    <form id="form1" runat="server">
   <%if (IsPostBack){ %>
   <script type="text/javascript" language="javascript">
       bdone();
   </script>
   <%} %>
    <div class="frm">
        <fieldset>
        <legend><%
                    bool okToDisplay = true;
                    bool delScrpt = false;
                    if (isInsert && !IsPostBack)
            { %>
            <img alt="" src="images/newrecord.gif" /> Add: <strong><%Response.Write(myWF.FriendlyName(docKind)); %></strong> for <strong><%: DisplayCodeString()%></strong>
            <%}
            else if (isEdit && !IsPostBack)
            { %>
            <img alt="" src="images/edit.png" /> Edit: <strong><%Response.Write(myWF.FriendlyName(docKind)); %></strong>  for <strong><%: DisplayCodeString()%></strong>
              <%}
                  else if (isDelete && !IsPostBack)
                    {
                        delScrpt = true;%>
                  <strong>Delete Note</strong>
                       
                  <%}
                    else
                    {
                        okToDisplay = false;%>
                     <strong>Invalid AC Documentation Note</strong>
                     
                  <%}%>
                  
        </legend>
        <div class="inn">
        <label>English</label><textarea rows="" cols="" class="input" id="TextEng" name="oTextEng"><asp:Literal ID="txtEng" runat="server"/></textarea><br />
        <label>French</label><textarea rows="" cols="" class="input" id="TextFre" name="oTextFre"><asp:Literal ID="txtFre" runat="server"/></textarea><br /><br />
        <div id="oSaving" style="float:left;display:none">
            <img alt="" src="images/save.png" /> <strong>Saving ... Please Wait.</strong>
        </div>
        <div style="float:right;">
            <asp:Button class="btn" id="bSave" text="Save" runat="server" OnClientClick="javascript:Disable(this);" />
            <asp:Button class="btn" id="bCancel" text="Cancel" runat="server" OnClientClick="javascript:Cancel();" />
            <input type="hidden" value="0" id="oDlt" name="dlt" />
         </div>
         </div>
         </fieldset>
    </div>
    <%if (!okToDisplay)
      {%>
          <script type="text/javascript" language="javascript">
              document.all.bSave.disabled = true;
              document.all.TextEng.disabled = true;
              document.all.TextFre.disabled = true;
                        </script> 
      <%}
          if (delScrpt)
          {%> 
          <script type="text/javascript" language="javascript">
              confirmForBdone();
                        </script>
          <%}
         %>
    </form>
</body>
</html>
