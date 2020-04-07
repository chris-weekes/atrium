<?xml version='1.0'?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:param name="id"/>
<xsl:param name="new"/>
<xsl:output method="html"/>
<xsl:template match="/">
	<xsl:apply-templates select="/groups/group[@id=$id]" />
</xsl:template>
<xsl:template match="group">
  <div class="span-5 module-form-fluid-none">
  <fieldset>
    <div class="buttonrow">
      <xsl:if test="$new='true'">
        <button class="btn" id="btnAction" type="submit" name="btnAction" value="Save">
          <div class="bImg bSave"></div>
          <span>Save</span>
        </button>
      </xsl:if>
      <xsl:if test="$new='false'">
        <button class="btn" type="button" onclick="location='admin.asp?pgid=3012&amp;groupid={@id}'" value="View Members">
          <div class="bImg bNewMember"></div>
          <span>View Members</span>
        </button>
      </xsl:if>
      <button class="btn" type="button" onclick="location='admin.asp?pgid=3012';" name="btnAction" value="Return to List">
        <div class="bImg bCancel"></div>
        <span>Return to List</span>
      </button>
    </div>
  </fieldset>
    <div class="module-attention">
      <p>Creating a new group will also create a new page, along with a menu item under the "Service Groups" menu item.</p>
    </div>
    <br/>
    <fieldset>
      <legend>
        <strong>
          <img src="content_manager/images/properties.png" alt="" class="imgCenter"/>Properties
        </strong>
      </legend>
      <div class="span-5">
        <label class="lbl" for="id">Service Team ID</label>
        <input type="Hidden" id="id" name="id" value="{@id}"/>
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
    
  </div>
</xsl:template>
</xsl:stylesheet>
