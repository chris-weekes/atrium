<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SAMEditorSelector.aspx.cs" Inherits="lmras.DeskbookSAM.english.atrium.content_manager.SAMEditorSelector" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
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
	<title>Tag Selector</title>
	<!-- TemplateEndEditable -->
	<!-- Title ends / Fin du titre -->
	
	<!-- Favicon (optional) begins / Début du favicon (optionnel) -->
	<link rel="shortcut icon" href="../../../wet20/favicon.ico" />
	<!-- Favicon (optional) ends / Find du favicon (optionnel) -->
	
	<!-- Metadata begins / Début des métadonnées -->
	<!-- TemplateBeginEditable name="English metadata | Metadonnées anglaises" -->
	<meta name="dc.title" content="" /> 
	<meta name="dc.description" content="" />
	<meta name="description" content="" /> 
	<meta name="dc.subject" title="Legal Services Branch Site Admin Module" content="" /> 
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

	<!-- WET scripts/CSS begin / Début des scripts/CSS de la BOEW --><!--[if IE 6]><![endif]-->
	<link href="../../../wet20/css/base.css" rel="stylesheet" type="text/css" />
	<!--[if IE 8]><link href="../../../wet20/css/base-ie8.css" rel="stylesheet" type="text/css" /><![endif]-->
	<!--[if IE 7]><link href="../../../wet20/css/base-ie7.css" rel="stylesheet" type="text/css" /><![endif]-->
	<!--[if lte IE 6]><link href="../../../wet20/css/base-ie6.css" rel="stylesheet" type="text/css" /><![endif]-->
    <!-- clf2-nsi2 theme begins / Début du thème clf2-nsi2 -->
	<link href="../../../wet20/theme-clf2-nsi2/css/theme-clf2-nsi2.css" rel="stylesheet" type="text/css" />
	<!--[if IE 7]><link href="../../../wet20/theme-clf2-nsi2/css/theme-clf2-nsi2-ie7.css" rel="stylesheet" type="text/css" /><![endif]-->
	<!--[if lte IE 6]><link href="../../../wet20/theme-clf2-nsi2/css/theme-clf2-nsi2-ie6.css" rel="stylesheet" type="text/css" /><![endif]-->
    <!-- clf2-nsi2 theme ends / Fin du thème clf2-nsi2 -->
    <!-- CSS Grid System begins / Début du système de grille de CSS -->
	<link rel="stylesheet" href="../../../wet20/grids/css/grid-small.css" media="screen" type="text/css" id="grid-framework" />
	<link rel="stylesheet" href="../../../wet20/grids/css/grid.css" media="screen" type="text/css" />
	<link rel="stylesheet" href="../../../wet20/grids/css/grid-module.css" media="screen" type="text/css" />
    <!-- CSS Grid System ends / Fin du système de grille de CSS -->
	<!-- WET scripts/CSS end / Fin des scripts/CSS de la BOEW -->

	<!-- Progressive enhancement begins / Début de l'amélioration progressive -->
	<script src="../../../wet20/js/lib/jquery.min.js" type="text/javascript"></script>
    <script src="../common/js/script.js" type="text/javascript"></script>   
    <script type="text/javascript">

        function loadHTML() {
            var oMyObject = window.dialogArguments;
            var vTag = oMyObject.tag;
            switch (vTag) {
                case "table":
                    tableTag.style.display = "";
                    break;
                case "ol":
                    olTag.style.display = "";
                    break;
                case "ul":
                    ulTag.style.display = "";
                    break;
                case "a":
                    aTag.style.display = "";
            }
        }
        function insertTable() {
            returnTag = "<table";
            if (document.editor.tblBorder.value != "") {
                returnTag += ' border="' + document.editor.tblBorder.value + '"';
            }
            if (document.editor.tblWidth.value != "") {
                returnTag += ' width="' + document.editor.tblWidth.value + '"';
            }
            if (document.editor.tblAlign.value != "") {
                returnTag += ' align="' + document.editor.tblAlign.value + '"';
            }
            if (document.editor.tblcellP.value != "") {
                returnTag += ' cellpadding="' + document.editor.tblcellP.value + '"';
            }
            if (document.editor.tblcellS.value != "") {
                returnTag += ' cellspacing="' + document.editor.tblcellS.value + '"';
            }
            returnTag += ">"
            for (var rows = 0; rows < document.editor.tblRows.value; rows++) {
                returnTag += "\n	<tr>";
                for (var columns = 0; columns < document.editor.tblColumns.value; columns++) {
                    returnTag += "\n		<td></td>";
                }
                returnTag += "\n	</tr>";
            }

            returnTag += "\n</table>";
            returnValue = returnTag;
            self.close();
        }

        function insertOL() {
            returnTag = '<ol type="';
            switch (document.editor.olType.value) {
                case "a":
                    returnTag += 'a"';
                    break;
                case "A":
                    returnTag += 'a"';
                    break;
                case "i":
                    returnTag += 'a"';
                    break;
                case "I":
                    returnTag += 'a"';
                    break;
                default:
                    returnTag += '1"';
                    break;
            }
            if (document.editor.olStart.value != "") {
                returnTag += ' start="' + document.editor.olStart.value + '"';
            }
            returnTag += '>';
            for (var rows = 0; rows < document.editor.olRows.value; rows++) {
                returnTag += "\n	<li></li>";
            }

            returnTag += "\n</ol>";
            returnValue = returnTag;
            self.close();
        }
        function insertUL() {
            returnTag = '<ul type="' + document.editor.ulType.value + '">';
            for (var rows = 0; rows < document.editor.ulRows.value; rows++) {
                returnTag += "\n	<li></li>";
            }

            returnTag += "\n</ul>";
            returnValue = returnTag;
            self.close();
        }
        function insertA() {
            returnTag = '<a';
            if (document.editor.aHref.value != "") {
                returnTag += ' href="' + document.editor.aHref.value + '"';
            }
            if (document.editor.aTarget.checked) {
                returnTag += ' target="_blank"';
            }
            if (document.editor.aName.value != "") {
                returnTag += ' name="' + document.editor.aName.value + '"';
            }
            returnTag += '>';
            returnValue = returnTag;
            self.close();
        }
        function checkForEscape() {
            if (event.keyCode == '27') {
                returnValue = '';
                self.close();
            }
        }
	</script>
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
    <link href="../common/css/adminstyles.css" rel="stylesheet" media="screen" type="text/css" />
    <!-- admin styles end-->

	<!-- WET print CSS ends / Fin du CSS de la BOEW pour l'impression -->
    <base target="_self" />
