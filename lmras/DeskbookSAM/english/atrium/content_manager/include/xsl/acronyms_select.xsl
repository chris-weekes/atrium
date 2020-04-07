<?xml version="1.0" encoding="ISO-8859-1"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="html"/>
<xsl:param name="sort"/>
<xsl:template match="/">
	<xsl:apply-templates select="acronyms"/>
</xsl:template>
<xsl:template match="acronyms">

  <table id="adminTbl" cellpadding="0" cellspacing="0">
    <tr>
      <th width="40" nowrap="true" style="font-size:0.8em;text-align:center;"><a class="headerLnk"><xsl:attribute name="href">SAMAcronyms.aspx?pgid=3007&amp;sort=quicklist</xsl:attribute>Quicklist</a><xsl:if test="$sort='quicklist'">*</xsl:if></th>
      <th width="80" nowrap="true"><a class="headerLnk"><xsl:attribute name="href">SAMAcronyms.aspx?pgid=3007&amp;sort=eng</xsl:attribute>English</a><xsl:if test="$sort='eng' or sort=''">*</xsl:if></th>
      <th width="200" nowrap="true"><a class="headerLnk"><xsl:attribute name="href">SAMAcronyms.aspx?pgid=3007&amp;sort=descEng</xsl:attribute>Description (eng)</a><xsl:if test="$sort='descEng'">*</xsl:if></th>
      <th width="80" nowrap="true"><a class="headerLnk"><xsl:attribute name="href">SAMAcronyms.aspx?pgid=3007&amp;sort=fre</xsl:attribute>French</a><xsl:if test="$sort='fre'">*</xsl:if></th>
      <th width="200" nowrap="true"><a class="headerLnk"><xsl:attribute name="href">SAMAcronyms.aspx?pgid=3007&amp;sort=descFre</xsl:attribute>Description (fre)</a><xsl:if test="$sort='descFre'">*</xsl:if></th>
    </tr>
    <xsl:choose>
      <xsl:when test="$sort='' or $sort='eng'">
        <xsl:for-each select="acronym">
          <xsl:sort select="@english"/>
          <xsl:call-template name="row"/>
        </xsl:for-each>
      </xsl:when>
      <xsl:when test="$sort='descEng'">
        <xsl:for-each select="acronym">
          <xsl:sort select="@desc_e"/>
          <xsl:call-template name="row"/>
        </xsl:for-each>
      </xsl:when>
      <xsl:when test="$sort='quicklist'">
        <xsl:for-each select="acronym">
          <xsl:sort select="@quicklist" order="descending"/>
          <xsl:sort select="@english"/>
          <xsl:call-template name="row"/>
        </xsl:for-each>
      </xsl:when>
      <xsl:when test="$sort='fre'">
        <xsl:for-each select="acronym">
          <xsl:sort select="@french"/>
          <xsl:call-template name="row"/>
        </xsl:for-each>
      </xsl:when>
      <xsl:when test="$sort='descFre'">
        <xsl:for-each select="acronym">
          <xsl:sort select="@desc_f"/>
          <xsl:call-template name="row"/>
        </xsl:for-each>
      </xsl:when>
    </xsl:choose>
  </table>
</xsl:template>

<xsl:template name="row">
	<tr valign="top" onclick="location='SAMAcronyms.aspx?pgid=3007&amp;id={@id}'" style="cursor:hand" onmouseover="this.style.color='#6600ff';" onmouseout="this.style.color='black';">
	<xsl:if test="position() mod 2 = 0">
		<xsl:attribute name="style">background-color:#f3f3f3;cursor:hand</xsl:attribute>
	</xsl:if>
		<td style="text-align:center;"><xsl:if test="@quicklist='1'"><img src="images/Checkmark.png" alt=""/></xsl:if></td>
		<td><xsl:value-of select="@english"/></td>
		<td><xsl:value-of select="@desc_e"/></td>
		<td><xsl:value-of select="@french"/></td>
		<td><xsl:value-of select="@desc_f"/></td>
	</tr>
</xsl:template>
</xsl:stylesheet>