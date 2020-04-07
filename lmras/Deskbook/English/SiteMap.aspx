<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SiteMap.aspx.cs" Inherits="lmras.Deskbook.English._SiteMap" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
    <title>Atrium Deskbooks</title>
    <!-- TemplateEndEditable -->
    <!-- Title ends / Fin du titre -->

    <!-- Favicon (optional) begins / Début du favicon (optionnel) -->
    <asp:Literal ID="favIcon" runat="server"></asp:Literal>
    <!-- Favicon (optional) ends / Find du favicon (optionnel) -->
    <!-- Metadata begins / Début des métadonnées -->
    <!-- TemplateBeginEditable name="English metadata | Metadonnées anglaises" -->
    <asp:Literal ID="fdcTitle" runat="server"></asp:Literal>
    <asp:Literal ID="fdcDescription" runat="server"></asp:Literal>
    <meta name="description" content="" />
    <asp:Literal ID="fdcSubject" runat="server"></asp:Literal>
    <asp:Literal ID="fkeywords" runat="server"></asp:Literal>
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
    <link href="../wet20/css/base.css" rel="stylesheet" type="text/css" />
    <!--[if IE 8]><link href="../wet20/css/base-ie8.css" rel="stylesheet" type="text/css" /><![endif]-->
    <!--[if IE 7]><link href="../wet20/css/base-ie7.css" rel="stylesheet" type="text/css" /><![endif]-->
    <!--[if lte IE 6]><link href="../wet20/css/base-ie6.css" rel="stylesheet" type="text/css" /><![endif]-->

    <!-- clf2-nsi2 theme begins / Début du thème clf2-nsi2 -->
    <link href="../wet20/theme-clf2-nsi2/css/theme-clf2-nsi2.css" rel="stylesheet" type="text/css" />
    <!--[if IE 7]><link href="../wet20/theme-clf2-nsi2/css/theme-clf2-nsi2-ie7.css" rel="stylesheet" type="text/css" /><![endif]-->
    <!--[if lte IE 6]><link href="../ wet20/theme-clf2-nsi2/css/theme-clf2-nsi2-ie6.css" rel="stylesheet" type="text/css" /><![endif]-->

    <!-- clf2-nsi2 theme ends / Fin du thème clf2-nsi2 -->
    <!-- CSS Grid System begins / Début du système de grille de CSS -->
    <asp:Literal runat="server" ID="css1"></asp:Literal>
    <link rel="stylesheet" href="../wet20/grids/css/grid.css" media="screen" type="text/css" />
    <link rel="stylesheet" href="../wet20/grids/css/grid-module.css" media="screen" type="text/css" />

    <!-- CSS Grid System ends / Fin du système de grille de CSS -->
    <!-- WET scripts/CSS end / Fin des scripts/CSS de la BOEW -->

    <!-- Progressive enhancement begins / Début de l'amélioration progressive -->
    <script src="../wet20/js/lib/jquery.min.js" type="text/javascript"></script>
    <script src="../wet20/js/pe-ap.js" type="text/javascript" id="progressive"></script>
 
    <script type="text/javascript" src="../../DeskbookSAM/english/atrium/common/js/script2.js"></script>
    
    <script type="text/javascript">
        /* <![CDATA[ */
        var params = {
            styleswitcher: { cookie: 'defaultCookie' },
            expandhide: { titleSelector: ".toggle-link-text", globalToggles: false, rule: 'enforce-nav-open' },
            resolution: "elastic",
            navCurrent: { id: "navCurrent" },
            zebra: { selector: ".zebra" },
            toolbar: { homeLinkSelector: "#cn-banner-text > a", searchLinkSelector: "#cn-cmb5 > a", methodName: "get", searchFieldName: "query" }
        };
        /* ]]> */
    </script>

    <!-- TemplateBeginEditable name="Progressive enhancement | Amélioration progressive" -->
    <script type="text/javascript">
        /* <![CDATA[ */

        /* ]]> */
    </script>
    <!-- TemplateEndEditable -->

    <script type="text/javascript">
        /* <![CDATA[ */
        PE.progress(params);
        /* ]]> */
    </script>
    <!-- Progressive enhancement ends / Fin de l'amélioration progressive -->
    <!-- Custom scripts/CSS begin / Début des scripts/CSS personnalisés -->
    <link href="../wet20/intranet/css/default.css" rel="stylesheet" media="screen" type="text/css" />
    <link href="../wet20/intranet/css/pf-if.css" rel="stylesheet" media="print" type="text/css" />
    <link href="../common/css/lsu_styles.css" rel="stylesheet" media="screen" type="text/css" />

    <!-- TemplateBeginEditable name="Scripts/CSS" -->
    <script src="../wet20/js/plugins/font-replacement.js" type="text/javascript"></script>
    <!-- TemplateEndEditable -->
    <!-- Custom scripts/CSS end / Fin des scripts/CSS personnalisés -->

    <!-- WET print CSS begins / Début du CSS de la BOEW pour l'impression -->
    <link href="../wet20/css/pf-if.css" rel="stylesheet" media="print" type="text/css" />
    <!-- clf2-nsi2 theme begins / Début du thème clf2-nsi2 -->
    <link href="../wet20/theme-clf2-nsi2/css/pf-if-theme-clf2-nsi2.css" rel="stylesheet" media="print" type="text/css" />

    <!-- clf2-nsi2 theme ends / Fin du thème clf2-nsi2 -->
    <!-- WET print CSS ends / Fin du CSS de la BOEW pour l'impression -->
    <asp:Literal ID="lclCSS" runat="server"></asp:Literal>

