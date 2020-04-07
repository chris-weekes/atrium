<?xml version="1.0"  encoding="iso-8859-1"?>

<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:param name="pgid"/>
<xsl:param name="highlightNode"/>
<xsl:output method="html"/>

<xsl:template match="/">
  
  <fieldset>
    <div class="span-5 buttonrow">
      <button class="btn" type="button" onclick="location='SAMImages.aspx?pgid={$pgid}&amp;treeview=false';">
        <div class="bImg bListview"></div>
        <span>List View</span>
      </button>
      <button class="btn" type="button" id="oExpandCollapseAllImg" value="ExpandCollapseAllImg" init="1" onclick="ExpandCollapseAll();">
        <div class="bImg bExpCol2"></div>
        <span>Collapse All</span>
      </button>
      <button class="btn" type="button" id="pasteItemToRootBtn" value="PasteToRootImg" style="display:none;" onclick="location='SAMImages.aspx?pgid={$pgid}&amp;paste=Y&amp;ParentItem=ROOT&amp;PasteItem='+this.itemid;">
        <div class="bImg bPaste"></div>
        <span>Paste To Root</span>
      </button>
    </div>
  </fieldset>

  <xsl:apply-templates select="images"/>
  
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
  .img{margin-top:2px;margin-right:4px;position:relative;top:3px;}
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
    <a class="menAnc" name="insContainer" href="javascript:" onclick="location='SAMImages.aspx?pgid={$pgid}&amp;NewFolder=Y&amp;parentId='+this.parentElement.srcId;return false"><img src="images/folder.png" border="0" alt="" height="16" width="16" style="margin-right:12px;vertical-align:middle;"/>Insert New Container</a>
    <a class="menAnc" name="moveUp" href="javascript:" onclick="location='SAMImages.aspx?pgid={$pgid}&amp;move=up&amp;srctype='+this.parentElement.srcType+'&amp;targetid='+this.parentElement.MoveUpTargetId+'&amp;moveid='+this.parentElement.srcId;return false"><img src="images/arrUp.gif" border="0" alt="" height="16" width="16" style="margin-right:12px;vertical-align:middle;"/>Move Up</a>
    <a class="menAnc" name="moveDown" href="javascript:" onclick="location='SAMImages.aspx?pgid={$pgid}&amp;move=down&amp;srctype='+this.parentElement.srcType+'&amp;targetid='+this.parentElement.MoveDownTargetId+'&amp;moveid='+this.parentElement.srcId;return false"><img src="images/arrdown.gif" border="0" alt="" height="16" width="16" style="margin-right:12px;vertical-align:middle;"/>Move Down</a>
    <a class="menAnc" name="CutItem" href="javascript:" onclick="CutContainer();"><img src="images/cut.png" border="0" alt="" height="16" width="16" style="margin-right:12px;vertical-align:middle;"/>Cut</a>
    <a class="menAncDisabled" disabled="true" name="PasteItem" href="javascript:" onclick="event.cancelBubble=true;location='SAMImages.aspx?pgid={$pgid}&amp;paste=Y&amp;ParentItem='+this.parentElement.srcId+'&amp;PasteItem='+this.id;return false"><img src="images/paste.png" border="0" alt="" height="16" width="16" style="margin-right:12px;vertical-align:middle;"/>Paste</a>
    <a class="menAncDisabled" disabled="true" name="PasteBrotherItem" href="javascript:" onclick="event.cancelBubble=true;location='SAMImages.aspx?pgid={$pgid}&amp;paste=Y&amp;parent=N&amp;ParentItem='+this.parentElement.srcId+'&amp;PasteItem='+CurrentCutItem.ItemId;return false">
      <img src="images/paste.png" border="0" alt="" height="16" width="16" style="margin-right:12px;vertical-align:middle;"/>Same Level
    </a>
   </div>
<input type="Hidden" id="oHighlightNode" value="{$highlightNode}"/>
<script>
  //SetCollapseExpandSections();
  window.setTimeout('scrollToNode()',200);
</script>
</xsl:template>
<!-- ERROR Template, this node does not match -->
<xsl:template match="nextid">
	<!-- do nothing -->
</xsl:template>

<xsl:template match="images">
  <xsl:apply-templates select="container"/>
  <xsl:apply-templates select="image"/>
</xsl:template>

  <xsl:template name="liSubItem">
    <a>
      <xsl:attribute name="name">
        <xsl:value-of select="@id"/>
      </xsl:attribute>
    </a>
    <li class="li" iscontainer="true">
      <xsl:if test="@id!='1'">
        <xsl:attribute name="name">collection</xsl:attribute>
      <a class="CXLink" id="ExpCol{@id}" vid="xc" href="javascript:CollapseSection({@id}, false);">
        <IMG class="img" WIDTH="16" src="images/minus.gif" />
      </a>
      </xsl:if>
      <IMG class="img" WIDTH="16" src="images/folder.png" />

      <a class="mnItm" id="scrollTo{@id}" ContainerId="{@id}" levelCount="{count(ancestor::item)}">
        <xsl:if test="(@id!='1')">
          <xsl:attribute name="oncontextmenu">javascript:showContextMenuContainer();</xsl:attribute>
        </xsl:if>
        <xsl:attribute name="HREF">
          ?pgid=<xsl:value-of select="$pgid"/>&amp;id=<xsl:value-of select="@id"/>&amp;isfolder=Y
        </xsl:attribute>
        <xsl:value-of select="@name" />
      </a>
      <ul ulid="{@id}" style="padding: 0;margin-left:22px;">
        <xsl:if test="(@id!='1')">  
          <xsl:attribute name="top">Y</xsl:attribute>
        </xsl:if>
        <xsl:apply-templates select="container"/>
        <xsl:apply-templates select="image"/>
      </ul>
    </li>
    
  </xsl:template>
  <xsl:template match="container">
      <xsl:call-template name="liSubItem"/>
  </xsl:template>

  <xsl:template match="image">
        <LI class="li lileaf" isimage="true">
          <IMG class="img" WIDTH="16">
            <xsl:attribute name="SRC">images/image.png</xsl:attribute>
          </IMG>
          <A class="mnItm" id="scrollTo{@id}" ImageId="{@id}">
            <xsl:attribute name="oncontextmenu">javascript:showContextMenuImg();</xsl:attribute>
            <xsl:attribute name="HREF">?pgid=<xsl:value-of select="$pgid"/>&amp;id=<xsl:value-of select="@id"/></xsl:attribute>
            <xsl:value-of select="@name" />
          </A>
        </LI>
    <xsl:apply-templates select="container"/>
    <xsl:apply-templates select="image"/>
  </xsl:template>


</xsl:stylesheet>