<?xml version='1.0' encoding='ISO-8859-1'?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:param name="id"/>
<xsl:output method="html"/>
<xsl:template match="/">

	<xsl:apply-templates select="/directory/staff[@id=$id]" />
</xsl:template>
  <xsl:template match="staff">

    <div class="span-5 module-form-fluid-none">
      <p>
        <span style="color:red;">*</span> - Denotes a requested/mandatory field.
      </p>

      <fieldset>
        <div class="span-5 buttonrow">
          <button class="btn" type="submit" name="btnAction" value="Save">
            <div class="bImg bSave"></div>
            <span>Save</span>
          </button>
          <button class="btn" type="submit" name="btnAction" value="Cancel">
            <div class="bImg bCancel"></div>
            <span>Cancel</span>
          </button>
        <!--  <asp:button ID="TestBtn" runat="server" Text="Test button"  ></asp:button> -->

        </div>
      </fieldset>
      <fieldset>
        <legend>
          <strong>
            Properties
          </strong>
        </legend>
        <div class="span-6">
          <label class="lbl" for="id">Staff ID</label>
          <input type="Hidden" name="id" value="{$id}"/>
          <span style="position:relative;top:3px;">
            <xsl:value-of select="@id"/>
          </span>
        </div>
        <div class="span-6">
          <label class="lbl" for="l_name">
            <span style="color:red;">*</span> Last Name
          </label>
          <input type="text" class="input" id="l_name" name="l_name">
            <xsl:attribute name="value">
              <xsl:value-of select="@l_name"/>
            </xsl:attribute>
          </input>
        </div>

        <div class="span-6">
          <label class="lbl" for="f_name">
            <span style="color:red;">*</span> First Name
          </label>
          <input type="text" class="input" id="f_name" name="f_name">
            <xsl:attribute name="value">
              <xsl:value-of select="@f_name"/>
            </xsl:attribute>
          </input>
        </div>

        <div class="span-6">
          <label class="lbl" for="status">
            <span style="color:red;">*</span> Status
          </label>
          <select name="status" class="input select">
            <option value="0">
              <xsl:if test="@status=''">
                <xsl:attribute name="selected">true</xsl:attribute>
              </xsl:if>
            </option>
            <option value="1">
              <xsl:if test="@status='1'">
                <xsl:attribute name="selected">true</xsl:attribute>
              </xsl:if>1 - Current Employee
            </option>
            <option value="2">
              <xsl:if test="@status='2'">
                <xsl:attribute name="selected">true</xsl:attribute>
              </xsl:if>2 - On Leave (hidden)
            </option>
            <option value="3">
              <xsl:if test="@status='3'">
                <xsl:attribute name="selected">true</xsl:attribute>
              </xsl:if>3 - Non-Current Employee
            </option>

          </select>
        </div>

        <div class="span-6">
          <label class="lbl" for="group">
            <span style="color:red;">*</span> Group
          </label>
          <select name="group" class="input select">
            <option value="">
              <xsl:if test="@group=''">
                <xsl:attribute name="selected">true</xsl:attribute>
              </xsl:if>
            </option>
            <option value="CR">
              <xsl:if test="@group='CR'">
                <xsl:attribute name="selected">true</xsl:attribute>
              </xsl:if>CR - Clerical and Regulatory
            </option>
            <option value="AS">
              <xsl:if test="@group='AS'">
                <xsl:attribute name="selected">true</xsl:attribute>
              </xsl:if>AS - Administrative Services
            </option>
            <option value="SI">
              <xsl:if test="@group='SI'">
                <xsl:attribute name="selected">true</xsl:attribute>
              </xsl:if>SI - Economics and Social Science Services
            </option>
            <option value="LA">
              <xsl:if test="@group='LA'">
                <xsl:attribute name="selected">true</xsl:attribute>
              </xsl:if>LA - Law
            </option>
          </select>
        </div>

        <!--<div class="span-6">
          <label class="lbl">
            <span style="color:red;">*</span> Team
          </label>
          <select size="1" type="text" class="input select" onchange="selectTeam(this.value);">
            <option value=""></option>
            <option value="collections">Collections</option>
            <option value="advisory">Advisory</option>
            <option value="impt">IMPT</option>
          </select>
        </div>-->

        <div class="span-6">
          <label class="lbl" for="team_e">
            <span style="color:red;">*</span> Team (Eng)
          </label>
          <input readonly="true" type="text" class="input" id="team_e" name="team_e">
            <xsl:attribute name="value">
              <xsl:value-of select="@team_e"/>
            </xsl:attribute>
          </input>
        </div>
        <div class="span-6">
          <label class="lbl" for="team_f">
            <span style="color:red;">*</span> Team (Fre)
          </label>
          <input readonly="true" type="text" class="input" id="team_f" name="team_f">
            <xsl:attribute name="value">
              <xsl:value-of select="@team_f"/>
            </xsl:attribute>
          </input>
        </div>
        <div class="span-6">
          <label class="lbl" for="acrnm_e">
            <span style="color:red;">*</span> Acronym (Eng)
          </label>
          <input readonly="true" type="text" class="input" id="acrnm_e" name="acrnm_e">
            <xsl:attribute name="value">
              <xsl:value-of select="@acrnm_e"/>
            </xsl:attribute>
          </input>
        </div>
        <div class="span-6">
          <label class="lbl" for="acrnm_f">
            <span style="color:red;">*</span> Acronym (Fre)
          </label>
          <input readonly="true" type="text" class="input" id="acrnm_f" name="acrnm_f">
            <xsl:attribute name="value">
              <xsl:value-of select="@acrnm_f"/>
            </xsl:attribute>
          </input>
        </div>
        <div class="span-6">
          <label class="lbl" for="position_e">
            <span style="color:red;">*</span> Position (Eng)
          </label>
          <input  type="text" class="input" id="position_e" name="position_e">
            <xsl:attribute name="value">
              <xsl:value-of select="@position_e"/>
            </xsl:attribute>
          </input>
        </div>
        <div class="span-6">
          <label class="lbl" for="position_f">
            <span style="color:red;">*</span> Position (Fre)
          </label>
          <input  type="text" class="input" id="position_f" name="position_f">
            <xsl:attribute name="value">
              <xsl:value-of select="@position_f"/>
            </xsl:attribute>
          </input>
        </div>
        <div class="span-6">
          <label class="lbl" for="phone_area_code">Telephone</label>
          <input type="text" class="input" maxlength="3" style="width:30px;margin-right:3px;" id="phone_area_code" name="phone_area_code">
            <xsl:attribute name="value">
              <xsl:value-of select="@phone_area_code"/>
            </xsl:attribute>
          </input>
          <input type="text" class="input" maxlength="3" style="width:30px;margin-right:3px;" id="phone_3" name="phone_3">
            <xsl:attribute name="value">
              <xsl:value-of select="@phone_3"/>
            </xsl:attribute>
          </input>
          <input type="text" class="input" maxlength="4" id="phone_4" name="phone_4" style="width:40px;">
            <xsl:attribute name="value">
              <xsl:value-of select="@phone_4"/>
            </xsl:attribute>
          </input>
        </div>
        <div class="span-6">
          <label class="lbl" for="intercom">Intercom</label>
          <input type="text" class="input" style="width:71px;" id="intercom" name="intercom">
            <xsl:attribute name="value">
              <xsl:value-of select="@intercom"/>
            </xsl:attribute>
          </input>
        </div>
        <div class="span-6">
          <label class="lbl" for="cell_area_code">Cell Phone</label>
          <input type="text" class="input" maxlength="3" style="width:30px;margin-right:3px;" id="cell_area_code" name="cell_area_code">
            <xsl:attribute name="value">
              <xsl:value-of select="@cell_area_code"/>
            </xsl:attribute>
          </input>
          <input type="text" class="input" maxlength="3" style="width:30px;margin-right:3px;" id="cell_3" name="cell_3">
            <xsl:attribute name="value">
              <xsl:value-of select="@cell_3"/>
            </xsl:attribute>
          </input>
          <input type="text" class="input" maxlength="4" id="cell_4" name="cell_4" style="width:40px;">
            <xsl:attribute name="value">
              <xsl:value-of select="@cell_4"/>
            </xsl:attribute>
          </input>
        </div>
        <div class="span-6">
          <label class="lbl" for="craUserName" title="Windows Logon User Name">
            <span style="color:red;">*</span> Logon User Name
          </label>
          <input type="text" class="input"  id="craUserName" name="craUserName">
            <xsl:attribute name="value">
              <xsl:value-of select="@craUserName"/>
            </xsl:attribute>
          </input>
        </div>
        <div class="span-6">
          <label class="lbl" for="email">
            <span style="color:red;">*</span> E-mail Address
          </label>
          <input type="text" class="input"  id="email" name="email">
            <xsl:attribute name="value">
              <xsl:value-of select="@email"/>
            </xsl:attribute>
          </input>
        </div>
        <div class="span-6">
          <label class="lbl" for="dojEmail">DOJ E-mail</label>
          <input type="text" class="input"  id="dojEmail" name="dojEmail">
            <xsl:attribute name="value">
              <xsl:value-of select="@dojEmail"/>
            </xsl:attribute>
          </input>
        </div>
        <div class="span-6">
          <label class="lbl" for="assistant">
            <a href="javascript:loadAssistants();">Assistant</a>
          </label>
          <input type="text" readonly="true" class="input" id="assistant" name="assistant">
            <xsl:attribute name="value">
              <xsl:call-template name="findAssistant"/>
            </xsl:attribute>
          </input>
          <img onclick="clearAssistantValue();" alt="Remove Assistant" style="cursor:hand;margin-left:3px;margin-top:6px;" src="images/delete.png"/>
          <input type="text" class="input" style="display:none;" id="assistant_id" name="assistant_id">
            <xsl:attribute name="value">
              <xsl:value-of select="@assistant_id"/>
            </xsl:attribute>
          </input>
        </div>
        <div class="span-6">
          <label class="lbl" for="imageDate">Image Date</label>
          <input type="text" class="input"  id="imageDate" name="imageDate" style="width:140px">
            <xsl:attribute name="value">
              <xsl:value-of select="@imageDate"/>
            </xsl:attribute>
          </input>
          <span style="font-size:0.9em;position:relative;top:4px;left:4px;">(yyyy/mm/dd) - Last known date</span>
        </div>
        <div class="span-6">
          <label class="lbl" for="EfilerAccess">E-Filer Access</label>
          <select name="EfilerAccess" class="input select">
            <option value="">
              <xsl:if test="@EfilerAccess=''">
                <xsl:attribute name="selected">true</xsl:attribute>
              </xsl:if>
            </option>
            <option value="0">
              <xsl:if test="@EfilerAccess='0'">
                <xsl:attribute name="selected">true</xsl:attribute>
              </xsl:if>0 - No Prompt
            </option>
            <option value="1">
              <xsl:if test="@EfilerAccess='1'">
                <xsl:attribute name="selected">true</xsl:attribute>
              </xsl:if>1 - Sender and Recipient
            </option>
            <option value="2">
              <xsl:if test="@EfilerAccess='2'">
                <xsl:attribute name="selected">true</xsl:attribute>
              </xsl:if>2 - Sender, Recipient and Subject
            </option>
            <option value="3">
              <xsl:if test="@EfilerAccess='3'">
                <xsl:attribute name="selected">true</xsl:attribute>
              </xsl:if>3 - Sender, Recipient, Subject and Other Codes
            </option>
          </select>
        </div>
        <div class="span-6">
          <label class="lbl" for="quicklawAccount">Quicklaw ID</label>
          <input type="text" class="input"  id="quicklawAccount" name="quicklawAccount">
            <xsl:attribute name="value">
              <xsl:value-of select="@quicklawAccount"/>
            </xsl:attribute>
          </input>
        </div>
        <div class="span-6">
          <label class="lbl" for="notes">Notes</label>
          <textarea class="input" name="notes" id="notes" rows="5">
            <xsl:value-of select="@notes"/>
          </textarea>
        </div>
      </fieldset>
      <fieldset>
        <legend>
          <strong>
            Other
          </strong>
        </legend>
        <div class="span-6">
          <label class="lbl" for="isAssistant">List as assistant:</label>
          <select name="isAssistant" class="input select">
            <option value="0">
              <xsl:if test="@isAssistant='0'">
                <xsl:attribute name="selected">true</xsl:attribute>
              </xsl:if>No
            </option>
            <option value="1">
              <xsl:if test="@isAssistant='1'">
                <xsl:attribute name="selected">true</xsl:attribute>
              </xsl:if>Yes
            </option>
          </select>
        </div>
        <div class="span-6">
          <label class="lbl" for="isDLSUCoach">List as DLSU Coach:</label>
          <select name="isDLSUCoach" class="input select">
            <option value="0">
              <xsl:if test="@isDLSUCoach='0'">
                <xsl:attribute name="selected">true</xsl:attribute>
              </xsl:if>No
            </option>
            <option value="1">
              <xsl:if test="@isDLSUCoach='1'">
                <xsl:attribute name="selected">true</xsl:attribute>
              </xsl:if>Yes
            </option>
          </select>
        </div>
        <div class="span-6">
          <label class="lbl" for="hasPaperlessDummyAccount">Paperless Office Dummy Account:</label>
          <select name="hasPaperlessDummyAccount" class="input select">
            <option value="0">
              <xsl:if test="@hasPaperlessDummyAccount='0'">
                <xsl:attribute name="selected">true</xsl:attribute>
              </xsl:if>No
            </option>
            <option value="1">
              <xsl:if test="@hasPaperlessDummyAccount='1'">
                <xsl:attribute name="selected">true</xsl:attribute>
              </xsl:if>Yes
            </option>
          </select>
        </div>
      </fieldset>
      <xsl:if test="@group='LA'">
        <fieldset>
          <legend>
            <strong>
              Service Teams
            </strong>
          </legend>

          <div class="span-6">
            <a name="group"></a>
            <div style="border:1px solid #ffffa0;width:545px;padding:4px;background-color:#ffffe0;font-size:85%">
              <img align="left" style="margin-top:8px;padding-right:14px;" alt="Service Team Note" src="content_manager/images/tripup.gif"/> <strong>Service Team Note</strong>:  Removing or adding service teams will perform a page submit.  Any changes made to other fields will be lost.  Ensure that all required data changes for this record are saved before making changes to the Service Team section.
            </div>
            <div class="buttonrow" style="margin:3px 0px 10px -6px;">
              <button class="btn" type="button" onclick="loadGroups('{@id}');">
                <div class="bImg bNewGroup"></div>
                <span>Add New Service Team</span>
              </button>
            </div>
            <table id="adminTbl" cellpadding="0" cellspacing="0">
              <xsl:for-each select="group">
                <tr valign="top" onmouseover="this.style.color='#6600ff';" onmouseout="this.style.color='black';">
                  <xsl:if test="position() mod 2 = 0">
                    <xsl:attribute name="style">background-color:#f0f0f0;</xsl:attribute>
                  </xsl:if>
                  <td nowrap="true" width="300">
                    <xsl:value-of select="@name_e"/>
                  </td>
                  <td align="right">
                    <a title="Remove {../@f_name} {../@l_name} from the {@name_e} service team" href="javascript:removeGroup('{@id}','{../@id}');">
                      <img src="content_manager/images/delete.png"/>
                    </a>
                  </td>
                </tr>
              </xsl:for-each>
            </table>
          </div>
        
      </fieldset>
      </xsl:if>
    </div>
  </xsl:template>

<xsl:template name="findAssistant">
	<xsl:if test="@assistant_id!=''">
		<xsl:value-of select="../staff[@id=../staff[@id=$id]/@assistant_id]/@l_name"/>, <xsl:value-of select="../staff[@id=../staff[@id=$id]/@assistant_id]/@f_name"/>
	</xsl:if>
</xsl:template>
</xsl:stylesheet>