</head>

<body>
    <!-- Two column layout begins / Début de la mise en page de deux colonnes -->
    <div id="cn-body-inner-2col">
        <!-- Skip header begins / Début du saut de l'en-tête -->
        <div id="cn-skip-head">
            <nav>
		<ul id="cn-tphp">
			<li id="cn-sh-link-1"><a href="#cn-cont">Skip to main content</a></li>
			<li id="cn-sh-link-2"><a href="#cn-nav">Skip to primary navigation</a></li>
		</ul>
	</nav>
        </div>
        <!-- Skip header ends / Fin du saut de l'en-tête -->

        <!-- Header begins / Début de l'en-tête -->
        <div id="cn-head">
            <div id="cn-head-inner">
                <header>
        <!-- clf2-nsi2 theme begins / Début du thème clf2-nsi2 -->
        <div id="cn-wmms"><img src="../wet20/theme-clf2-nsi2/images/wmms.gif" width="83" height="20" alt="Symbol of the Government of Canada" title="Symbol of the Government of Canada" /></div>

		<!-- Banner begins / Début de la bannière -->
		<div id="cn-leaf"></div>
		<div id="cn-banner" role="banner">
			<p id="cn-banner-text"><a href="../english/">Atrium Deskbooks</a></p>
			<p><a href="#">Collections Litigation & Advisory Services</a></p>
		</div>
		<!-- Banner ends / Fin de la bannière -->

		<nav role="navigation">
			<!-- Common menu bar begins / Début de la barre de menu commune -->
			<div id="cn-cmb">
				<h2>Deskbook menu bar</h2>
				<ul>
					<li id="cn-cmb1"><a href="/lmras/deskbook/english/">Home</a>
					<!-- TemplateBeginEditable name="French Link | Lien français"
					<asp:Literal ID="fLang" runat="server"></asp:Literal> -->
					<!-- TemplateEndEditable -->
					</li>
					<li id="cn-cmb2"><a href="SiteMap.aspx">Site Map</a></li>
					<li id="cn-cmb3"><a href="#"></a></li>
					<li id="cn-cmb4"><a href="#"></a></li>
					<li id="cn-cmb5"><a href="#"></a></li>
					<li id="cn-cmb6"><a href="#"></a></li>
				</ul>
			</div>
            
			<!-- Common menu bar ends / Fin de la barre de menu commune -->
            
			<!-- Breadcrumb begins / Début du fil d'Ariane -->
			<div id="cn-bcrumb">
				<h2>Breadcrumb</h2>
                <!-- TemplateBeginEditable name="English bread crumb | Piste de navigation anglaise" -->
                <asp:Literal ID="pgBcXml" runat="server"></asp:Literal>
				<!-- TemplateEndEditable -->
			</div>
			<!-- Breadcrumb ends / Fin du fil d'Ariane -->
		</nav>
