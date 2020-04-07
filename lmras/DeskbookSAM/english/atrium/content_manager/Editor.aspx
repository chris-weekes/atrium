<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Editor.aspx.cs" Inherits="SSTDeskBooks.english.atrium.content_manager.Editor" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=8" />
    <link rel="schema.dc" href="http://purl.org/dc/elements/1.1/" />
    <link rel="schema.dcterms" href="http://purl.org/dc/terms/" />
    <!-- Web Experience Toolkit (wayne) / Boîte à outils de l'expérience Web (BOEW)
	Terms and conditions of use: http://tbs-sct.ircan.gc.ca/projects/gcwwwtemplates/wiki/Terms
	Conditions régissant l'utilisation : http://tbs-sct.ircan.gc.ca/projects/gcwwwtemplates/wiki/Conditions
	-->
    <!-- Title begins / Début du titre -->
    <!-- TemplateBeginEditable name="English title | Titre anglais" -->
    <title>SAM Content Editor</title>
    <!-- TemplateEndEditable -->
    <!-- Title ends / Fin du titre -->

    <!-- Favicon (optional) begins / Début du favicon (optionnel) -->
    <link rel="shortcut icon" href="../../../wet20/favicon.ico" />
    <!-- Favicon (optional) ends / Find du favicon (optionnel) -->

    <!-- Metadata begins / Début des métadonnées -->
    <!-- TemplateBeginEditable name="English metadata | Metadonnées anglaises" -->
    <meta name="dc.title" content="SAM Content Editor" />
    <meta name="dc.description" content="SAM Content Editor" />
    <meta name="description" content="" />
    <meta name="dc.subject" title="SAM Content Editor" content="" />
    <meta name="keywords" content="" />
    <meta name="dc.creator" content="" />
    <meta name="owner" content="" />
    <meta name="dc.publisher" content="" />
    <meta name="dc.language" title="ISO639-2" content="eng" />
    <meta name="dcterms.issued" title="W3CDTF" content="" />
    <meta name="dcterms.modified" title="W3CDTF" content="" />
    <meta name="dcterms.audience" title="CRAaudience" content="" />
    <meta name="dc.type" title="gctype" content="" />
    <meta name="dcterms.spatial" title="CRAgeonames" content="" />
    <meta name="robots" content="index,follow" />
    <meta name="dc.identifier" content="" />
    <meta name="metaQA" content="" />
    <!-- TemplateEndEditable -->
    <!-- Metadata ends / Fin des métadonnées -->
    <!-- WET scripts/CSS begin / Début des scripts/CSS de la BOEW -->
    <!--[if IE 6]><![endif]-->

    <link href="../../../wet20/css/base.css" rel="stylesheet" type="text/css" />


    <!-- clf2-nsi2 theme begins / Début du thème clf2-nsi2 -->
    <link href="../../../wet20/theme-clf2-nsi2/css/theme-clf2-nsi2.css" rel="stylesheet" type="text/css" />


    <!-- clf2-nsi2 theme ends / Fin du thème clf2-nsi2 -->
    <!-- CSS Grid System begins / Début du système de grille de CSS -->
    <link rel="stylesheet" href="../../../wet20/grids/css/grid-small.css" media="screen" type="text/css" id="grid_framework" />
    <link rel="stylesheet" href="../../../wet20/grids/css/grid.css" media="screen" type="text/css" />
    <link rel="stylesheet" href="../../../wet20/grids/css/grid-module.css" media="screen" type="text/css" />
    <!-- CSS Grid System ends / Fin du système de grille de CSS -->
    <!-- WET scripts/CSS end / Fin des scripts/CSS de la BOEW -->


    <!-- Progressive enhancement begins / Début de l'amélioration progressive -->
    <script src="../../../wet20/js/lib/jquery.min.js" type="text/javascript"></script>
    <script src="../../../wet20/js/pe-ap.js" type="text/javascript" id="progressive"></script>
    <script src="../common/js/script.js" type="text/javascript"></script>


    <!-- TemplateEndEditable -->


    <!-- Progressive enhancement ends / Fin de l'amélioration progressive -->

    <!-- Custom scripts/CSS begin / Début des scripts/CSS personnalisés -->
    <link href="../../../wet20/intranet/css/default.css" rel="stylesheet" media="screen" type="text/css" />
    <link href="../../../wet20/intranet/css/pf-if.css" rel="stylesheet" media="print" type="text/css" />

    <!-- TemplateBeginEditable name="Scripts/CSS" -->
    <script src="../../../wet20/js/plugins/font-replacement.js" type="text/javascript"></script>
    <!-- TemplateEndEditable -->
    <!-- Custom scripts/CSS end / Fin des scripts/CSS personnalisés -->


    <!-- WET print CSS begins / Début du CSS de la BOEW pour l'impression -->
    <link href="../../../wet20/css/pf-if.css" rel="stylesheet" media="print" type="text/css" />
    <!-- clf2-nsi2 theme begins / Début du thème clf2-nsi2 -->
    <link href="../../../wet20/theme-clf2-nsi2/css/pf-if-theme-clf2-nsi2.css" rel="stylesheet" media="print" type="text/css" />
    <!-- clf2-nsi2 theme ends / Fin du thème clf2-nsi2 -->

    <!-- admin styles begins-->
    <link href="../common/css/lsu_styles.css" rel="stylesheet" media="screen" type="text/css" />
    <link href="../common/css/adminstyles.css" rel="stylesheet" media="screen" type="text/css" />
    <link href="../common/css/adminstyles2.css" rel="stylesheet" media="screen" type="text/css" />
    <link href="../common/css/jquery-linedtextarea.css" rel="stylesheet" media="screen" type="text/css" />
    <!-- admin styles end-->

    <!-- WET print CSS ends / Fin du CSS de la BOEW pour l'impression -->


