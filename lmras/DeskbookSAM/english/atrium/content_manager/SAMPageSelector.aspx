<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SAMPageSelector.aspx.cs" Inherits="SSTDeskBooks.english.atrium.content_manager.SAMPageSelector" %>

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
	<title>Page Selector</title>
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
	<script src="../../../wet20/js/pe-ap.js" type="text/javascript" id="progressive"></script>
    <script src="../common/js/script.js" type="text/javascript"></script>
	<script type="text/javascript">


	    function returnPgId(pgid,title) {
	        returnValue = "<a href=\"?pgid=" + pgid + "\">" + title;
	        self.close();
	    }
	    function leavingDialog() {
	        if (returnValue == undefined) {
	            returnValue = "cancel";
	        }
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

<body onunload="leavingDialog();" onkeydown="checkForEscape();" style="width:780px;">
    <form id="form1" runat="server">
    <div>
     <asp:Literal ID="pgContent" runat="server"></asp:Literal>
    </div>
    </form>
</body>
</html>
