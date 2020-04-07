<?xml version="1.0" encoding="ISO-8859-1"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:param name="groupid"/>
<xsl:output method="html"/>
<xsl:template match="/">
	<xsl:apply-templates select="groups/group[@id=$groupid]"/>
</xsl:template>
<xsl:template match="group">

  <div class="span-5 module-form-fluid-none">
  <fieldset>
    <div class="buttonrow">
      <button class="btn" id="btnAction" type="submit" name="btnAction" value="Save">
        <div class="bImg bSave"></div>
        <span>Save</span>
      </button>
      <button class="btn" type="button" onclick="location='admin.asp?pgid=3012';" name="btnAction" value="Return to Service Teams List">
        <div class="bImg bCancel"></div>
        <span>Return to List</span>
      </button>
      <button class="btn" type="button" onclick="location='admin.asp?pgid=3012&amp;groupid={@id}&amp;insert=new';" value="New Service Team Member">
        <div class="bImg bNewMember"></div>
        <span>New Member</span>
      </button>
      <button class="btn" type="submit" name="btnAction" onclick="return confirmDelete('group');" value="Delete Service Team" style="margin-left:30px;">
        <div class="bImg bDelete"></div>
        <span>Delete Service Team</span>
      </button>
    </div>
  </fieldset>
    <fieldset>
      <legend>
        <strong>
          <img src="content_manager/images/properties.png" alt="" class="imgCenter"/>Properties
        </strong>
      </legend>
      <div class="span-5">
        <label class="lbl" for="id">Service Team ID</label>
        <input type="Hidden" name="id" value="{@id}"/>
        <span style="position:relative;top:3px;">
          <xsl:value-of select="@id"/>
        </span>
      </div>
      <div class="span-5">
        <label class="lbl" for="name_e">Name (English)</label>
        <input type="text" class="input" name="name_e">
          <xsl:attribute name="value">
            <xsl:value-of select="@name_e"/>
          </xsl:attribute>
        </input>
      </div>
      <div class="span-5">
        <label class="lbl" for="name_f">Name (French)</label>
        <input type="text" class="input" name="name_f">
          <xsl:attribute name="value">
            <xsl:value-of select="@name_f"/>
          </xsl:attribute>
        </input>
      </div>
    </fieldset>
    <fieldset>
      <legend>
        <strong>
          <img src="content_manager/images/member.png" alt=""  class="imgCenter"/>Members
        </strong>
      </legend>
      <xsl:if test="count(member)&lt;1">
        <p>
          <img src="content_manager/images/warning.png" alt="" class="imgCenter"/><strong style="text-decoration:underline;">There are no members on this team</strong></p>
      </xsl:if>

      <xsl:if test="count(member)>0">
        <table border="0" cellpadding="0" cellspacing="0">
          <xsl:for-each select="member">
            <xsl:sort select="@name"/>
            <tr valign="top" onclick="location='admin.asp?pgid=3012&amp;memberid={@id}'" style="cursor:hand" onmouseover="this.style.color='#6600ff';" onmouseout="this.style.color='black';">
              <xsl:if test="position() mod 2 = 0">
                <xsl:attribute name="style">background-color:#f0f0f0;cursor:hand</xsl:attribute>
              </xsl:if>
              <td nowrap="true">
                <xsl:value-of select="@name"/>
              </td>
            </tr>
          </xsl:for-each>
        </table>

      </xsl:if>

    </fieldset>
    </div>


</xsl:template>
</xsl:stylesheet>