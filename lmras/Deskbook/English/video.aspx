<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="video.aspx.cs" Inherits="lmras.Deskbook.English.video" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
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
	<title><%HttpContext.GetGlobalResourceObject("LocalizedText", "AtriumVideos").ToString();%></title>
    <!-- TemplateEndEditable -->
	<!-- Title ends / Fin du titre -->
	
	<!-- Favicon (optional) begins / Début du favicon (optionnel) -->
	<link rel="shortcut icon" href="~/Workflow/images/atriumtrans48x48.ico" />
	<!-- Favicon (optional) ends / Find du favicon (optionnel) -->
	
	<!-- Metadata begins / Début des métadonnées -->
	<!-- TemplateBeginEditable name="English metadata | Metadonnées anglaises" -->
	<meta name="dc.title" content="" /> 
	<meta name="dc.description" content="" />
	<meta name="description" content="" /> 
	<meta name="dc.subject" title="Atrium Training Videos" content="" /> 
	<meta name="keywords" content="" />
	<meta name="dc.creator" content="Governement du Canada, Information sur les compétences" />
	<meta name="owner" content="" /> 
	<meta name="dc.publisher" content="" /> 
	<meta name="dc.language" title="ISO639-2" content="eng" />
	<meta name="dcterms.issued" title="W3CDTF" content="" /> 
	<meta name="dcterms.modified" title="W3CDTF" content="" /> 
	<meta name="dcterms.audience" title="AtriumAudience" content="" /> 
	<meta name="dc.type" title="gctype" content="" /> 
	<meta name="dcterms.spatial" title="Atriumgeonames" content="" /> 
	<meta name="robots" content="index,follow" /> 
	<meta name="dc.identifier" content="" />
	<meta name="metaQA" content="" />
	<!-- TemplateEndEditable -->
	<!-- Metadata ends / Fin des métadonnées -->

    <!-- WET scripts/CSS begin / Début des scripts/CSS de la BOEW --><!--[if IE 6]><![endif]-->
	<link href="../wet20/css/base.css" rel="stylesheet" type="text/css" />
	 
    <!-- clf2-nsi2 theme begins / Début du thème clf2-nsi2 -->
	<link href="../wet20/theme-clf2-nsi2/css/theme-clf2-nsi2.css" rel="stylesheet" type="text/css" />
  
    <!-- clf2-nsi2 theme ends / Fin du thème clf2-nsi2 -->
    <!-- CSS Grid System begins / Début du système de grille de CSS -->
    
	<link rel="stylesheet" href="../wet20/grids/css/grid-small.css" media="screen" type="text/css" id="grid_framework" />
	<link rel="stylesheet" href="../wet20/grids/css/grid.css" media="screen" type="text/css" />
	<link rel="stylesheet" href="../wet20/grids/css/grid-module.css" media="screen" type="text/css" />
    <link rel="stylesheet" href="../../Workflow/css/wfstyles.css" media="screen" type="text/css" />
    
    <!-- CSS Grid System ends / Fin du système de grille de CSS -->
	<!-- WET scripts/CSS end / Fin des scripts/CSS de la BOEW -->

    
	<!-- Progressive enhancement begins / Début de l'amélioration progressive -->
	<script src="../wet20/js/lib/jquery.min.js" type="text/javascript"></script>
	
    <script src="../common/js/script.js" type="text/javascript"></script>
    <!--<script src="script/wfscript.js" type="text/javascript"></script>-->
      
	<!-- Custom scripts/CSS begin / Début des scripts/CSS personnalisés -->
	<link href="../wet20/intranet/css/default.css" rel="stylesheet" media="screen" type="text/css" />
	<link href="../wet20/intranet/css/pf-if.css" rel="stylesheet" media="print" type="text/css" />
	<!--<link href="../common/css/lsu_styles.css" rel="stylesheet" media="screen" type="text/css" />-->
	<!-- TemplateBeginEditable name="Scripts/CSS" -->
	<script src="../wet20/js/plugins/font-replacement.js" type="text/javascript"></script>
	<!-- TemplateEndEditable -->
	<!-- Custom scripts/CSS end / Fin des scripts/CSS personnalisés -->

	<!-- WET print CSS begins / Début du CSS de la BOEW pour l'impression -->
	<link href="../wet20/css/pf-if.css" rel="stylesheet" media="print" type="text/css" />
    <!-- clf2-nsi2 theme begins / Début du thème clf2-nsi2 -->
	<link href="../wet20/theme-clf2-nsi2/css/pf-if-theme-clf2-nsi2.css" rel="stylesheet" media="print" type="text/css" />
    <!-- clf2-nsi2 theme ends / Fin du thème clf2-nsi2 -->

    <!-- admin styles begins-->
    <!--<link href="../common/css/adminstyles.css" rel="stylesheet" media="screen" type="text/css" />-->
    <!-- admin styles end-->

	<!-- WET print CSS ends / Fin du CSS de la BOEW pour l'impression -->
