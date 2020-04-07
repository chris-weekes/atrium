<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:param name="lang"/>
  <xsl:param name="server"/>
  <xsl:output method="html"/>

<xsl:template match="/">
  <style>
    .li { list-style-type:none;list-style-position : outside;padding:1px;
  </style>
  <div class="span-6">
    <ul>
      <xsl:apply-templates select="item[@orphan='false']"/>
    </ul>
  </div>
</xsl:template>


<xsl:template match="item[@orphan='false']">
	
    
    <li class="li">
    <a>
      <xsl:attribute name="href">
        <xsl:value-of select="$server"/>?pgid=<xsl:value-of select="@pgid"/>
      </xsl:attribute>
      <xsl:if test="$lang='eng'">
        <xsl:value-of select="@eng" disable-output-escaping="yes"/>
      </xsl:if>
      <xsl:if test="$lang='fre'">
        <xsl:value-of select="@fre" disable-output-escaping="yes"/>
      </xsl:if>
    </a>
      </li>
  <ul>
    <xsl:apply-templates select="item[@orphan='false']"/>
  </ul>
</xsl:template>
</xsl:stylesheet>