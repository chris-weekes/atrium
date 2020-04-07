<?xml version="1.0" encoding="iso-8859-1"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:param name="lang"/>
<xsl:param name="server"/>
<xsl:output method="html"/>
<xsl:template match="/">
	<xsl:apply-templates select="menu"/>
</xsl:template>
<xsl:template match="menu">
  <ul>
    <xsl:apply-templates select="item[@parent='true']"/>
  </ul>
</xsl:template>

  <xsl:template match="item[@parent='true']">
    <li>
      <a>
        <xsl:attribute name="href">
            <xsl:value-of select="$server"/>?pgid=<xsl:value-of select="@pgid"/>
        </xsl:attribute>
        <xsl:attribute name="class">
          nav-parent
        </xsl:attribute>
        <xsl:call-template name="loadLabel"/>
      </a>
    </li>
    <xsl:if test="item[@parent='true']">
      <xsl:apply-templates select="item[@parent='true']"/>  
    </xsl:if>
    <xsl:if test="item[not(@parent='true')]">
      <xsl:apply-templates select="item[not(@parent='true')]"/>
    </xsl:if>
  </xsl:template>
  
  <xsl:template match="item[not(@parent='true')]">
    <li>
      <a>
        <xsl:attribute name="href">
            <xsl:value-of select="$server"/>?pgid=<xsl:value-of select="@pgid"/>
        </xsl:attribute>
        <xsl:if test="@isSelected!='true'">
          <xsl:attribute name="class">
            toggle-link-text
          </xsl:attribute>
        </xsl:if>
        <xsl:call-template name="loadLabel"/>
      </a>
      <xsl:choose>
        <xsl:when test="@isSelected='true'">
          <xsl:if test="count(child::*) &gt;= 1">
            <xsl:call-template name="LoadSubMenuExpanded"/>
          </xsl:if>
        </xsl:when>
        <xsl:otherwise>
          <xsl:if test="count(child::*) &gt;= 1">
            <xsl:call-template name="LoadSubMenu"/>
          </xsl:if>
        </xsl:otherwise>
      </xsl:choose>
    </li>
  </xsl:template>
  
<xsl:template name="LoadSubMenu">
  <ul class="toggle-menu">
    <xsl:for-each select="item">
      <li>
        <a>
          <xsl:attribute name="href">
              <xsl:value-of select="$server"/>?pgid=<xsl:value-of select="@pgid"/>
          </xsl:attribute>
          <xsl:call-template name="loadLabel"/>
        </a>
      </li>
    </xsl:for-each>  
  </ul>
</xsl:template>
  <xsl:template name="LoadSubMenuExpanded">
    <ul>
      <xsl:for-each select="item">
        <li>
          <a>
            <xsl:attribute name="href">
                <xsl:value-of select="$server"/>?pgid=<xsl:value-of select="@pgid"/>
            </xsl:attribute>
            <xsl:call-template name="loadLabel"/>
          </a>
        </li>
      </xsl:for-each>
    </ul>
  </xsl:template>

<xsl:template name="loadLabel">
	<xsl:if test="$lang='eng'">
      <xsl:value-of select="@eng" disable-output-escaping="yes"/>
	</xsl:if>
	<xsl:if test="$lang='fre'">
		<xsl:value-of select="@fre" disable-output-escaping="yes"/>
	</xsl:if>
</xsl:template>
</xsl:stylesheet>