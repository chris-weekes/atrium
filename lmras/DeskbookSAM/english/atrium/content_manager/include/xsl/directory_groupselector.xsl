<?xml version="1.0" encoding="ISO-8859-1"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="html"/>
<xsl:template match="/">
	<xsl:apply-templates select="groups"/>
</xsl:template>
<xsl:template match="groups">
  <div class="span-4">
<table id="adminTbl" cellpadding="0" cellspacing="0">
	<xsl:for-each select="group">
		<xsl:sort select="@name_e"/>
		<tr onclick="returnGroup('{@id}','{@empid}');" name="" style="cursor:hand" onmouseover="this.style.color='#6600ff';" onmouseout="this.style.color='black';">
		<xsl:if test="position() mod 2 = 0">
			<xsl:attribute name="style">cursor:hand;background-color:#f0f0f0</xsl:attribute>
		</xsl:if>
		<td><xsl:value-of select="@name_e"/></td>
		</tr>
	</xsl:for-each>
</table>
  </div>
</xsl:template>
</xsl:stylesheet>