<?xml version="1.0"?>

<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:param name="preview"/>
<xsl:output method="html"/>
<xsl:template match="images">
<style>
div.lnk{color: blue; font-weight : bold; text-decoration : none;font-size:0.9em;cursor:hand}

</style>
<table class="content" cellpadding="2" cellspacing="0" border="0">
	<tr>
		<td width="200" nowrap="true" class="adminTableHeader"><strong>File</strong></td>
		<td width="100%" class="adminTableHeader"><strong>Image</strong></td>
	</tr>
	<xsl:for-each select="image">
	<xsl:sort select="@name"/>
	<tr valign="top">
		<td width="120" nowrap="true" style="border-bottom:1px dashed steelblue;padding:4px;"><div onmouseover="this.style.textDecoration='underline';" onmouseout="this.style.textDecoration='none';" class="lnk" srcId="{@src}" onclick="ImgSelected();"><xsl:value-of select="@src"/></div></td>
		<td style="border-bottom:1px dashed steelblue;padding:4px;"><img src="../res.aspx?f={@src}" border="0" alt=""/></td>
	</tr>
	</xsl:for-each>		
</table>
</xsl:template>

</xsl:stylesheet>