<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:param name="server"/>
<xsl:param name="lang"/>
<xsl:output method="html"/>
<xsl:template match="/">
	<xsl:apply-templates select="*"/>
</xsl:template>
<xsl:template match="*">
  <div class="span-6 border-span-6 module-table-contents">
    <xsl:if test="$lang='eng'">
      <p>Table of contents</p>  
    </xsl:if>
    <xsl:if test="$lang='fre'">
      <p>Table des matières</p>
    </xsl:if>
    
    <ul>
    <xsl:for-each select="item">
      <li>
        <a>
          <xsl:attribute name="href">
            <xsl:value-of select="$server"/>?pgid=<xsl:value-of select="@pgid"/>
          </xsl:attribute>
          <xsl:if test="$lang='eng'">
            <xsl:value-of select="@eng"/>
          </xsl:if>
          <xsl:if test="$lang='fre'">
            <xsl:value-of select="@fre"/>
          </xsl:if>
        </a>
      </li>
    </xsl:for-each>
    </ul>
  </div>

</xsl:template>
</xsl:stylesheet>