</head>

<body onload="loadHTML();" onkeydown="checkForEscape();">
    <form id="editor" runat="server">
   

<div id="tableTag" class="span-4 module-form-fluid-none" style="margin:14px;display:none;">
 <fieldset>
      <legend>
        <strong>
          Insert Table
        </strong>
      </legend>
       <div class="span-4">
        <label class="lbl"># of Colums</label>
        <input type="text" class="input shrt" name="tblColumns" value="1" />
      </div>
       <div class="span-4">
        <label class="lbl"># of Rows</label>
        <input type="text" class="input shrt" name="tblRows" value="1" />
      </div>
      <div class="span-4">
        <label class="lbl">Border (px)</label>
        <input type="text" class="input shrt" name="tblBorder" />
      </div>
      <div class="span-4">
        <label class="lbl">Width (px)</label>
        <input type="text" class="input shrt" name="tblWidth" />
      </div>
      <div class="span-4">
        <label class="lbl">Align</label>
       <select name="tblAlign" class="input shrtSelect">
		    <option value="left">Left</option>
		    <option value="center">Center</option>
		    <option value="right">Right</option>
	    </select>
      </div>
      <div class="span-4">
        <label class="lbl">Cellpadding (px)</label>
        <select class="input shrtSelect" name="tblcellP">
            <option value="0">0</option>
			<option value="1">1</option>
			<option value="2">2</option>
			<option value="3">3</option>
			<option value="4">4</option>
			<option value="5">5</option>
        </select>
      </div>
      <div class="span-4">
        <label class="lbl">Cellspacing (px)</label>
        <select class="input shrtSelect" name="tblcellS">
            <option value="0">0</option>
			<option value="1">1</option>
			<option value="2">2</option>
			<option value="3">3</option>
			<option value="4">4</option>
			<option value="5">5</option>
        </select>
      </div>
    </fieldset>
    <fieldset>
      <div class="span-4 buttonrow">
        <button class="btn" value="OK" onclick="insertTable();">
          <div class="bImg bOK"></div>
          <span>OK</span>
        </button>
        <button class="btn" value="Cancel" onclick="returnValue='';self.close();">
          <div class="bImg bCancel"></div>
          <span>Cancel</span>
        </button>
      </div>
    </fieldset>
	
