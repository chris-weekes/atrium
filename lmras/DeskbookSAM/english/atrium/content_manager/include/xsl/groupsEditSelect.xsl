<?xml version="1.0" encoding="ISO-8859-1"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="html"/>
<xsl:template match="/">
	<xsl:apply-templates select="groups"/>
</xsl:template>
<xsl:template match="groups">

  <button class="btn" type="button" onclick="publishGroups();" name="btnPublishDirectory" value="Copy Directory from Workzone to Staging">
    <div class="bImg bPublish"></div>
    <span>Copy (All) Service Teams/Members from Workzone to Staging</span>
  </button>

  <table id="adminTbl" cellpadding="0" cellspacing="0">
    <tr>
      <th width="328" nowrap="true">
        Name (Eng)
      </th>
      <th width="328" nowrap="true">
        Name (Fre)
      </th>
    </tr>
    <xsl:for-each select="group">
      <xsl:sort select="@name_e"/>
      <tr valign="top" onclick="location='admin.asp?pgid=3012&amp;groupid={@id}'" style="cursor:hand" onmouseover="this.style.color='#6600ff';" onmouseout="this.style.color='black';">
        <xsl:if test="position() mod 2 = 0">
          <xsl:attribute name="style">background-color:#f0f0f0;cursor:hand</xsl:attribute>
        </xsl:if>
        <td nowrap="true">
          <xsl:value-of select="@name_e"/>
        </td>
        <td nowrap="true">
          <xsl:value-of select="@name_f"/>
        </td>
      </tr>
    </xsl:for-each>
  </table>
</xsl:template>
</xsl:stylesheet>