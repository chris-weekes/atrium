<?xml version="1.0" encoding="ISO-8859-1"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="html"/>
<xsl:template match="/">
	<xsl:apply-templates select="directory"/>
</xsl:template>
<xsl:template match="directory">
  <div class="span-4">
    <table id="adminTbl" cellpadding="0" cellspacing="0">
      <xsl:for-each select="staff[(@isAssistant=1)]">
        <xsl:sort select="@l_name"/>
        <tr id="assistantId" name="{@id}" style="cursor:hand" onmouseover="this.style.color='#6600ff';" onmouseout="this.style.color='black';">
          <xsl:if test="position() mod 2 = 0">
            <xsl:attribute name="style">background-color:#f3f3f3;cursor:hand</xsl:attribute>
          </xsl:if>
          <td onclick="returnAssistant();" width="200">
            <xsl:value-of select="@l_name"/>, <xsl:value-of select="@f_name"/>
          </td>
        </tr>
      </xsl:for-each>
    </table></div>
</xsl:template>
</xsl:stylesheet>