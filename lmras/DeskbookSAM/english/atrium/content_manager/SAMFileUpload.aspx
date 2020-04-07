<%@ Page Title="" Language="C#" MasterPageFile="~/DeskbookSAM/english/atrium/content_manager/SAM.Master" AutoEventWireup="true" CodeBehind="SAMFileUpload.aspx.cs" Inherits="SSTDeskBooks.english.atrium.content_manager.SAMFileUpload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<fieldset>
      <legend>
        <strong>
         File to Upload
        </strong>
      </legend>
      <div class="span-5">
       <%--<label class="lbl" for="id">File*:</label>
       <input type="file" class="input" name="file1"/>--%>
       <asp:Label ID="Label1" runat="server" Text="File*:"></asp:Label>
    
          <asp:FileUpload ID="FileUploadMulti" runat="server" AllowMultiple="true" />

      </div>
 </fieldset>
 <fieldset>
      <div class="span-5 buttonrow">
        <button class="btn" type="submit" name="btnAction" value="Upload File" style="margin-left:30px;">
          <div class="bImg bUpload"></div>
          <span>Upload File</span>
        </button>
        <button class="btn" type="reset" name="btnAction" value="Reset" onclick="resetImgUpload();">
          <div class="bImg bCancel"></div>
          <span>Reset</span>
        </button>
      </div>
    </fieldset>

<%if (NoFiles == true)
  {%>
<div class="span-5 module-alert" style="margin-bottom:12px" id="oNoFileSelected">
<h2>File Upload Error</h2>
<p>No file was selected for upload.</p>
</div>
<%}%>
        
 
    
</asp:Content>
