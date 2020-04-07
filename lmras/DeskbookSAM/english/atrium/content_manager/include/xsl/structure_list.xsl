<?xml version="1.0"  encoding="iso-8859-1"?>

<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:param name="pgid"/>
  <xsl:param name="highlightNode"/>
  <xsl:output method="html"/>
  
  
  <xsl:template match="/">
    <fieldset>
      <div class="span-5 buttonrow">
        <button class="btn" type="button" onclick="location='SAMStructure.aspx';">
          <div class="bImg bTreeview"></div>
          <span>Tree View</span>
        </button>
        <button class="btn" type="button" onclick="location='SAMStructure.aspx?&amp;list=Y&amp;Export=Y';">
          <div class="bImg bListview"></div>
          <span>Export as Excel</span>
        </button>
      </div>
    </fieldset>

    <h3>Menu Structure</h3>
    <table>
      <tr>
        <th>PageID</th>
        <th>PageName(Eng)</th>
        <th>Principal Process</th>
        <th>Translate To</th>
        <th>Translation Process</th>
        <th>Responsibility</th>
        <th>Due Date</th>
        <th>File Number</th>
        <th>Comment</th>
      </tr>
      <xsl:apply-templates select="//item[@orphan='false']"/>
    </table>
    <style>

      .li { list-style-type:none;list-style-position : outside;padding:1px;}
      .lileaf{margin-left:16px;margin-bottom:2px;}
      .content a:link{color: blue; font-weight : bold; text-decoration : none;}
      .content a:visited{color: blue; font-weight : bold; text-decoration : none;}
      .content a:hover{color: #cc3333; font-weight : bold; text-decoration : underline;}
      .content a.u:link{color: blue; font-weight : bold; text-decoration : none;}
      .content a.u:visited{color: blue; font-weight : bold; text-decoration : none;}
      .content a.u:hover{color: #cc3333; font-weight : bold; text-decoration : underline;}
      .content a.uu:link{color: blue; font-weight : bold; text-decoration : underline;font-style:italic}
      .content a.uu:visited{color: blue; font-weight : bold; text-decoration : underline;font-style:italic}
      .content a.uu:hover{color: #cc3333; font-weight : bold; text-decoration : none;font-style:italic}
      .img{margin-top:2px;margin-right:8px;position:relative;top:2px;}
      div.men{background-image : url(images/contextMenuBack.gif);BORDER: 1px solid #999999;position:absolute;padding:1px;margin:0;FILTER: progid:DXImageTransform.Microsoft.GradientWipe(GradientSize=0.3,duration=0.25,wipestyle=1,motion=forward)progid:DXImageTransform.Microsoft.Shadow(color=#aaaaaa,direction=120, strength=3);}
      a.menAnc{color:black;font-weight:normal;display:block;text-decoration:none;font-size:11px;height:20px;font-family:tahoma;padding:1px;width:100%;cursor:default;padding-left:4px;margin:1;}
      a.menAncDisabled{color:black;font-weight:normal;display:block;text-decoration:none;font-size:11px;height:20px;font-family:tahoma;padding:1;width:100%;cursor:default;padding-left:4px;margin:0;}

      a.menAnc:hover{color:black;text-decoration:underline;}
      a.menAnc:active{color:black;text-decoration:none;}
      a.menAnc img, a.menAncDisabled img{margin:0;padding:0;}

      a.contextHighlight{background-color:#ffffc0;}
      a.CXLink{color:blue;font-size:0.8em;position:relative;top:-2px;text-decoration:none;}
      a.CXLink img{margin-left:3px;position:relative;top:1px;}
      a.mnItm:link{color:blue;text-decoration:none;}
      a.mnItm:hover{color:blue;text-decoration:underline;}
      a.mnItm:visited{color:blue;text-decoration:none;}

    </style>
    <div id="contextMenu" name="divMenu" class="men" style="display:none;z-index:200;width:180px;" onclick="clearAll();">
      <a class="menAnc" name="editOpen" href="javascript:" onclick="launchEditorWindow(this.parentElement.srcId,'eng' );">
        <img src="images/section.png" border="0" alt="" height="16" width="16" style="margin-right:12px;vertical-align:middle;"/>Open in SAM Editor
      </a>
    </div>
    <h3>Orphan Page</h3>
    <table>
      <tr>
        <th>PageID</th>
        <th>PageName(Eng)</th>
        <th>Principal Process</th>
        <th>Translate To</th>
        <th>Translation Process</th>
        <th>Responsibility</th>
        <th>Due Date</th>
        <th>File Number</th>
        <th>Comment</th>
      </tr>
      <xsl:apply-templates select="//item[@orphan='true']"/>
    </table>
  </xsl:template>

  <!-- ERROR Template, this node does not match -->
  <xsl:template match="nextid">
    <!-- do nothing -->
  </xsl:template>

  <xsl:template name="liSubItem">
    <tr>
      <td>
        <xsl:value-of select="@id"/>
      </td>
      <td>
        <a class="mnItm" id="scrollTo{@id}" ItemId="{@id}" data-itemid="{@id}" levelCount="{count(ancestor::item)}">
          <xsl:attribute name="HREF">
            ?pgid=<xsl:value-of select="$pgid"/>&amp;id=<xsl:value-of select="@id"/>
          </xsl:attribute>
          <xsl:attribute name="oncontextmenu">javascript:showListContextMenu('1');</xsl:attribute>
          <xsl:value-of select="@eng" />
        </a>
      </td>
      <td>
        <xsl:if test="@process='1'">
          1. Planning
        </xsl:if>
        <xsl:if test="@process='2'">
          2. Content Development
        </xsl:if>
        <xsl:if test="@process='3'">
          3. Perform Quality Control
        </xsl:if>
        <xsl:if test="@process='4'">
          4. Approve Content
        </xsl:if>
        <xsl:if test="@process='5'">
          5. Publish Content
        </xsl:if>
        <xsl:if test="@process='6'">
          6. Content Published
        </xsl:if>
      </td>
      <td>
        <xsl:if test="@translateTo='french'">
          French/français
        </xsl:if>
        <xsl:if test="@translateTo='english'">
          English/anglais
        </xsl:if>
      </td>
      <td>
        <xsl:if test="@translationProcess='1'">
          1. Not Started
        </xsl:if>
        <xsl:if test="@translationProcess='2'">
          2. In Translation
        </xsl:if>
        <xsl:if test="@translationProcess='3'">
          3. Review Translation
        </xsl:if>
        <xsl:if test="@translationProcess='4'">
          4. Approve Translation
        </xsl:if>
        <xsl:if test="@translationProcess='5'">
          5. Publish Translation
        </xsl:if>
        <xsl:if test="@translationProcess='6'">
          6. Translation Published
        </xsl:if>
      </td>
      <td>
          <xsl:value-of select="@responsability"/>

      </td>
      <td>
        
          <xsl:value-of select="@dateAssigned"/>

      </td>
      <td>
       
          <xsl:value-of select="@fileNumber"/>
   
      </td>
      <td>
        <xsl:value-of select="@comment"/>
      </td>
    </tr>

  </xsl:template>

  <xsl:template match="item[@orphan='false']">
    <xsl:call-template name="liSubItem"/>
  </xsl:template>
  <xsl:template match="item[@orphan='true']">
    <xsl:call-template name="liSubItem"/>
  </xsl:template>
</xsl:stylesheet>