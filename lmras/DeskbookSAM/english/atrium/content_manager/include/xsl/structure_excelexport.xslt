<?xml version="1.0" encoding="utf-8"?>
<?mso-application progid="Excel.Sheet"?>
<xsl:stylesheet version="1.0"
xmlns:html="http://www.w3.org/TR/REC-html40"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns="urn:schemas-microsoft-com:office:spreadsheet"
    xmlns:o="urn:schemas-microsoft-com:office:office"
    xmlns:x="urn:schemas-microsoft-com:office:excel"
    xmlns:ss="urn:schemas-microsoft-com:office:spreadsheet">

  <xsl:template match="/">

    <Workbook>
      <Styles>
        <Style ss:ID="Default" ss:Name="Normal">
          <Alignment ss:Vertical="Bottom" />
          <Borders />
          <Font />
          <Interior />
          <NumberFormat />
          <Protection />
        </Style>
        <Style ss:ID="s21">
          <Font ss:Size="22" ss:Bold="1" />
        </Style>
        <Style ss:ID="s22">
          <Font ss:Size="14" ss:Bold="1" />
        </Style>
        <Style ss:ID="s23">
          <Font ss:Size="12" ss:Bold="1" />
        </Style>
        <Style ss:ID="s24">
          <Font ss:Size="10" ss:Bold="1" />
        </Style>
      </Styles>

      <Worksheet ss:Name="Page1">
        <Table>
          <xsl:call-template name="XMLToXSL" />
        </Table>
      </Worksheet>
    </Workbook>

  </xsl:template>

  <xsl:template name="XMLToXSL">

    <Row>
      <Cell>
        <Data ss:Type="String">PageID</Data>
      </Cell>
      <Cell>
        <Data ss:Type="String">PageName(Eng)</Data>
      </Cell>
      <Cell>
        <Data ss:Type="String">Principal Process</Data>
      </Cell>
      <Cell>
        <Data ss:Type="String">Translate To</Data>
      </Cell>
      <Cell>
        <Data ss:Type="String">Translation Process</Data>
      </Cell>
      <Cell>
        <Data ss:Type="String">Responsibility</Data>
      </Cell>
      <Cell>
        <Data ss:Type="String">Due Date</Data>
      </Cell>
      <Cell>
        <Data ss:Type="String">File Number</Data>
      </Cell>
      <Cell>
        <Data ss:Type="String">Comment</Data>
      </Cell>
    </Row>
    <xsl:for-each
        select="//item[@orphan='false']">
      <Row>
        <Cell>
          <Data ss:Type="String">
            <xsl:value-of select="@id"/>
          </Data>
        </Cell>
        <Cell>
          <Data ss:Type="String">
            <xsl:value-of select="@eng" />
          </Data>
        </Cell>
        <Cell>
          <Data ss:Type="String">
            <xsl:if test="@process='1'">1. Planning</xsl:if>
            <xsl:if test="@process='2'">2. Content Development</xsl:if>
            <xsl:if test="@process='3'">3. Perform Quality Control</xsl:if>
            <xsl:if test="@process='4'">4. Approve Content</xsl:if>
            <xsl:if test="@process='5'">5. Publish Content</xsl:if>
            <xsl:if test="@process='6'">6. Content Published</xsl:if>
          </Data>
        </Cell>
        <Cell>
          <Data ss:Type="String">
            <xsl:if test="@translateTo='french'">French/français</xsl:if>
            <xsl:if test="@translateTo='english'">English/anglais</xsl:if>
          </Data>
        </Cell>
        <Cell>
          <Data ss:Type="String">
            <xsl:if test="@translationProcess='1'">1. Not Started</xsl:if>
            <xsl:if test="@translationProcess='2'">2. In Translation</xsl:if>
            <xsl:if test="@translationProcess='3'">3. Review Translation</xsl:if>
            <xsl:if test="@translationProcess='4'">4. Approve Translation</xsl:if>
            <xsl:if test="@translationProcess='5'">5. Publish Translation</xsl:if>
            <xsl:if test="@translationProcess='6'">6. Translation Published</xsl:if>
          </Data>
        </Cell>
        <Cell>
          <Data ss:Type="String">
          
              <xsl:value-of select="@responsability"/>
          
          </Data>
        </Cell>
        <Cell>
          <Data ss:Type="String">
          
              <xsl:value-of select="@dateAssigned"/>
          
          </Data>
        </Cell>
        <Cell>
          <Data ss:Type="String">
          
              <xsl:value-of select="@fileNumber"/>
          
          </Data>
        </Cell>
        <Cell>
          <Data ss:Type="String">
            <xsl:value-of select="@comment"/>
          </Data>
        </Cell>
      </Row>
    </xsl:for-each>
  </xsl:template>
  <xsl:template match="MT_TEST_IN">
  </xsl:template>
</xsl:stylesheet>