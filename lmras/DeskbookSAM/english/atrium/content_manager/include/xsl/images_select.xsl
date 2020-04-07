<?xml version="1.0"?>

<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:param name="preview"/>
<xsl:param name="highlightNode"/>
<xsl:param name="pgid"/>
<xsl:output method="html"/>
<xsl:template match="images">

  <fieldset>
    <div class="span-5 buttonrow">
      <button class="btn" type="button" onclick="location='SAMImages.aspx?pgid={$pgid}&amp;treeview=true';">
        <div class="bImg bTreeview"></div>
        <span>Tree View</span>
      </button>
      <button class="btn" type="button" onclick="document.all.chkPreviewImages.click();">
        <div class="bImg bPreviewImages"></div>
        <span>Preview Images</span>
      </button>
      <input type="Checkbox" id="chkPreviewImages" name="chkPreviewImages" onclick="location='SAMImages.aspx?pgid={$pgid}&amp;preview='+this.checked;">
        <xsl:if test="$preview='true'">
          <xsl:attribute name="checked">
            <xsl:value-of select="$preview"/>
          </xsl:attribute>
        </xsl:if>
      </input>
    </div>
  </fieldset>
  
    
  
  
	<br/>
      <table id="adminTbl" cellpadding="0" cellspacing="0">
        <tr>
          <th nowrap="true">Image Name</th>
          <th nowrap="true">File</th>
          <xsl:if test="$preview='true'">
            <th>Image</th>
          </xsl:if>
        </tr>
        <xsl:for-each select="//image">
          <xsl:sort select="@name"/>
        <tr valign="top" onclick="location='SAMImages.aspx?pgid={$pgid}&amp;id={@id}';" style="cursor:hand" onmouseover="this.style.color='#6600ff';" onmouseout="this.style.color='black';">
          <xsl:if test="position() mod 2 = 0">
            <xsl:attribute name="style">background-color:#f3f3f3;cursor:hand</xsl:attribute>
          </xsl:if>
          <td>
            <xsl:value-of select="@name"/>
          </td>
          <td>
            <xsl:value-of select="@src"/>

            <xsl:if test="$preview='true'">
              <br/>
              <br/>
              <!--<img src="../common/images/{@src}" border="0" alt="{@name}"/>-->
                  <img src="../res.aspx?f={@src}" border="0" alt="{@name}"/>
              <br/>
              <br/>
            </xsl:if>
          </td>
        </tr>
        </xsl:for-each>
      </table>
  
</xsl:template>
</xsl:stylesheet>