<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="imgTest.aspx.cs" Inherits="lmras.imgTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <%
      //  atriumDAL.hlpImageDAL img=mya
        atriumDAL.hlpImageDAL imgDAL = myatDAL.GethlpImage();
        lmDatasets.HelpDB.hlpImageDataTable dt = imgDAL.Load();

        foreach (lmDatasets.HelpDB.hlpImageRow dr in dt)
        {
            Response.Write(dr.FileName);
            %>
            <img src="res.aspx?f=<%: dr.FileName %>" /><br />
            <%
        }
         %>
    </div>
    </form>
</body>
</html>
