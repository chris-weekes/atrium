<?xml version="1.0"  encoding="iso-8859-1"?>

<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:param name="pgid"/>
  <xsl:param name="highlightNode"/>
  <xsl:output method="html"/>

  <xsl:template match="/">
    <fieldset>
      <div class="span-5 buttonrow">
        <button class="btn" type="button" onclick="location='SAMImageSelector.aspx?treeview=true';">
        <div class="bImg bTreeview"></div>
        <span>Tree View</span>
      </button>
      </div>
    </fieldset>


    <div style="float:left;height:600px;width:380px;overflow:scroll;">
      <xsl:apply-templates select="images"/>
    </div>
    <div id="imgDivContainer" style="float:left;height:600px;width:380px;overflow:scroll;">
      <xsl:call-template name="allImages"/>
    </div>
    <style>

      .li { list-style-type:none;list-style-position : outside;padding:1px;}
      .lileaf{margin-left:16px;margin-bottom:2px;}
      .content a:link{color: blue; font-weight : bold; text-decoration : none;}
      .content a:visited{color: blue; font-weight : bold; text-decoration : none;}
      .content a:hover{color: #cc3333; font-weight : bold; text-decoration : underline;}
      .content a.u:link{color: blue; font-weight : bold; text-decoration : none;}
      .content a.u:visited{color: blue; font-weight : bold; text-decoration : none;}
      .content a.u:hover{color: #cc3333; font-weight : bold; text-decoration : underline;}
      .content a.uu:link{color: blue; font-weight : bold; text-decoration : underline;font-style:italic}
      .content a.uu:visited{color: blue; font-weight : bold; text-decoration : underline;font-style:italic}
      .content a.uu:hover{color: #cc3333; font-weight : bold; text-decoration : none;font-style:italic}
      .img{margin-top:2px;margin-right:4px;position:relative;top:3px;}
      a.CXLink{color:blue;font-size:0.8em;position:relative;top:-2px;text-decoration:none;}
      a.CXLink img{margin-left:3px;position:relative;top:1px;}
      a.mnItm:link{color:blue;text-decoration:none;}
      a.mnItm:hover{color:blue;text-decoration:underline;}
      a.mnItm:visited{color:blue;text-decoration:none;}

    </style>

  </xsl:template>
  <!-- ERROR Template, this node does not match -->
  <xsl:template match="nextid">
    <!-- do nothing -->
  </xsl:template>
  <xsl:template name="allImages">
    <xsl:for-each select="//image">
      <img id="divImg{@id}" src="../common/images/{@src}" style="margin-left:10px;display:none;"/>
    </xsl:for-each>
  </xsl:template>
  <xsl:template match="images">
    <xsl:apply-templates select="container"/>
    <xsl:apply-templates select="image"/>
  </xsl:template>

  <xsl:template name="liSubItem">
    <li class="li" iscontainer="true">
      <xsl:if test="@id!='1'">
        <xsl:attribute name="name">collection</xsl:attribute>
        <a class="CXLink" id="ExpCol{@id}" vid="xc" href="javascript:CollapseSection({@id}, true);">
          <IMG class="img" WIDTH="16" src="images/minus.gif" />
        </a>
      </xsl:if>
      <IMG class="img" WIDTH="16" src="images/folder.png" />

      <a class="mnItm" id="scrollTo{@id}" ContainerId="{@id}">
        <xsl:attribute name="HREF">
          javascript:
        </xsl:attribute>
        <xsl:value-of select="@name" />
      </a>
      <ul ulid="{@id}" style="padding: 0;margin-left:22px;">
        <xsl:if test="(@id!='1')">
          <xsl:attribute name="top">Y</xsl:attribute>
        </xsl:if>
        <xsl:apply-templates select="container"/>
        <xsl:apply-templates select="image"/>
      </ul>
    </li>

  </xsl:template>
  <xsl:template match="container">
    <xsl:call-template name="liSubItem"/>
  </xsl:template>

  <xsl:template match="image">
    <LI class="li lileaf" isimage="true">
      <IMG class="img" WIDTH="16">
        <xsl:attribute name="SRC">images/image.png</xsl:attribute>
      </IMG>
      <A class="mnItm" id="scrollTo{@id}" ImageId="{@id}" onmouseover="showImage('divImg{@id}');">
        <xsl:attribute name="HREF">
          javascript:returnImgTag("<xsl:value-of select="@src"/>");
        </xsl:attribute>
        <xsl:value-of select="@name" />
      </A>
    </LI>
    <xsl:apply-templates select="container"/>
    <xsl:apply-templates select="image"/>
  </xsl:template>


</xsl:stylesheet>