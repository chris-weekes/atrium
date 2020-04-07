<?xml version='1.0'?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:param name="id"/>
<xsl:param name="parentName"/>
<xsl:param name="parentID"/>
<xsl:param name="nodeType"/>
<xsl:output method="html"/>
<xsl:template match="/">
	<xsl:apply-templates select="//item[@id=$id]" />
</xsl:template>
<xsl:template match="item">
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
        <button class="btn" type="submit" name="btnAction" value="Cancel">
          <div class="bImg bCancel"></div>
          <span>Cancel</span>
        </button>
      </div>
    </fieldset>

  <fieldset>
    <legend>
      <strong>
        Properties
      </strong>
    </legend>

    <div class="span-6">
      <label class="lbl" for="id">Parent Node</label>
      <xsl:choose>
        <xsl:when test="$parentID='null'">
          <input type="Hidden" name="parentID" value="null"/>

          <span style="position:relative;top:3px;">
            <xsl:if test="@orphan='false'">No Parent; Root Menu Item</xsl:if>
            <xsl:if test="@orphan='true'">No Parent; Orphan Page</xsl:if>
          </span>

        </xsl:when>
        <xsl:otherwise>
          <input type="Hidden" name="parentID" value="{$parentID}"/>
          <span style="position:relative;top:3px;">
            <xsl:value-of select="$parentName"/> (<xsl:value-of select="$parentID"/>)
          </span>
        </xsl:otherwise>
      </xsl:choose>
    </div>
    <div class="span-6">
      <label class="lbl" for="id">Page ID</label>
      <input type="Hidden" name="id" value="{@id}"/>
      <xsl:if test="@orphan='false'">
        <input type="Hidden" name="orphan" value="false"/>
      </xsl:if>
      <xsl:if test="@orphan='true'">
        <input type="Hidden" name="orphan" value="true"/>
      </xsl:if>
      <span style="position:relative;top:3px;">
        <xsl:value-of select="@id"/>
      </span>
    </div>

    <div class="span-6">
      <label class="lbl" for="nodetype">Type</label>
      <xsl:if test="@orphan='true'">
        <input type="Hidden" name="nodetype" value="leaf"/>
        <span style="position:relative;top:3px;">
          Leaf
        </span>
      </xsl:if>
      <xsl:if test="@orphan='false'">
        <select name="nodetype" class="input select">
          <option value="node"><xsl:if test="$nodeType='node'"><xsl:attribute name="selected">true</xsl:attribute></xsl:if>Section</option>
          <option value="nodeleaf"><xsl:if test="$nodeType='nodeleaf'"><xsl:attribute name="selected">true</xsl:attribute></xsl:if>Leaf w/ Sub-section</option>
          <option value="leaf"><xsl:if test="$nodeType='leaf'"><xsl:attribute name="selected">true</xsl:attribute></xsl:if>Leaf</option></select>
      </xsl:if>
    </div>

    <div class="span-6">
      <label class="lbl" for="eng">English Title</label>
      <input type="text" class="input" name="eng">
        <xsl:attribute name="value">
          <xsl:value-of select="@eng"/>
        </xsl:attribute>
      </input>
    </div>

    <div class="span-6">
      <label class="lbl" for="fre">French Title</label>
      <input type="text" class="input" name="fre">
        <xsl:attribute name="value">
          <xsl:value-of select="@fre"/>
        </xsl:attribute>
      </input>
    </div>

    <div class="span-6">
      <label class="lbl" for="tocPath">Breadcrumb (Eng)</label>
      <input type="text" class="input" name="tocPath">
        <xsl:attribute name="value">
          <xsl:value-of select="@tocPath"/>
        </xsl:attribute>
      </input>
    </div>

    <div title="Populate only if differs from english" class="span-6">
      <label class="lbl" for="tocPathF">Breadcrumb (Fre)</label>
      <input type="text" class="input" name="tocPathF">
        <xsl:attribute name="value">
          <xsl:value-of select="@tocPathF"/>
        </xsl:attribute>
      </input>
      <img src="images/help.png" alt="Populate only if differs from english" class="image-actual hlp" />
    </div>
  </fieldset>
  </div>
  
  
<!--  
<table cellspacing="2" width="100%">
	<tr>
		<th align="left" colspan="2" style="font-weight:bold;padding-left:130px;text-decoration:underline;">Properties</th>
	</tr>
	<tr>
		<td class="tdlbl" width="120" nowrap="true">Parent Node</td>
		<td>
			<xsl:choose>
				<xsl:when test="$parentID='null'">
					<input type="Hidden" name="parentID" value="null"/>
				</xsl:when>
				<xsl:otherwise>
					<input type="Hidden" name="parentID" value="{$parentID}"/>
				</xsl:otherwise>
			</xsl:choose>
			<xsl:value-of select="$parentName"/>
		</td>
	</tr>
	<tr>
		<td class="tdlbl" width="120" nowrap="true">Page ID</td>
		<td>
		<input type="Hidden" name="id" value="{@id}"/>
		<xsl:value-of select="@id"/></td>
	</tr>
	<tr>
		<td class="tdlbl" width="120" nowrap="true">Type</td>
		<td>
		<input type="Hidden" name="nodetype" value="{@nodeType}"/>
		<xsl:choose>
			<xsl:when test="@nodeType='node'">
				<img src="images/bo.gif" alt="" class="icon"/>
			</xsl:when>
			<xsl:when test="@nodeType='leaf'">
				<img src="images/dc.gif" alt=""  class="icon"/>
			</xsl:when>
			<xsl:otherwise>
			</xsl:otherwise>
		</xsl:choose>
		<xsl:value-of select="@nodeType"/>
		
		</td>
	</tr>
	<tr>
		<td class="tdlbl">English Title</td>
		<td><input type="text" name="eng" style="width:500px;"><xsl:attribute name="value"><xsl:value-of select="@eng"/></xsl:attribute></input></td>
	</tr>
	<tr>
		<td class="tdlbl">French Title</td>
		<td><input type="text" name="fre" style="width:500px;"><xsl:attribute name="value"><xsl:value-of select="@fre"/></xsl:attribute></input></td>
	</tr>
	<tr>
		<td class="tdlbl">Heading Path</td>
		<td><input type="text" name="tocPath" style="width:100px;"></input></td>
	</tr>
	<tr title="Populate only if differs from english">
		<td class="tdlbl">Heading Path (Fre)</td>
		<td><input type="text" name="tocPathF" style="width:100px;"><xsl:attribute name="value"><xsl:value-of select="@tocPathF"/></xsl:attribute></input></td>
	</tr>
	<tr>
		<td></td>
		<td><br/><br/>
		<input type="submit" id="btnAction" name="btnAction" value="Save" onclick="return ValidateNewPage();"></input>&#160;&#160;
		<input type="submit" id="btnCancel" name="btnAction" value="Cancel"></input>
		</td>
	</tr>
</table>-->
</xsl:template>
</xsl:stylesheet>
