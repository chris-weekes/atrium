<?xml version="1.0"  encoding="iso-8859-1"?>

<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:param name="pgid"/>
  <xsl:param name="highlightNode"/>
  <xsl:output method="html"/>

  <xsl:template match="/">
    <fieldset>
      <div class="span-5 buttonrow">
        <button class="btn" type="button" id="oExpandCollapseAll" value="ExpandCollapseAll" init="2" onclick="ExpandCollapseAll();">
          <div class="bImg bExpCol"></div>
          <span>Expand All</span>
        </button>
        <button class="btn" type="button" id="pasteItemToRootBtn" value="PasteToRoot" style="display:none;" onclick="location='SAMImages.aspx?pgid={$pgid}&amp;paste=Y&amp;ParentItem=ROOT&amp;PasteItem='+this.getAttribute('data-itemid');">
          <div class="bImg bPaste"></div>
          <span>Paste Item To Root</span>
        </button>
        <button class="btn" type="button" onclick="location='SAMStructure.aspx?&amp;list=Y';">
          <div class="bImg bListview"></div>
          <span>Grid View</span>
        </button>
      </div>
    </fieldset>

    <h3>Menu Structure</h3>
    <xsl:apply-templates select="item[@orphan='false']"/>

    <h3>Orphan Pages</h3>
    <xsl:apply-templates select="//item[@orphan='true']"/>

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
      <a class="menAnc" name="insNode" href="javascript:" onclick="location='SAMStructure.aspx?pgid={$pgid}&amp;nodetype=node&amp;parentId='+this.parentElement.srcId;return false">
        <img src="images/section.png" border="0" alt="" height="16" width="16" style="margin-right:12px;vertical-align:middle;"/>Insert New Section
      </a>
      <a class="menAnc" name="insLeafSection" href="javascript:" onclick="location='SAMStructure.aspx?pgid={$pgid}&amp;nodetype=nodeleaf&amp;parentId='+this.parentElement.srcId;return false">
        <img src="images/leafsection.png" border="0" alt="" height="16" width="16" style="margin-right:12px;vertical-align:middle;"/>Insert New Leaf (W/ Section)
      </a>
      <a class="menAnc" name="insLeaf" href="javascript:" onclick="location='SAMStructure.aspx?pgid={$pgid}&amp;nodetype=leaf&amp;parentId='+this.parentElement.srcId;return false">
        <img src="images/leaf.png" border="0" alt="" height="16" width="16" style="margin-right:12px;vertical-align:middle;"/>Insert New Leaf
      </a>
      <a class="menAnc" name="moveUp" href="javascript:" onclick="location='SAMStructure.aspx?pgid={$pgid}&amp;move=up&amp;moveid='+this.parentElement.srcId;return false">
        <img src="images/arrUp.gif" border="0" alt="" height="16" width="16" style="margin-right:12px;vertical-align:middle;"/>Move Item Up
      </a>
      <a class="menAnc" name="moveDown" href="javascript:" onclick="location='SAMStructure.aspx?pgid={$pgid}&amp;move=down&amp;moveid='+this.parentElement.srcId;return false">
        <img src="images/arrdown.gif" border="0" alt="" height="16" width="16" style="margin-right:12px;vertical-align:middle;"/>Move Item Down
      </a>
      <a class="menAnc" name="CutItem" href="javascript:" onclick="CutTreeViewItem();">
        <img src="images/cut.png" border="0" alt="" height="16" width="16" style="margin-right:12px;vertical-align:middle;"/>Cut
      </a>
      <a class="menAncDisabled" disabled="true" name="PasteItem" href="javascript:" onclick="event.cancelBubble=true;location='SAMStructure.aspx?pgid={$pgid}&amp;paste=Y&amp;ParentItem='+this.parentElement.srcId+'&amp;PasteItem='+CurrentCutItem.getAttribute('data-itemid');return false">
        <img src="images/paste.png" border="0" alt="" height="16" width="16" style="margin-right:12px;vertical-align:middle;"/>as Child
      </a>
      <a class="menAncDisabled" disabled="true" name="PasteBrotherItem" href="javascript:" onclick="event.cancelBubble=true;location='SAMStructure.aspx?pgid={$pgid}&amp;paste=Y&amp;parent=N&amp;ParentItem='+this.parentElement.srcId+'&amp;PasteItem='+CurrentCutItem.getAttribute('data-itemid');return false">
        <img src="images/paste.png" border="0" alt="" height="16" width="16" style="margin-right:12px;vertical-align:middle;"/>Same Level
      </a>
      <a class="menAnc" name="editOpen" href="javascript:" onclick="launchEditorWindow(this.parentElement.srcId,'eng' );">
        <img src="images/section.png" border="0" alt="" height="16" width="16" style="margin-right:12px;vertical-align:middle;"/>Open in SAM Editor
      </a>
    </div>
    <input type="Hidden" id="oHighlightNode" value="{$highlightNode}"/>
    <script>
      $( document ).ready(function() {
      SetCollapseExpandSections();
      window.setTimeout('scrollToNode()',200);
      });

    </script>
  </xsl:template>
  <!-- ERROR Template, this node does not match -->
  <xsl:template match="nextid">
    <!-- do nothing -->
  </xsl:template>

  <xsl:template name="liSubItem">
    <a>
      <xsl:attribute name="name">
        <xsl:value-of select="@id"/>
      </xsl:attribute>
    </a>
    <li class="li">
      <xsl:if test="@id!='1'">
        <xsl:attribute name="name">collection</xsl:attribute>
        <a class="CXLink" id="ExpCol{@id}" vid="xc" href="javascript:CollapseSection({@id}, false);">
          <IMG class="img" WIDTH="16" src="images/minus.gif" />
        </a>
      </xsl:if>
      <xsl:if test="@nodeType='node'">
        <IMG class="img" WIDTH="16" src="images/section.png" />
      </xsl:if>
      <xsl:if test="@nodeType='nodeleaf'">
        <IMG class="img" WIDTH="16" src="images/leafSection.png" />
      </xsl:if>
      <xsl:if test="@nodeType='leaf'">
        <IMG class="img" WIDTH="16" src="images/leaf.png" />
      </xsl:if>
      <xsl:choose>
        <xsl:when test="@nodeType='node'">
          <strong>
            <a class="mnItm" id="scrollTo{@id}" data-itemid="{@id}" ItemId="{@id}" levelCount="{count(ancestor::item)}">
              <xsl:attribute name="oncontextmenu">javascript:showContextMenu('1');</xsl:attribute>
              <xsl:attribute name="HREF">
                ?pgid=<xsl:value-of select="$pgid"/>&amp;id=<xsl:value-of select="@id"/>
              </xsl:attribute>
              <xsl:value-of select="@eng" />
            </a>
          </strong>
        </xsl:when>
        <xsl:otherwise>
          <a class="mnItm" id="scrollTo{@id}"  data-itemid="{@id}" ItemId="{@id}" levelCount="{count(ancestor::item)}">
            <xsl:attribute name="oncontextmenu">javascript:showContextMenu('1');</xsl:attribute>
            <xsl:attribute name="HREF">
              ?pgid=<xsl:value-of select="$pgid"/>&amp;id=<xsl:value-of select="@id"/>
            </xsl:attribute>
            <xsl:value-of select="@eng" />
          </a>
        </xsl:otherwise>
      </xsl:choose>
      <ul ulid="{@id}" data-ulid="{@id}" style="padding: 0;">
        <xsl:if test="(../item) and (@id!='1')">
          <xsl:attribute name="top">Y</xsl:attribute>
        </xsl:if>
        <xsl:apply-templates select="item[@orphan='false']"/>
      </ul>
    </li>

  </xsl:template>
  <xsl:template match="item[@orphan='false']">
    <xsl:call-template name="liSubItem"/>
  </xsl:template>

  <xsl:template match="item[@orphan='true']">
    <LI class="li lileaf">
      <IMG class="img" WIDTH="16">
        <xsl:attribute name="SRC">images/leaf.png</xsl:attribute>
      </IMG>
      <A class="mnItm" id="scrollTo{@id}" data-itemid="{@id}" ItemId="{@id}" nodeType="leaf" levelCount="{count(ancestor::item)}">
        <xsl:attribute name="oncontextmenu">javascript:showContextMenu('1');</xsl:attribute>
        <xsl:attribute name="HREF">
          ?pgid=<xsl:value-of select="$pgid"/>&amp;id=<xsl:value-of select="@id"/>
        </xsl:attribute>
        <xsl:value-of select="@eng" />
      </A>
    </LI>
  </xsl:template>


</xsl:stylesheet>