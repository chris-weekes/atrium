<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:param name="lang"/>
  <xsl:output method="html" encoding="UTF-8"/>
  <xsl:template match="/">
    <ol>
      <xsl:apply-templates select="menu"/>
    </ol>
  </xsl:template>
  <xsl:template match="menu">
    <xsl:if test="$lang='eng'">
      <xsl:for-each select="*">
        <xsl:choose>
          <xsl:when test="position()=last()">
            <li>
              <a href="?pgid={@pgid}">
                <xsl:value-of select="@eng"/>
              </a>
            </li>
          </xsl:when>
          <xsl:otherwise>
            <li>
              <a href="?pgid={@pgid}">
                <xsl:value-of select="@eng"/>
              </a> &#62;
            </li>
          </xsl:otherwise>
        </xsl:choose>
      </xsl:for-each>
    </xsl:if>
    <xsl:if test="$lang='fre'">
      <xsl:for-each select="*">
        <xsl:choose>
          <xsl:when test="position()=last()">
            <li>
              <a href="?pgid={@pgid}">
                <xsl:value-of select="@fre"/>
              </a>
            </li>
          </xsl:when>
          <xsl:otherwise>
            <li>
              <a href="?pgid={@pgid}">
                <xsl:value-of select="@fre"/>
              </a> &#62;
            </li>
          </xsl:otherwise>
        </xsl:choose>
      </xsl:for-each>
    </xsl:if>
  </xsl:template>
</xsl:stylesheet>