</div>
<div id="olTag" class="span-4 module-form-fluid-none" style="margin:14px;display:none;">
	<fieldset>
      <legend>
        <strong>Insert Ordered List</strong>
      </legend>
	  <div class="span-4">
        <label class="lbl">Rows</label>
        <input type="text" class="input shrt" name="olRows" value="1" />
      </div>
	   <div class="span-4">
        <label class="lbl">Start (numeric)</label>
        <input type="text" class="input shrt" name="olStart" />
      </div>
	   <div class="span-4">
        <label class="lbl">Type</label>
        <select class="input w200" name="olType">
			<option value="">1 - arabic numbers (default)
			<option value="a">a - lower alpha
			<option value="A">A - upper alpha
			<option value="i">i - lower roman
			<option value="I">I - upper roman
		</select>
      </div>
    </fieldset>
    <fieldset>
      <div class="span-4 buttonrow">
        <button class="btn" value="OK" onclick="insertOL();">
          <div class="bImg bOK"></div>
          <span>OK</span>
        </button>
        <button class="btn" value="Cancel" onclick="returnValue='';self.close();">
          <div class="bImg bCancel"></div>
          <span>Cancel</span>
        </button>
      </div>
    </fieldset>
</div>
<div id="ulTag" class="span-4 module-form-fluid-none" style="margin:14px;display:none;">
	<fieldset>
      <legend>
        <strong>Insert Unordered List</strong>
      </legend>
	  <div class="span-4">
        <label class="lbl">Rows</label>
        <input type="text" class="input shrt" name="ulRows" value="1" />
      </div>
	   <div class="span-4">
        <label class="lbl">Start (numeric)</label>
        <input type="text" class="input shrt" name="olStart" />
      </div>
	   <div class="span-4">
        <label class="lbl">Type</label>
        <select class="input shrtSelect" name="ulType">
			<option value="disc">disc
			<option value="circle">circle
			<option value="square">square
		</select>
      </div>
    </fieldset>
    <fieldset>
      <div class="span-4 buttonrow">
        <button class="btn" value="OK" onclick="insertUL();">
          <div class="bImg bOK"></div>
          <span>OK</span>
        </button>
        <button class="btn" value="Cancel" onclick="returnValue='';self.close();">
          <div class="bImg bCancel"></div>
          <span>Cancel</span>
        </button>
      </div>
    </fieldset>
</div>
<div id="aTag" class="span-5 module-form-fluid-none" style="margin:14px;display:none;">
	<fieldset>
      <legend>
        <strong>
          Insert Hyperlink
        </strong>
      </legend>
	  <div class="span-5">
        <label class="lbl">Href Attribute</label>
        <input type="text" class="input" name="aHref" value="" />
      </div>
	  <div class="span-5">
        <label class="lbl">Anchor Name</label>
        <input type="text" class="input" name="aName" value="" />
      </div>
	  <div class="span-5">
        <label class="lbl">New Window</label>
        <input type="checkbox" name="aTarget" style="margin-left:0px;" />
      </div>
    </fieldset>
    <fieldset>
      <div class="span-4 buttonrow">
        <button class="btn" value="OK" onclick="insertA();">
          <div class="bImg bOK"></div>
          <span>OK</span>
        </button>
        <button class="btn" value="Cancel" onclick="returnValue='';self.close();">
          <div class="bImg bCancel"></div>
          <span>Cancel</span>
        </button>
      </div>
    </fieldset>
</div>
    </form>
</body>
</html>
