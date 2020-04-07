<?xml version="1.0" encoding="ISO-8859-1"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="html"/>
<xsl:template match="/">
	<xsl:apply-templates select="directory"/>
</xsl:template>
<xsl:template match="directory">
  <div class="span-4">
    <h3>Counsel</h3>
      <button class="btn" type="button" value="Cancel" onclick="returnValue=undefined;self.close();" style="margin:10px 0 4px 0;">
        <div class="bImg bCancel"></div>
        <span>Cancel</span>
      </button>

      <table id="adminTbl" cellpadding="0" cellspacing="0">
      <tr align="left">
       
        <td width="200" class="adminTableHeader">
          <strong>Name</strong>
        </td>
      </tr>
    </table>
    <div style="overflow:auto;height:250px;width:225px;">
      <table border="0" cellpadding="2" cellspacing="0" id="adminTbl">
        <xsl:for-each select="staff[@group='LA' and @status='1']">
          <xsl:sort select="@l_name"/>
          <tr style="cursor:hand" onmouseover="this.style.color='#6600ff';" onmouseout="this.style.color='black';">
            <xsl:if test="position() mod 2 = 0">
              <xsl:attribute name="style">background-color:#f3f3f3;cursor:hand</xsl:attribute>
            </xsl:if>
            <td  style="display:none;">
              <xsl:value-of select="@id"/>
            </td>
            <td width="200" onclick="returnLocation();">
              <xsl:value-of select="@l_name"/>, <xsl:value-of select="@f_name"/>
            </td>
          </tr>
        </xsl:for-each>
      </table>
    </div>
  </div>
</xsl:template>
</xsl:stylesheet>