</head>
<body id="b1">
    <form id="form1" runat="server">
    <div id="awdc">
        <img alt="" src="../../workflow/images/documentation.jpg" align="middle"/><asp:Label ID="Label1" Runat="server" Text="<%$ Resources:LocalizedText, AtriumVideos %>"></asp:Label><br />
        
    </div>
    <div style="float:right">
    
        <img alt="" src="../../workflow/images/atriumcra-arc.png"/>
       

    </div>
    <div class="clear"></div><br />
   
        <h1>CLASMate vs. Atrium</h1>
        <h2>Comparison Video Series</h2>
        <div style="float:left";>
        <%string mediaRoot = System.Configuration.ConfigurationManager.AppSettings["atMediaRoot"].ToString(); %>
        <a title="View in external viewer" href="<%Response.Write(mediaRoot); %>/01 Windows Apps vs Web Apps.wmv"><img alt="" src="../../workflow/images/video.png" />01 - Windows Apps vs Web Apps.wmv</a> <a title="View embedded" href="video.aspx?id=01 Windows Apps vs Web Apps.wmv#cvs"><img alt="" src="../../workflow/images/embed.png" /></a><br />
        <a title="View in external viewer" href="<%Response.Write(mediaRoot); %>/02 One Screen vs Multiple Screens.wmv"><img alt="" src="../../workflow/images/video.png" />02 - One Screen vs Multiple Screens.wmv</a> <a title="View embedded" href="video.aspx?id=02 One Screen vs Multiple Screens.wmv#cvs"><img alt="" src="../../workflow/images/embed.png" /></a><br />
        <a title="View in external viewer" href="<%Response.Write(mediaRoot); %>/03 Main Screen.wmv"><img alt="" src="../../workflow/images/video.png" />03 - Main Screen.wmv</a> <a title="View embedded" href="video.aspx?id=03 Main Screen.wmv#cvs"><img alt="" src="../../workflow/images/embed.png" /></a><br />
        <a title="View in external viewer" href="<%Response.Write(mediaRoot); %>/04 What's New.wmv"><img alt="" src="../../workflow/images/video.png" />04 - What's New.wmv</a> <a title="View embedded" href="video.aspx?id=04 What's New.wmv#cvs"><img alt="" src="../../workflow/images/embed.png" /></a><br />
        <a title="View in external viewer" href="<%Response.Write(mediaRoot); %>/05 Files and File-based Screens.wmv"><img alt="" src="../../workflow/images/video.png" />05 - Files and File-based Screens.wmv</a> <a title="View embedded" href="video.aspx?id=05 Files and File-based Screens.wmv#cvs"><img alt="" src="../../workflow/images/embed.png" /></a><br />
        <a title="View in external viewer" href="<%Response.Write(mediaRoot); %>/06 Multiple Files.wmv"><img alt="" src="../../workflow/images/video.png" />06 - Multiple Files.wmv</a> <a title="View embedded" href="video.aspx?id=06 Multiple Files.wmv#cvs"><img alt="" src="../../workflow/images/embed.png" /></a><br />
        <a title="View in external viewer" href="<%Response.Write(mediaRoot); %>/07 Seeing File Content While in Activity.wmv"><img alt="" src="../../workflow/images/video.png" />07 - Seeing File Content While in Activity.wmv</a> <a title="View embedded" href="video.aspx?id=07 Seeing File Content While in Activity.wmv#cvs"><img alt="" src="../../workflow/images/embed.png" /></a><br />
        <a title="View in external viewer" href="<%Response.Write(mediaRoot); %>/08 Explicit Workflow.wmv"><img alt="" src="../../workflow/images/video.png" />08 - Explicit Workflow.wmv</a> <a title="View embedded" href="video.aspx?id=08 Explicit Workflow.wmv#cvs"><img alt="" src="../../workflow/images/embed.png" /></a><br />
        <a title="View in external viewer" href="<%Response.Write(mediaRoot); %>/09 Displaying Available Activities.wmv"><img alt="" src="../../workflow/images/video.png" />09 - Displaying Available Activities.wmv</a> <a title="View embedded" href="video.aspx?id=09 Displaying Available Activities.wmv#cvs"><img alt="" src="../../workflow/images/embed.png" /></a><br />
        <a title="View in external viewer" href="<%Response.Write(mediaRoot); %>/10 New Activity Wizard.wmv"><img alt="" src="../../workflow/images/video.png" />10 - New Activity Wizard.wmv</a> <a title="View embedded" href="video.aspx?id=10 New Activity Wizard.wmv#cvs"><img alt="" src="../../workflow/images/embed.png" /></a><br />
        <a title="View in external viewer" href="<%Response.Write(mediaRoot); %>/11 Document Generating and Storage.wmv"><img alt="" src="../../workflow/images/video.png" />11 - Document Generating and Storage.wmv</a> <a title="View embedded" href="video.aspx?id=11 Document Generating and Storage.wmv#cvs"><img alt="" src="../../workflow/images/embed.png" /></a><br />
        <a title="View in external viewer" href="<%Response.Write(mediaRoot); %>/12 Document Importing.wmv"><img alt="" src="../../workflow/images/video.png" />12 - Document Importing.wmv</a> <a title="View embedded" href="video.aspx?id=12 Document Importing.wmv#cvs"><img alt="" src="../../workflow/images/embed.png" /></a><br />
        <a title="View in external viewer" href="<%Response.Write(mediaRoot); %>/13 Document Serching.wmv"><img alt="" src="../../workflow/images/video.png" />13 - Document Searching.wmv</a> <a title="View embedded" href="video.aspx?id=13 Document Serching.wmv#cvs"><img alt="" src="../../workflow/images/embed.png" /></a><br />
        <a title="View in external viewer" href="<%Response.Write(mediaRoot); %>/14 Sending CLASMail vs. AtriumMail.wmv"><img alt="" src="../../workflow/images/video.png" />14 - Sending CLASMail vs. AtriumMail.wmv</a> <a title="View embedded" href="video.aspx?id=14 Sending CLASMail vs. AtriumMail.wmv#cvs"><img alt="" src="../../workflow/images/embed.png" /></a><br />
        <a title="View in external viewer" href="<%Response.Write(mediaRoot); %>/15 Interface with Outlook-Importing E-mails to file.wmv"><img alt="" src="../../workflow/images/video.png" />15 - Interface with Outlook-Importing E-mails to file.wmv</a> <a title="View embedded" href="video.aspx?id=15 Interface with Outlook-Importing E-mails to file.wmv#cvs"><img alt="" src="../../workflow/images/embed.png" /></a><br />
        <a title="View in external viewer" href="<%Response.Write(mediaRoot); %>/16 Receiving CLASMail vs. AtriumMail - All Workload in One Place.wmv"><img alt="" src="../../workflow/images/video.png" />16 - Receiving CLASMail vs. AtriumMail - All Workload in One Place.wmv</a> <a title="View embedded" href="video.aspx?id=16 Receiving CLASMail vs. AtriumMail - All Workload in One Place.wmv#cvs"><img alt="" src="../../workflow/images/embed.png" /></a><br />
        <a title="View in external viewer" href="<%Response.Write(mediaRoot); %>/17 Grids.wmv"><img alt="" src="../../workflow/images/video.png" />17 - Grids.wmv</a> <a title="View embedded" href="video.aspx?id=17 Grids.wmv#cvs"><img alt="" src="../../workflow/images/embed.png" /></a><br />
        <a title="View in external viewer" href="<%Response.Write(mediaRoot); %>/18 BF List.wmv"><img alt="" src="../../workflow/images/video.png" />18 - BF List.wmv</a> <a title="View embedded" href="video.aspx?id=18 BF List.wmv#cvs"><img alt="" src="../../workflow/images/embed.png" /></a><br />
        <a title="View in external viewer" href="<%Response.Write(mediaRoot); %>/19 Double-clicking.wmv"><img alt="" src="../../workflow/images/video.png" />19 - Double-clicking.wmv</a> <a title="View embedded" href="video.aspx?id=19 Double-clicking.wmv#cvs"><img alt="" src="../../workflow/images/embed.png" /></a><br />
        <a title="View in external viewer" href="<%Response.Write(mediaRoot); %>/20 Recently Viewed Files.wmv"><img alt="" src="../../workflow/images/video.png" />20 - Recently Viewed Files.wmv</a><a title="View embedded" href="video.aspx?id=20 Recently Viewed Files.wmv#cvs"><img alt="" src="../../workflow/images/embed.png" /></a><br />

        </div>
        <%if (Request.QueryString["id"] != null)
                { %>
        <a name="cvs"></a>
        <div style="float:left;margin-left:40px;padding:6px 30px 6px 30px;background-color:#eaeaea;border:1px solid #cacaca;">
        
        
          <h4>Viewing: <%Response.Write(Request.QueryString["id"]); %></h4>
            <OBJECT id='mediaPlayer1' width="700" height="500" classid='CLSID:22d6f312-b0f6-11d0-94ab-0080c74c7e95' codebase='http://activex.microsoft.com/activex/controls/mplayer/en/nsmp2inf.cab#Version=5,1,52,701' standby='Loading Microsoft Windows Media Player components...' type='application/x-oleobject'>
            <param name='fileName' value="<%Response.Write(mediaRoot + "/" + Request.QueryString["id"]); %>">
            <param name='animationatStart' value='true'>
            <param name='transparentatStart' value='true'>
            <param name='autoStart' value="true">
            <param name='showControls' value="true">
            <param name ="ShowAudioControls"value="true">
            <param name="ShowStatusBar" value="true">
            <param name='loop' value="false">
            <param name='Volume' value="100">
            <EMBED type='application/x-mplayer2' pluginspage='http://microsoft.com/windows/mediaplayer/en/download/' id='mediaPlayer' name='mediaPlayer' displaysize='4' autosize='-1' bgcolor='darkblue' showcontrols="true" showtracker='-1' showdisplay='0' showstatusbar='-1' videoborder3d='-1' width="700" height="500" src="<%Response.Write(mediaRoot + "/" + Request.QueryString["id"]); %>" autostart="true" designtimesp='5311' loop="false">
            </EMBED>
            </OBJECT>
            <br />
            <div style="text-align:center;padding-top:12px;">
            <a href="<%Response.Write(mediaRoot + "/" + Request.QueryString["id"]); %>">Click here for standalone player</a>
            </div>









            <!--<object width="700" height="500" classid="CLSID:22D6F312-B0F6-11D0-94AB-0080C74C7E95" standby="Loading Microsoft® Windows® Media Player components..." type="application/x-oleobject" codebase="http://activex.microsoft.com/activex/controls/mplayer/en/nsm p2inf.cab#Version=6,4,7,1112"> 
            <param name="fileName" value="<%Response.Write(mediaRoot + "/" + Request.QueryString["id"]); %>"> 
            <param name="AutoStart" value="true">
            <param name="ShowControls" value="true">
            <param name="BufferingTime" value="2">
            <param name="ShowStatusBar" value="true">
            <param name="AutoSize" value="true">
            <param name="InvokeURLs" value="false">
            <param name="AnimationatStart" value="1">
            <param name="TransparentatStart" value="1">
            <PARAM NAME="EnableFullScreenControls" VALUE="True"> 
            <param name="Loop" value="0">
            <param name="Volume" value="100">
            <embed type="application/x-mplayer2" volume="100" pluginspage="http://www.microsoft.com/Windows/MediaPlayer/" src="<%Response.Write(mediaRoot + "/" + Request.QueryString["id"]); %>" autoStart="true" ></embed>
            </object>-->
        
        </div>
        <%} %>
        <div class="clear"></div><br /><br /><br />
        <div class="aTp"><a href="#"><img alt="" src="../../workflow/images/arrow-up.png" /><asp:Label ID="Label6" Runat="server" Text="<%$ Resources:LocalizedText, backToTop %>"></asp:Label></a></div>
    </form>
</body>
</html>
