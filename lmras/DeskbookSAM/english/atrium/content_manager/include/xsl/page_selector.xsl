<?xml version="1.0"  encoding="iso-8859-1"?>

<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="html"/>

<xsl:template match="/">

  <h3 class="head3">Menu Structure</h3>
  <xsl:apply-templates select="item[@orphan='false']"/>

  <h3 class="head3">Orphan Pages</h3>
  <xsl:apply-templates select="//item[@orphan='true']"/>
  
<style>
  .head3{width:90%}
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
  .img{margin-top:2px;margin-right:8px;position:relative;top:2px;}

  a.contextHighlight{background-color:#ffffc0;}
  a.CXLink{color:blue;font-size:0.8em;position:relative;top:-2px;text-decoration:none;}
  a.CXLink img{margin-left:3px;position:relative;top:1px;}

</style>
</xsl:template>
<!-- ERROR Template, this node does not match -->
<xsl:template match="nextid">
	<!-- do nothing -->
</xsl:template>

  <xsl:template name="liSubItem">
    <li class="li">
      <xsl:if test="@id!='1'">
        <xsl:attribute name="name">collection</xsl:attribute>
      <a class="CXLink" id="ExpCol{@id}" vid="xc" href="javascript:CollapseSection({@id}, true);">
        <IMG class="img" WIDTH="16" src="images/minus.gif" />
      </a>
      </xsl:if>
      <xsl:if test="@nodeType='node'">
        <IMG class="img" WIDTH="16" src="images/section.png" />
      </xsl:if>
      <xsl:if test="@nodeType='nodeleaf'">
        <IMG class="img" WIDTH="16" src="images/leafSection.png" />
      </xsl:if>
      <xsl:if test="@nodeType='leaf'">
        <IMG class="img" WIDTH="16" src="images/leaf.png" />
      </xsl:if>

      <a class="mnItm" id="scrollTo{@id}" ItemId="{@id}" levelCount="{count(ancestor::item)}">
        <xsl:attribute name="HREF">
          javascript:returnPgId('<xsl:value-of select="@id"/>','<xsl:value-of select="@eng" />');
        </xsl:attribute>
        <xsl:value-of select="@eng" />
      </a>
      <ul ulid="{@id}" data-ulid="{@id}" style="padding: 0;">
        <xsl:if test="(../item) and (@id!='1')">
          <xsl:attribute name="top">Y</xsl:attribute>
        </xsl:if>
        <xsl:apply-templates select="item[@orphan='false']"/>
      </ul>
    </li>
    
  </xsl:template>
  <xsl:template match="item[@orphan='false']">
      <xsl:call-template name="liSubItem"/>
  </xsl:template>

  <xsl:template match="item[@orphan='true']">
        <LI class="li lileaf">
          <IMG class="img" WIDTH="16">
            <xsl:attribute name="SRC">images/leaf.png</xsl:attribute>
          </IMG>
          <A class="mnItm" id="scrollTo{@id}" ItemId="{@id}" nodeType="leaf">
            <xsl:attribute name="HREF">
              javascript:returnPgId('<xsl:value-of select="@id"/>','<xsl:value-of select="@eng" />');
            </xsl:attribute>
            <xsl:value-of select="@eng" />
          </A>
        </LI>
  </xsl:template>


</xsl:stylesheet>