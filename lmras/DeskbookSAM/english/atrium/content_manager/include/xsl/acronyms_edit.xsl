<?xml version='1.0'?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:param name="id"/>
<xsl:output method="html"/>
<xsl:template match="/">
	<xsl:apply-templates select="/acronyms/acronym[@id=$id]" />
</xsl:template>
<xsl:template match="acronym">

  <div class="span-5 module-form-fluid-none">
    <fieldset>
      <div class="span-5 buttonrow">
        <button class="btn" type="submit" name="btnAction" value="Save" onclick="return validateAcronym();">
          <div class="bImg bSave"></div>
          <span>Save</span>
        </button>
        <button class="btn" type="submit" name="btnAction" value="Cancel">
          <div class="bImg bCancel"></div>
          <span>Return to List</span>
        </button>
        <button class="btn" type="submit" name="btnAction" onclick="return confirmDelete('acronym');" value="Delete" style="margin-left:30px;">
          <div class="bImg bDelete"></div>
          <span>Delete</span>
        </button>
      </div>
    </fieldset>
    <fieldset>
      <legend>
        <strong>
          Properties
        </strong>
      </legend>

      <div class="span-5">
        <p>
          <span style="color:red;font-weight:bold;">*</span> - Denotes a requested/mandatory field.
        </p>
        <label class="lbl" for="id">Page ID</label>
        <input type="Hidden" name="id" value="{$id}"/>
        <span style="position:relative;top:3px;">
          <xsl:value-of select="@id"/>
        </span>
      </div>

      <div class="span-5">
        <label class="lbl" for="quicklist">Quicklist</label>
        <select name="quicklist" class="input select">
          <xsl:choose>
            <xsl:when test="@quicklist">
              <option value="1">
                <xsl:if test="@quicklist='1'">
                  <xsl:attribute name="selected">true</xsl:attribute>
                </xsl:if>
                True
              </option>
              <option value="0">
                <xsl:if test="@quicklist='0'">
                  <xsl:attribute name="selected">true</xsl:attribute>
                </xsl:if>
                False
              </option>
            </xsl:when>
            <xsl:otherwise>
              <option value="1">
                True
              </option>
              <option value="0" selected="true">
                False
              </option>
            </xsl:otherwise>
          </xsl:choose>
        </select>
      </div>
      <div class="span-5">
        <label class="lbl" for="english">
          <span style="color:red;font-weight:bold;">*</span> Acronym (eng)
        </label>
        <input type="text" class="input" name="english" onblur="acrnmLetter('eng',this.value)">
          <xsl:attribute name="value">
            <xsl:value-of select="@english"/>
          </xsl:attribute>
        </input>
      </div>
      <div class="span-5">
        <label class="lbl" for="french">
          <span style="color:red;font-weight:bold;">*</span> Acronym (fre)
        </label>
        <input type="text" class="input" name="french" onblur="acrnmLetter('fre',this.value)">
          <xsl:attribute name="value">
            <xsl:value-of select="@french"/>
          </xsl:attribute>
        </input>
      </div>
      <div class="span-5">
        <label class="lbl" for="desc_e">
          <span style="color:red;font-weight:bold;">*</span> Description (eng)
        </label>
        <input type="text" class="input" name="desc_e">
          <xsl:attribute name="value">
            <xsl:value-of select="@desc_e"/>
          </xsl:attribute>
        </input>
      </div>
      <div class="span-5">
        <label class="lbl" for="desc_f">
          <span style="color:red;font-weight:bold;">*</span> Description (fre)
        </label>
        <input type="text" class="input" name="desc_f">
          <xsl:attribute name="value">
            <xsl:value-of select="@desc_f"/>
          </xsl:attribute>
        </input>
      </div>
      <div class="span-5">
        <label class="lbl" for="letter_e">Letter (eng)</label>
        <input type="text" class="input" name="letter_e" readonly="true">
          <xsl:attribute name="value">
            <xsl:value-of select="@letter_e"/>
          </xsl:attribute>
        </input>
      </div>
      <div class="span-5">
        <label class="lbl" for="letter_f">Letter (fre)</label>
        <input type="text" class="input" name="letter_f" readonly="true">
          <xsl:attribute name="value">
            <xsl:value-of select="@letter_f"/>
          </xsl:attribute>
        </input>
      </div>
    </fieldset>
  </div>
  