</head>
<body>




    <form id="frmEditMenu" runat="server">
        <div>
            <asp:HiddenField ID="path" runat="server" />
            <asp:HiddenField ID="id" runat="server" />
            <asp:HiddenField ID="inc" runat="server" />
            <asp:HiddenField ID="title" runat="server" />
            <asp:HiddenField ID="vfilefull" runat="server" />
            <asp:HiddenField ID="type" runat="server" />
            <%--
<%if (errMessage != "")%>
    <h2><%= errMessage %></h2>--%>

            <%
                if (errMessage != null && errMessage != "") { Response.Write("<h2>" + errMessage + "</h2>"); }


                string lnk;
                string lbl;
                if (Request.QueryString["inc"]=="eng")
                {
                    lnk="fre";
                    lbl="French Content";
                }
                else
                {
                    lnk="eng";
                    lbl = "English Content";
                }
            %>


            <table class="editorTblHeader" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td nowrap="true">Page ID:</td>

                    <td nowrap="true"><strong><%=Request.QueryString["id"]%></strong></td>
                    <td nowrap="true">Name:</td>

                    <td nowrap="true"><strong><%=vPageName%></strong></td>
                    <%--<td nowrap="true">Title:</td>
		<td nowrap="true"><strong><%=Request.QueryString["title"]%></strong></td>--%>
                    <td nowrap="true">Last Accessed:</td>
                    <td nowrap="true"><strong><%
                                  if( HasAccess == true) 
                                      Response.Write(vAccessedDate + " (" + vAccessedPerson +")" );  
                                  else 
                                      Response.Write("Not Available"); %></strong></td>
                    <td nowrap="true">Last Saved:</td>
                    <td nowrap="true" style="width: 100%"><strong><%if (HasUpdate == true)
                                       Response.Write(vUpdateDate +  " (" + vUpdatePerson + ")") ;
                                    else 
                                       Response.Write("Not Available" );%></strong></td>
                </tr>


            </table>

            
            <table class="editorTblHeader" border="0" cellspacing="0" cellpadding="0" style="width: 100%; color: Black;<%if (displayAccessMessage == false && displayUpdateMessage == false) Response.Write("display:none"); %>">

                <tr valign="top">
                    <td><%  if( displayAccessMessage == true)%>
                        <div <%=style%>><%=img%><%=imgText%></div>
                    </td>
                    <td><%if (displayUpdateMessage ==true)%>
                        <div <%=updateStyle%>><%=UpdateImg%><%=UpdateImgText%></div>
                    </td>
                </tr>

            </table>


            <table class="editorTblHeader2" border="0" cellspacing="0" cellpadding="0" style="margin: 6px 0 6px 0;">
                <tr valign="top">

                    <td nowrap="nowrap">
                        <button id="btnEditorSave" class="btn" type="submit" onclick="inFormOrLink = true;">
                            <div class="bImg bSave"></div>
                            <span class="spnBtn">Save</span>
                        </button>
                        <button class="btn" type="button" onclick="refreshEditor(); inFormOrLink = true;">
                            <div class="bImg bRefresh"></div>
                            <span class="spnBtn">Refresh</span>
                        </button>
                        <button class="btn" type="button" onclick="window.close(); inFormOrLink = true;">
                            <div class="bImg bCancelEditor"></div>
                            <span class="spnBtn">Close/No Save</span>
                        </button>
                    </td>
                    <td nowrap="true">
                        <div class="divBtn">
                            <a id="langAnchor" class="langLnk" onclick="verifyEdit('editor.aspx?inc=<%=lnk%>&amp;id=<%=Request.QueryString["id"]%>&amp;title=<%=Request.QueryString["title"]%>');" href="javascript:"><%=lbl %></a>
                        </div>
                    </td>
                </tr>
            </table>

            <div class="divEdit" id="cssTopDiv">
                <div class="divToolbar">
                    <div class="toolbarTitle">
                        <img class="tlbrImg" onclick="tbExpand(this, taPgCSS, cssToolbar);" src="images/minus.gif" alt="Expand/Collapse" />Page-Level CSS
                    </div>
                    <span id="cssToolbar">
                        <img class="toolbarBtn" onmouseover="toolbarRaise(this);" onmouseout="toolbarOff(this);" onclick="updateFontSize(this, document.frmEditMenu.pgCSS);" src="images/fontSize.png" alt="Increase/Decrease Font Size" />
                        <img class="toolbarBtn" onmouseover="toolbarRaise(this);" onmouseout="toolbarOff(this);" onclick="taWrapText(document.frmEditMenu.pgCSS, this);" curval="on" src="images/wordwrap.png" alt="Wrap Text" />
                        <img class="toolbarBtn" onmouseover="toolbarRaise(this);" onmouseout="toolbarOff(this);" onclick="taExtend(document.frmEditMenu.pgCSS, this);" src="images/extend.png" alt="Increase Textarea Size" />
                    </span>
                    <div id="cssEditFlag" class="editFlag">CSS Edited</div>
                </div>
                <textarea onchange="taTextChanged(cssTopDiv, cssEditFlag);" name="pgCSS" id="taPgCSS"><%=pgCSS%></textarea>
                <textarea id="taPgCSSOriginal"><%=pgCSS%></textarea>
            </div>

            <div class="divEdit" id="contentTopDiv">
                <div class="divToolbar">
                    <div class="toolbarTitle">
                        <img class="tlbrImg" onclick="tbExpand(this, oEditorTextArea, contentToolbar);" src="images/minus.gif" alt="Expand/Collapse" />Page Content
                    </div>
                    <span id="contentToolbar">
                        <img class="toolbarBtn" onmouseover="toolbarRaise(this);" onmouseout="toolbarOff(this);" onclick="updateFontSize(this, document.frmEditMenu.stream);" src="images/fontSize.png" alt="Increase/Decrease Font Size" />
                        <img class="toolbarBtn" onmouseover="toolbarRaise(this);" onmouseout="toolbarOff(this);" onclick="taWrapText(document.frmEditMenu.stream, this);" curval="on" src="images/wordwrap.png" alt="Wrap Text" />
                        <img class="toolbarBtn" onmouseover="toolbarRaise(this);" onmouseout="toolbarOff(this);" onclick="taExtend(document.frmEditMenu.stream, this);" src="images/extend.png" alt="Increase Textarea Size" />
                        <span class="pipe"></span>
                        <img class="toolbarBtn" onmouseover="toolbarRaise(this);" onmouseout="toolbarOff(this);" onclick="format_sel('h2');" src="images/h2.png" alt="Insert Heading 2" />
                        <img class="toolbarBtn" onmouseover="toolbarRaise(this);" onmouseout="toolbarOff(this);" onclick="format_sel('h3');" src="images/h3.png" alt="Insert Heading 3" />
                        <span class="pipe"></span>
                        <img class="toolbarBtn" onmouseover="toolbarRaise(this);" onmouseout="toolbarOff(this);" onclick="format_sel('p');" src="images/paragraph.png" alt="Insert Paragraph" />
                        <img class="toolbarBtn" onmouseover="toolbarRaise(this);" onmouseout="toolbarOff(this);" onclick="format_sel('strong');" src="images/bold.png" alt="Click to Make your Selection Bold" />
                        <img class="toolbarBtn" onmouseover="toolbarRaise(this);" onmouseout="toolbarOff(this);" onclick="format_sel('em');" src="images/italic.png" alt="Click to Make your Selection Italic" />
                        <span class="pipe"></span>
                        <img class="toolbarBtn" onmouseover="toolbarRaise(this);" onmouseout="toolbarOff(this);" onclick="format_sel('img');" src="images/image.png" alt="Insert Image" />
                        <img class="toolbarBtn" onmouseover="toolbarRaise(this);" onmouseout="toolbarOff(this);" onclick="format_sel('pgid');" src="images/document.png" alt="Insert Link To Page" />
                        <img class="toolbarBtn" onmouseover="toolbarRaise(this);" onmouseout="toolbarOff(this);" onclick="format_sel('a');" src="images/hyperlink.png" alt="Insert Anchor" />
                        <img class="toolbarBtn" onmouseover="toolbarRaise(this);" onmouseout="toolbarOff(this);" onclick="format_sel('br');" src="images/linebreak.png" alt="Insert Line Break" />
                        <span class="pipe"></span>
                        <img class="toolbarBtn" onmouseover="toolbarRaise(this);" onmouseout="toolbarOff(this);" onclick="format_sel('table');" src="images/table.png" alt="Insert Table" />
                        <img class="toolbarBtn" onmouseover="toolbarRaise(this);" onmouseout="toolbarOff(this);" onclick="format_sel('ol');" src="images/ol.png" alt="Insert Ordered List" />
                        <img class="toolbarBtn" onmouseover="toolbarRaise(this);" onmouseout="toolbarOff(this);" onclick="format_sel('ul');" src="images/ul.png" alt="Insert Unordered List" />
                        <img class="toolbarBtn" onmouseover="toolbarRaise(this);" onmouseout="toolbarOff(this);" onclick="format_sel('li');" src="images/li.png" alt="Insert List Item" />
                        <span class="pipe"></span>
                        <select name="acronymSelector" id="acronymInsert" onchange="insertAcronym();" class="input select" style="font-size: 85%; width: 90px; position: relative; top: -2px;">
                            <option value="">Acronyms</option>
                            <% loadListItems();%>
                            <option value="[Full Description]">[Blank Abbr Tag]</option>
                        </select>
                        <button class="btn" id="oCharCheck" type="button" onclick="charChecker();">
                            <div class="bImg bSChar"></div>
                            <span class="spnBtn">Character Checker</span>
                        </button>

                    </span>
                    <div id="contentEditFlag" class="editFlag">Content Edited</div>
                </div>

                <textarea onchange="taTextChanged(contentTopDiv, contentEditFlag);" id="oEditorTextArea" name="stream"><%=vStream%></textarea>
                <textarea id="oEditorTextAreaOriginal"><%=vStream%></textarea>
            </div>

            <div class="divEdit">
                <div class="divToolbar">
                    <div class="toolbarTitle">
                        <img id="oPreviewExpandCollapse" class="tlbrImg" onclick="tbExpand(this, oPreview, previewToolbar);" src="images/minus.gif" alt="Expand/Collapse" />Preview
                    </div>
                    <span id="previewToolbar">
                        <img class="toolbarBtn" onmouseover="toolbarRaise(this);" onmouseout="toolbarOff(this);" onclick="contentPreview();" src="images/refresh.png" alt="Refresh Preview" />
                        <img class="toolbarBtn" onmouseover="toolbarRaise(this);" onmouseout="toolbarOff(this);" onclick="taExtend(oPreview, this);" src="images/extend.png" alt="Increase Preview Window Size" />
                        <div style="margin-top: 2px; font-size: 85%; padding: 3px;"><strong>Note:</strong> Although links can be clicked from within the preview view, link paths are not accurate.  Therefore, link verification should not be performed from this page. Also, any data that is generated through the use of XML/XSL transformations does not get rendered in the preview window.</div>
                    </span>
                </div>
                <div id="oPreview" style="width: 99%; border: 1px solid #999999; overflow: auto; height: 250px; background-color: #ffffff; padding: 4px;"></div>
            </div>


            <script type="text/javascript">
                var t = setTimeout("resizeTA(document.frmEditMenu.pgCSS, 'off')", 200);
                var u = setTimeout("resizeTA(document.frmEditMenu.stream, 'off')", 300);
                var s = setTimeout("CheckEditorPreviewCookies()", 250);
                var inFormOrLink;

                $(document).ready(function () {


                    $(window).bind("beforeunload", function () {
                       // alert(inFormOrLink);
                        if (inFormOrLink == true) {
                            inFormOrLink = false;
                        }
                        else {
                            inFormOrLink = true;
                            return inFormOrLink ? "Do you really want to close?" : null;
                        }
                    })
                });


            </script>

        </div>
    </form>

</body>
</html>
