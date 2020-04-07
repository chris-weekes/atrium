<?xml version='1.0'?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:param name="id"/>
<xsl:param name="new"/>
<xsl:param name="groupName"/>
<xsl:output method="html"/>
<xsl:template match="/">
	<xsl:apply-templates select="/groups/group/member[@id=$id]" />
</xsl:template>
<xsl:template match="member">
  <input type="Hidden" name="groupid" value="{../@id}"/>
  <div class="span-5 module-form-fluid-none">
    <fieldset>
      <div class="buttonrow">
        <xsl:if test="$new='true'">
        <button class="btn" id="btnAction" type="submit" name="btnAction" value="Save">
          <div class="bImg bSave"></div>
          <span>Save</span>
        </button>
        <button class="btn" type="submit" name="btnAction" value="Back">
          <div class="bImg bCancel"></div>
          <span>Back</span>
        </button>
        </xsl:if>
        <xsl:if test="$new='false'">
        <button class="btn" type="submit" name="btnAction" value="Back">
          <div class="bImg bCancel"></div>
          <span>Back</span>
        </button>
          <button class="btn" type="submit" name="btnAction" value="Remove Member from Group" style="margin-left:30px;">
            <div class="bImg bDelete"></div>
            <span>Remove Member from Group</span>
          </button>
        </xsl:if>
      </div>
    </fieldset>
    <fieldset>
      <xsl:if test="$new='true'">
        <legend><img src="content_manager/images/properties.png" alt="" class="imgCenter"/><strong>New Member for:</strong></legend>
        <div class="span-5"><p><strong><xsl:value-of select="$groupName"/></strong></p></div>
      </xsl:if>
      <xsl:if test="$new='false'">
        <legend><img src="content_manager/images/properties.png" alt="" class="imgCenter"/><strong>Member of:</strong></legend>
        <div class="span-5"><p><strong><xsl:value-of select="../@name_e"/></strong></p></div>
      </xsl:if>
    </fieldset>
    <fieldset>
      <legend>
        <strong>
          <img src="content_manager/images/member.png" alt=""/> Member
        </strong>
      </legend>
      <div class="span-5">
        <label class="lbl" for="memberid">Member ID</label>
        <input type="Hidden" name="memberid" value="{@id}"/>
        <span style="position:relative;top:3px;">
          <xsl:value-of select="@id"/>
        </span>
      </div>
      <xsl:if test="$new='true'">
        <div class="span-5">
          <label class="lbl" for="memberName"><a href="javascript:loadMembersList();">Name</a></label>
          <input type="text" class="input" name="memberName" readonly="true"><xsl:attribute name="value"/></input>
          <input type="Hidden" name="empid"/>
        </div>
      </xsl:if>
      <xsl:if test="$new='false'">
        <div class="span-5">
          <label class="lbl" for="memberName">Name</label>
          <input type="text" class="input" name="memberName" readonly="true"><xsl:attribute name="value"><xsl:value-of select="@name"/></xsl:attribute></input>
          
        </div>
      </xsl:if>
    </fieldset>
  </div>
</xsl:template>
</xsl:stylesheet>