<!--<table cellspacing="2" width="100%">
	<tr>
		<td class="tdlbl" width="120" nowrap="true">Acronym ID</td>
		<td><input type="text" disabled="true" style="width:90px;" id="id" name="id"><xsl:attribute name="value"><xsl:apply-templates select="@id"/></xsl:attribute></input></td>
	</tr>
	<tr>
		<td class="tdlbl"><span style="color:red;font-weight:bold;">*</span> Acronym (eng)</td>
		<td><input type="text" id="english" onblur="acrnmLetter('eng',this.value);" name="english"><xsl:attribute name="value"><xsl:apply-templates select="@english"/></xsl:attribute></input></td>
	</tr>
	<tr>
		<td class="tdlbl"><span style="color:red;font-weight:bold;">*</span> Acronym (fre)</td>
		<td><input type="text" id="french" onblur="acrnmLetter('fre',this.value);" name="french"><xsl:attribute name="value"><xsl:apply-templates select="@french"/></xsl:attribute></input></td>
	</tr>
	<tr>
		<td class="tdlbl"><span style="color:red;font-weight:bold;">*</span> Description (eng)</td>
		<td><input type="text" style="width:450px;" id="desc_e" name="desc_e"><xsl:attribute name="value"><xsl:apply-templates select="@desc_e"/></xsl:attribute></input></td>
	</tr>
	<tr>
		<td class="tdlbl"><span style="color:red;font-weight:bold;">*</span> Description (fre)</td>
		<td><input type="text" style="width:450px;" id="desc_f" name="desc_f"><xsl:attribute name="value"><xsl:apply-templates select="@desc_f"/></xsl:attribute></input></td>
	</tr>
	<tr>
		<td class="tdlbl">Letter (eng)</td>
		<td><input type="text" id="letter_e" readonly="true" name="letter_e"><xsl:attribute name="value"><xsl:apply-templates select="@letter_e"/></xsl:attribute></input></td>
	</tr>
	<tr>
		<td class="tdlbl">Letter (fre)</td>
		<td><input type="text" id="letter_f" readonly="true" name="letter_f"><xsl:attribute name="value"><xsl:apply-templates select="@letter_f"/></xsl:attribute></input></td>
	</tr>
	<tr valign="top">
		<td class="tdlbl">Add to QuickList</td>
		<td>
		<select name="quicklist" size="1">
			<xsl:choose>
				<xsl:when test="@quicklist">
					<option value="1">
						<xsl:if test="@node='1'"><xsl:attribute name="selected">true</xsl:attribute></xsl:if>
						True
					</option>
					<option value="0">
						<xsl:if test="@node='0'"><xsl:attribute name="selected">true</xsl:attribute></xsl:if>
						False
					</option>					
				</xsl:when>
				<xsl:otherwise>
					<option value="1">
						True
					</option>
					<option value="0" selected="true">
						False
					</option>
				</xsl:otherwise>
			</xsl:choose>
		</select>
		</td>
	</tr>
	<tr>
		<td></td>
		<td><br/>
			<input type="hidden" name="id"><xsl:attribute name="value"><xsl:value-of select="$id"/></xsl:attribute></input>
			<input type="submit" id="btnSubmit" name="btnAction" value="Submit" onclick="return validateAcronym();"></input>&#160;&#160;
			<input type="submit" id="btnDelete" name="btnAction" value="Delete" onclick="return confirmDelete('acronym');"></input>&#160;&#160;
			<input type="submit" id="btnCancel" name="btnAction" value="Cancel"></input>&#160;&#160;
		</td>
	</tr>
</table>
-->
</xsl:template>
</xsl:stylesheet>
