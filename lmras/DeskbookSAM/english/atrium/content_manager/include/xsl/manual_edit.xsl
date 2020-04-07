<?xml version='1.0' encoding="iso-8859-1"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:param name="id"/>
<xsl:output method="html"/>
<xsl:template match="/">
	<xsl:apply-templates select="//item[@id=$id]" />
</xsl:template>
<xsl:template match="item">
  <div class="span-5 module-form-fluid-none">
    <!--<div class="span-5" style="margin-bottom:8px;padding:0;text-align:right;">
      <a class="admin" href="http://workzone/english/r2200000/?pgid={@id}" target="_blank">
        <img src="images/htms.gif" alt="" border="0" style="margin-right:4px;"/>Workzone
      </a>

      <a class="admin" href="http://staging/english/r2200000/?pgid={@id}" target="_blank">
        <img src="images/htms.gif" alt="" border="0" style="margin-right:4px;"/>Staging
      </a>

      <a class="admin" href="http://infozone/english/r2200000/?pgid={@id}" target="_blank">
        <img src="images/htms.gif" alt="" border="0" style="margin-right:4px;"/>Infozone
      </a>
      <a class="admin" href="mailto:ls-sj-impt-epgi@cra-arc.gc.ca?subject=Page Tracker&amp;body=http://workzone/english/r2200000/admin.asp?pgid=2002&amp;id={@id}">
        E-mail to IMPT
      </a>
      <br/>
    </div>-->
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
        <xsl:choose>
          <xsl:when test="item"/>
          <xsl:otherwise>
            <button class="btn" type="submit" name="btnAction" onclick="return userConfirm('{@nodeType}');" value="Delete" style="margin-left:30px;">
              <div class="bImg bDelete"></div>
              <span>Delete</span>
            </button>
          </xsl:otherwise>
        </xsl:choose>
        <xsl:if test="(@nodeType='leaf') or (@nodeType='nodeleaf')">
          <button class="btn" type="button" onclick="launchEditorWindow('{@id}','eng' );" style="margin-left:30px;">
            
            <span>SAM Editor</span>
          </button>
        </xsl:if>
      </div>
    </fieldset>
    <fieldset>
      <legend>
        <strong>
          Properties
        </strong>
      </legend>

      <div class="span-6">
        <label class="lbl" for="id">Page ID</label>
        <input type="Hidden" name="id" value="{@id}"/>
        <span style="position:relative;top:3px;">
          <xsl:value-of select="@id"/>
        </span>
      </div>

      <div class="span-6">
        <label class="lbl" for="orphan">Orphan Page</label>
        <input type="Hidden" name="orphan" value="{@orphan}"/>
        <span style="position:relative;top:3px;">
          <xsl:value-of select="@orphan"/>
        </span>
      </div>

      <div class="span-6">
        <label class="lbl" for="pass">Type</label>
        <xsl:if test="@orphan='true'">
          <input type="Hidden" name="nodeType" value="{@nodeType}"/>
          <span style="position:relative;top:3px;">
            <xsl:value-of select="@nodeType"/>
          </span>
        </xsl:if>
        <xsl:if test="@orphan='false'">
        <select name="nodetype" class="input select">
          <option value="node"><xsl:if test="@nodeType='node'"><xsl:attribute name="selected">true</xsl:attribute></xsl:if>Section</option>
          <option value="nodeleaf"><xsl:if test="@nodeType='nodeleaf'"><xsl:attribute name="selected">true</xsl:attribute></xsl:if>Leaf w/ Sub-section</option>
          <option value="leaf"><xsl:if test="@nodeType='leaf'"><xsl:attribute name="selected">true</xsl:attribute></xsl:if>Leaf</option>
        </select>
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
    <fieldset>
      <legend>
        <strong>
          Metadata
        </strong>
      </legend>

      <div class="span-6">
        <label class="lbl" for="dcSubjectEng">DC.subject (eng)</label>
        <input type="text" class="input" name="dcSubjectEng">
          <xsl:attribute name="value">
            <xsl:value-of select="@dcSubjectEng"/>
          </xsl:attribute>
        </input>
      </div>
      <div class="span-6">
        <label class="lbl" for="dcSubjectFre">DC.subject (fre)</label>
        <input type="text" class="input" name="dcSubjectFre">
          <xsl:attribute name="value">
            <xsl:value-of select="@dcSubjectFre"/>
          </xsl:attribute>
        </input>
      </div>
      <div class="span-6">
        <label class="lbl" for="dcDescriptionEng">DC.Description (eng)</label>
        <input type="text" class="input" name="dcDescriptionEng">
          <xsl:attribute name="value">
            <xsl:value-of select="@dcDescriptionEng"/>
          </xsl:attribute>
        </input>
      </div>
      <div class="span-6">
        <label class="lbl" for="dcDescriptionFre">DC.Description (fre)</label>
        <input type="text" class="input" name="dcDescriptionFre">
          <xsl:attribute name="value">
            <xsl:value-of select="@dcDescriptionFre"/>
          </xsl:attribute>
        </input>
      </div>
      <div class="span-6">
        <label class="lbl" for="keywordsEng">Keywords (eng)</label>
        <textarea class="input" name="keywordsEng">
          <xsl:value-of select="@keywordsEng"/>
        </textarea>
      </div>
      <div class="span-6">
        <label class="lbl" for="keywordsFre">Keywords (fre)</label>
        <textarea class="input" name="keywordsFre">
          <xsl:value-of select="@keywordsFre"/>
        </textarea>
      </div>
    </fieldset>


    <fieldset>
      
      <legend>
        <strong>
          Publishing
        </strong>
      </legend>
      
      <div class="span-6">
        <label class="lbl" for="process">Principal Process</label>
        <select name="process" class="input select">
          <option value=""/>
          <option value="1">
            <xsl:if test="@process='1'">
              <xsl:attribute name="selected">true</xsl:attribute>
            </xsl:if>1. Planning
          </option>
          <option value="2">
            <xsl:if test="@process='2'">
              <xsl:attribute name="selected">true</xsl:attribute>
            </xsl:if>2. Content Development
          </option>
          <option value="3">
            <xsl:if test="@process='3'">
              <xsl:attribute name="selected">true</xsl:attribute>
            </xsl:if>3. Perform Quality Control
          </option>
          <option value="4">
            <xsl:if test="@process='4'">
              <xsl:attribute name="selected">true</xsl:attribute>
            </xsl:if>4. Approve Content
          </option>
          <option value="5">
            <xsl:if test="@process='5'">
              <xsl:attribute name="selected">true</xsl:attribute>
            </xsl:if>5. Publish Content
          </option>
          <option value="6">
            <xsl:if test="@process='6'">
              <xsl:attribute name="selected">true</xsl:attribute>
            </xsl:if>6. Content Published
          </option>
        </select>
      </div>
      
      <div class="span-6">
        <label class="lbl" for="translateTo">Translate To</label>
        <select name="translateTo" class="input select">
          <option value=""/>
          <option value="french">
            <xsl:if test="@translateTo='french'">
              <xsl:attribute name="selected">true</xsl:attribute>
            </xsl:if>French/français
          </option>
          <option value="english">
            <xsl:if test="@translateTo='english'">
              <xsl:attribute name="selected">true</xsl:attribute>
            </xsl:if>English/anglais
          </option>
        </select>
      </div>
      
      <div class="span-6">
        <label class="lbl" for="translationProcess">Translation Process</label>
        <select name="translationProcess" class="input select">
          <option value=""/>
          <option value="1">
            <xsl:if test="@translationProcess='1'">
              <xsl:attribute name="selected">true</xsl:attribute>
            </xsl:if>1. Not Started
          </option>
          <option value="2">
            <xsl:if test="@translationProcess='2'">
              <xsl:attribute name="selected">true</xsl:attribute>
            </xsl:if>2. In Translation
          </option>
          <option value="3">
            <xsl:if test="@translationProcess='3'">
              <xsl:attribute name="selected">true</xsl:attribute>
            </xsl:if>3. Review Translation
          </option>
          <option value="4">
            <xsl:if test="@translationProcess='4'">
              <xsl:attribute name="selected">true</xsl:attribute>
            </xsl:if>4. Approve Translation
          </option>
          <option value="5">
            <xsl:if test="@translationProcess='5'">
              <xsl:attribute name="selected">true</xsl:attribute>
            </xsl:if>5. Publish Translation
          </option>
          <option value="6">
            <xsl:if test="@translationProcess='6'">
              <xsl:attribute name="selected">true</xsl:attribute>
            </xsl:if>6. Translation Published
          </option>
        </select>
      </div>
      
      <div class="span-6">
        <label class="lbl" for="responsability">Responsibility</label>
        <input type="text" class="input" name="responsability">
          <xsl:attribute name="value">
            <xsl:value-of select="@responsability"/>
          </xsl:attribute>
        </input>
      </div>
      
      <div class="span-6">
        <label class="lbl" for="dateAssigned">Due Date</label>
        <input type="text" class="input date" name="dateAssigned">
          <xsl:attribute name="value">
            <xsl:value-of select="@dateAssigned"/>
          </xsl:attribute>
        </input>
        <span class="rsLbl">yyyy/mm/dd</span>
      </div>

      <div class="span-6">
        <label class="lbl" for="fileNumber">File Number</label>
        <input type="text" class="input" name="fileNumber">
          <xsl:attribute name="value">
            <xsl:value-of select="@fileNumber"/>
          </xsl:attribute>
        </input>
      </div>

      <div class="span-6">
        <label class="lbl" for="comment">Comment</label>
        <textarea class="input" name="comment" style="height:150px;">
          <xsl:value-of select="@comment"/>
        </textarea>
      </div>
      
    </fieldset>
  </div>
	
</xsl:template>
</xsl:stylesheet>
