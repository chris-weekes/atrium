<?xml version="1.0" encoding="ISO-8859-1"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="html"/>
<xsl:param name="sort"/>
<xsl:template match="/">
	<xsl:apply-templates select="directory"/>
</xsl:template>
<xsl:template match="directory">

  
    <button class="btn" type="button" onclick="publishDirectory();" name="btnPublishDirectory" value="Copy Directory from Workzone to Staging">
      <div class="bImg bPublish"></div>
      <span>Copy Directory from Workzone to Staging</span>
    </button>
  <h3>Current Staff</h3>
  <table id="adminTbl" cellpadding="0" cellspacing="0">
    <tr>
      <th width="200" nowrap="true">
        <a>
          <xsl:attribute name="href">SAMDirectory.aspx?pgid=3009&amp;sort=name</xsl:attribute>Employee
        </a>
        <xsl:if test="$sort='name' or sort=''">*</xsl:if>
      </th>
      <th width="70" nowrap="true">
        <a>
          <xsl:attribute name="href">SAMDirectory.aspx?pgid=3009&amp;sort=group</xsl:attribute>Group
        </a>
        <xsl:if test="$sort='group'">*</xsl:if>
      </th>
      <th width="100" nowrap="true">
        <a>
          <xsl:attribute name="href">SAMDirectory.aspx?pgid=3009&amp;sort=team</xsl:attribute>Team
        </a>
        <xsl:if test="$sort='team'">*</xsl:if>
      </th>
      <th width="100" nowrap="true">
        <a>
          <xsl:attribute name="href">SAMDirectory.aspx?pgid=3009&amp;sort=status</xsl:attribute>Status
        </a>
        <xsl:if test="$sort='status'">*</xsl:if>
      </th>
    </tr>
  
		
		
		
		<xsl:choose>
			<xsl:when test="$sort='name' or $sort=''">
				<xsl:for-each select="staff[(@status!='3')]">
					<xsl:sort select="@l_name"/>
					<xsl:sort select="@f_name"/>
					<xsl:call-template name="row"/>
				</xsl:for-each>	
			</xsl:when>
			<xsl:when test="$sort='group'">
				<xsl:for-each select="staff[(@status!='3')]">
					<xsl:sort select="@group"/>
					<xsl:sort select="@l_name"/>
					<xsl:call-template name="row"/>
				</xsl:for-each>	
			</xsl:when>
			<xsl:when test="$sort='team'">
				<xsl:for-each select="staff[(@status!='3')]">
					<xsl:sort select="@acrnm_e"/>
					<xsl:sort select="@l_name"/>
					<xsl:call-template name="row"/>
				</xsl:for-each>	
			</xsl:when>
			<xsl:when test="$sort='status'">
				<xsl:for-each select="staff[(@status!='3')]">
					<xsl:sort select="@status" order="descending"/>
					<xsl:sort select="@l_name"/>
					<xsl:call-template name="row"/>
				</xsl:for-each>	
			</xsl:when>
		</xsl:choose>
			
</table>
  

<h3>Non-Current Staff</h3>
  <table id="adminTbl" cellpadding="0" cellspacing="0">
    <tr>
      <th width="200" nowrap="true">Employee</th>
    </tr>
			<xsl:for-each select="staff[(@status='3')]">
			<xsl:sort select="@l_name"/>
        <tr valign="top" onclick="location='SAMDirectory.aspx?pgid=3009&amp;id={@id}'" style="cursor:hand" onmouseover="this.style.color='#6600ff';" onmouseout="this.style.color='black';">
          <xsl:if test="position() mod 2 = 0">
            <xsl:attribute name="style">background-color:#f0f0f0;cursor:hand</xsl:attribute>
          </xsl:if>
				<td width="220"><xsl:value-of select="@l_name"/>, <xsl:value-of select="@f_name"/></td>
			</tr>
			</xsl:for-each>
</table>

</xsl:template>
  
<xsl:template name="row">
	<tr valign="top" onclick="location='SAMDirectory.aspx?pgid=3009&amp;id={@id}'" style="cursor:hand" onmouseover="this.style.color='#6600ff';" onmouseout="this.style.color='black';">
	<xsl:if test="position() mod 2 = 0">
		<xsl:attribute name="style">background-color:#f0f0f0;cursor:hand</xsl:attribute>
	</xsl:if>
		<td><xsl:value-of select="@l_name"/>, <xsl:value-of select="@f_name"/></td>
		<td><xsl:value-of select="@group"/></td>
		<td><xsl:value-of select="@acrnm_e"/></td>
		<td><xsl:if test="@status='2'"><xsl:attribute name="style">color:maroon;</xsl:attribute>Extended Leave</xsl:if></td>
	</tr>
</xsl:template>
</xsl:stylesheet>