<?xml version="1.0"?>

<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:param name="pgid"/>
<xsl:param name="highlightNode"/>
<xsl:output method="html"/>

<xsl:template match="/">
<xsl:apply-templates />
</xsl:template>
<xsl:template match="item">
  <p>test</p>
</xsl:template>

</xsl:stylesheet>