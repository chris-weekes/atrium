<?xml version='1.0'?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:param name="id"/>
<xsl:output method="html"/>
<xsl:template match="/">
	<xsl:apply-templates select="//image[@id=$id]" />
</xsl:template>
<xsl:template match="image">
  <div class="span-5 module-form-fluid-none">
    <fieldset>
      <div class="span-5 buttonrow">
        <button class="btn" type="submit" name="btnAction" value="Save">
          <div class="bImg bSave"></div>
          <span>Save</span>
        </button>
        <button class="btn" type="submit" name="btnAction" value="SaveReturn">
          <div class="bImg bSave"></div>
          <span>Save &amp; Return</span>
        </button>
        <button class="btn" type="submit" name="btnAction" value="Return to List">
          <div class="bImg bCancel"></div>
          <span>Cancel &amp; Return </span>
        </button>
        <button class="btn" type="submit" name="btnAction" onclick="return DeleteImage();" value="Delete" style="margin-left:30px;">
          <div class="bImg bDelete"></div>
          <span>Delete</span>
        </button>
      </div>
    </fieldset>
    <fieldset>
      <legend>
        <strong>
          Image Properties
        </strong>
      </legend>
      <div class="span-6">
        <label class="lbl" for="id">Image ID</label>
        <input type="Hidden" name="id" value="{@id}"/>
        <span style="position:relative;top:3px;">
          <xsl:value-of select="@id"/>
        </span>
      </div>
      <div class="span-6">
        <label class="lbl" for="src">Source File</label>
        <input type="Hidden" name="src" value="{@src}"/>
        <span style="position:relative;top:3px;">
          <xsl:value-of select="@src"/>
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
    <fieldset>
      <legend>
        <strong>
          References
        </strong>
      </legend>

    </fieldset>
    <fieldset style="border:none;">
      <legend>
        <strong>
          Image Preview
        </strong>
      </legend>
      <div >
          <!--<img src="../common/images/{@src}" style="margin-top:12px;background-color:#eaeaea;border:2px outset #fafafa;padding:12px;"/>-->
        <img src="../res.aspx?f={@src}&amp;id={@id}" style="margin-top:12px;background-color:#eaeaea;border:2px outset #fafafa;padding:12px;"/>
      </div>
    </fieldset>
   
  </div>
</xsl:template>
</xsl:stylesheet>
