<?xml version='1.0'?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:param name="id"/>
<xsl:param name="parentid"/>
<xsl:output method="html"/>
<xsl:template match="/">
	<xsl:apply-templates select="//container[@id=$id]" />
</xsl:template>
<xsl:template match="container">
  <div class="span-5 module-form-fluid-none">
    <fieldset>
      <div class="span-5 buttonrow">
        <button class="btn" type="submit" name="btnAction" id="btnSaveFolder" value="SaveFolder">
          <div class="bImg bSave"></div>
          <span>Save</span>
        </button>
        <button class="btn" type="submit" name="btnAction" value="SaveReturnFolder">
          <div class="bImg bSave"></div>
          <span>Save &amp; Return</span>
        </button>
        <button class="btn" type="submit" name="btnAction" value="Return to List">
          <div class="bImg bCancel"></div>
          <span>Cancel &amp; Return </span>
        </button>
        <xsl:if test="count(child::*) = 0">
        <button class="btn" type="submit" name="btnAction" onclick="return DeleteImageFolder();" value="DeleteFolder" style="margin-left:30px;">
          <div class="bImg bDelete"></div>
          <span>Delete</span>
        </button>
        </xsl:if>
      </div>
    </fieldset>
    <fieldset>
      <legend>
        <strong>
          Folder Properties
        </strong>
      </legend>
      <xsl:if test="$parentid!=''">
        <div class="span-6">
          <label class="lbl" for="parentid">Parent Folder ID</label>
          <input type="Hidden" name="parentid" value="{$parentid}"/>
          <span style="position:relative;top:3px;">
            <xsl:value-of select="$parentid"/>
          </span>
        </div>
        
      </xsl:if>
      <div class="span-6">
        <label class="lbl" for="id">Folder ID</label>
        <input type="Hidden" name="id" value="{@id}"/>
        <span style="position:relative;top:3px;">
          <xsl:value-of select="@id"/>
        </span>
      </div>
      <div class="span-6">
        <label class="lbl" for="name">Name</label>
        <input type="text" class="input" name="name" onkeydown="DontSubmitOnEnter();">
          <xsl:attribute name="value">
            <xsl:value-of select="@name"/>
          </xsl:attribute>
        </input>
      </div>
    </fieldset>
  </div>
</xsl:template>
</xsl:stylesheet>