<!-- clf2-nsi2 theme ends / Fin du thème clf2-nsi2 -->
	</header>
            </div>
        </div>
        <!-- Header ends / Fin de l'en-tête -->


        <div id="cn-cols">
            <!-- Main content begins / Début du contenu principal -->
            <div id="cn-centre-col-gap"></div>
            <div id="cn-centre-col" role="main">
                <div id="cn-centre-col-inner">
                    <section>
          <!-- CSS Grid System begins / Début du système de grille de CSS -->
          <!-- Content title begins / Début du titre du contenu -->
          <header>
            <h1 id="cn-cont">
			<!-- TemplateBeginEditable name="English content title | Titre contenu anglais" -->
            <asp:Literal ID="h1PgTitle" runat="server"></asp:Literal>
			<!-- TemplateEndEditable -->
			</h1>
          </header>
          <!-- Content Title ends / Fin du titre du contenu -->
          <!-- clf2-nsi2 theme begins / Début du thème clf2-nsi2 -->
	      <!-- TemplateBeginEditable name="English content | Contenu anglais" -->
    	  <div class="span">
          <asp:Literal ID="pgContent" runat="server"></asp:Literal>
          </div>
    <!-- TemplateEndEditable -->
<!-- clf2-nsi2 theme ends / Fin du thème clf2-nsi2 -->
<!-- CSS Grid System ends / Fin du système de grille de CSS -->
    </section>
                </div>
            </div>
            <!-- Main content ends / Fin du contenu principal -->

            <!-- Primary navigation (left column begins) / Début de la navigation principale (colonne gauche) -->
            <div id="cn-left-col-gap"></div>
            <div id="cn-left-col">
                <div id="cn-left-col-inner">
                    <section>
		<h2 id="cn-nav">Primary navigation (left column)</h2>
		<div class="cn-left-col-default">
		<nav role="navigation">
<!-- clf2-nsi2 theme begins / Début du thème clf2-nsi2 -->
			<section>
				<!--<img src="common/images/lsb-graphic.jpg" alt="Legal Services Branch Graphic" />-->
				<!-- TemplateBeginEditable name="Side menu | Menu latéral" -->
                <asp:Literal ID="pgMenuXml" runat="server"></asp:Literal>
                <!-- TemplateEndEditable -->
			</section>
<!-- clf2-nsi2 theme ends / Fin du thème clf2-nsi2 -->
<!-- UI personalisation begins / Début de la personnalisation de la IU -->
			<!--<section>
				<div class="utilities">
					<ul>
						<li><a href="?pgid=37" class="utility-search">Search</a></li>
						<li><a href="?pgid=36" class="utility-feedback">Feedback</a></li>
						<li><a href="?pgid=93" class="utility-sitemap">Site map</a></li>
					</ul>
				</div>
			</section>-->
<!-- UI personalisation ends / Fin de la personnalisation de la IU -->
		</nav>
		</div>
	</section>
                </div>
            </div>
            <!-- Primary navigation (left column) ends / Fin de la navigation principale (colonne gauche) -->
        </div>

        <!-- Footer begins / Début du pied de page -->
        <div id="cn-foot">
            <div id="cn-foot-inner">
                <footer>
		<h2>Footer</h2>
<!-- clf2-nsi2 theme begins / Début du thème clf2-nsi2 -->
		<div id="cn-in-pd">			
			<dl id="cn-doc-dates" role="contentinfo">
				<dt><asp:Literal ID="lbLastMod" runat="server"></asp:Literal></dt>
				<dd><span id="LastModDate">
				 <asp:Literal ID="txtFileDate" runat="server"></asp:Literal>
				</span></dd>
			</dl>
			<div id="cn-toppage-foot"><a href="#cn-tphp">Top of Page</a></div>
			<div id="cn-in-pd-links">
				<!--<ul>
					<li id="cn-inotices-link"><a href="http://infozone/english/gbl/util/ntcs-eng.html" rel="license">Important Notices</a></li>
				</ul>-->
			</div>
		</div>
<!-- clf2-nsi2 theme ends / Fin du thème clf2-nsi2 -->
	</footer>
            </div>
        </div>
        <!-- Footer ends / Fin du pied de page -->
    </div>
    <!-- Two column layout ends / Fin de la mis en page de deux colonnes -->
</body>

</html>

