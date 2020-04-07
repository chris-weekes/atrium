var refreshHit=false;
var CurrentCutItem;
var CurrentContextMenuAnchor;

document.onkeyup = function () {
    var f5Key = 116;
    if (f5Key == event.keyCode) {
        window.status = 'F5 (Refresh) is disabled.';
        alert("It is not recommended to refresh the application's web pages through the use of the F5 key.\n\nThis function has been disabled.  Use the application's functions to navigate.");
        event.keyCode = 0;
        event.returnValue = false;
    }
    var escapeKey = 27;
    try {
        if (escapeKey == event.keyCode) {
            var ItemCleared = false;
            if (CurrentCutItem != null) {
                CurrentCutItem.style.textDecoration = "none";
                CurrentCutItem.style.fontStyle = "";
                contextMenu.children["PasteItem"].disabled = true;
                contextMenu.children["PasteItem"].className = "menAncDisabled";
                contextMenu.children["PasteItem"].innerHTML = '<img src="images/paste.png" border="0" alt="" height="16" width="16" style="margin-right:12px;vertical-align:middle;"/>Paste as Child';

                //Added Kevin Hamilton Oct 2014
                contextMenu.children["PasteBrotherItem"].disabled = true;
                contextMenu.children["PasteBrotherItem"].className = "menAncDisabled";
                contextMenu.children["PasteBrotherItem"].innerHTML = '<img src="images/paste.png" border="0" alt="" height="16" width="16" style="margin-right:12px;vertical-align:middle;"/>Paste as Sibiling';
                
                try {
                    document.all.pasteItemToRootBtn.itemid = "";
                    document.all.pasteItemToRootBtn.style.display = "none";



                }
                catch (e) {

                }

                ItemCleared = true;
                CurrentCutItem = null;
            }

            if (ItemCleared)
                alert('Cut item has been cleared.');
        }
    }
    catch (e) {
        alert();
    }
}

function taWrapText(elmt, val) {
    if (val.curVal == 'on') {
        val.className = "tlbrBtnToggleOn";
        val.curVal = 'off';
        resizeTA(elmt, 'soft');
    }
    else {
        val.className = "toolbarBtn";
        val.curVal = 'on';
        resizeTA(elmt, 'off');
    }
}


function tbExpand(img, textarea, span) {

    if (span.style.display == 'none') {
        img.src = 'images/minus.gif';
        event.srcElement.parentElement.className = 'toolbarTitle';
        span.style.display = '';
    }
    else {
        img.src = 'images/plus.gif';
        event.srcElement.parentElement.className = 'toolbarTitle2';
        span.style.display = 'none';
    }
    $(textarea).slideToggle('slow');
}

function tbExpand2(img, textarea, span) {
    if (span.style.display == 'none') {
        img.src = 'content_manager/images/minus.gif';
        span.style.display = '';
        event.srcElement.parentElement.className = 'toolbarTitle';
    }
    else {
        img.src = 'content_manager/images/plus.gif';
        span.style.display = 'none';
        event.srcElement.parentElement.className = 'toolbarTitle2';
    }
    $(textarea).slideToggle('slow');
}

function toolbarRaise(img) {
    if (img.className != 'tlbrBtnToggleOn') {
        img.className = 'tlbrBtnHover';
		img.title = img.alt;
    }
}

function toolbarOff(img) {
    if (img.className != 'tlbrBtnToggleOn') {
        img.className = 'toolbarBtn';
    }
}

function toolbarToggle(img) {
    if (img.className == 'tlbrBtnToggleOn') {
        img.className = "toolbarBtn";
        return "off";
    }
    else {
        img.className = "tlbrBtnToggleOn";
        return "on";
    }

}

var editMade=false;
function taTextChanged(topDiv, editFlag) {
    topDiv.className = 'divEdit2';
    event.srcElement.style.border = '1px solid black';
    //document.all.btnEditorSave.disabled = false;
    //editFlag.style.display = 'block';
    editMade=true;
}

function resetTA(topDiv, editFlag) {
    topDiv.className = 'divEdit';
    event.srcElement.style.border = '1px solid #999';
    //document.all.btnEditorSave.disabled = true;
    editFlag.style.display = 'none';
    editMade = false;
}

function taTextChanged2(topDiv, editFlag) {
    topDiv.className = 'divEdit2';
    event.srcElement.style.border = '1px solid black';
    //document.all.btnEditorSave.disabled = false;
    //editFlag.style.display = 'block';
    editMade = true;
}

function verifyEdit(url) {
    if (editMade) {
        if (confirm("Page is in EDIT MODE. \n\nPress OK to continue WITHOUT SAVING, or Cancel to return to the page and select SAVE to save changes.")) {
            window.location.href=url;
        }
    }
    else
        window.location.href = url;

}
function confirmDelete(whichObject) {
    if (whichObject == 'trackerItem') {
        if (confirm("Help Desk Item\n\nAre you sure you want to delete this help desk entry?")) {
            return true;
        }
        else {
            return false;
        }
    }

    if (whichObject == 'directory') {
        if (confirm("Profile: " + document.forms.aspnetForm.f_name.value + " " + document.forms.aspnetForm.l_name.value + "\n\nAre you sure you want to delete this profile?")) {
            return true;
        }
        else {
            return false;
        }
    }
    if (whichObject == 'acronym') {
        if (confirm("Acronym: " + document.forms.aspnetForm.english.value + " - " + document.forms.aspnetForm.desc_e.value + "\n\nAre you sure you want to delete this acronym?")) {
            return true;
        }
        else {
            return false;
        }
    }
    if (whichObject == 'menu') {
        if (confirm("------------------------WARNING------------------------\n\n You are about to delete the following menu item:\n\n " + document.frmEditMenu.eng.value + " \n\nIf you choose OK, all menu items nested inside this item will be deleted as well.\n\nAre you sure you want to delete this menu item?")) {
            return true;
        }
        else {
            return false;
        }
    }
    if (whichObject == 'group') {
        if (confirm("------------------------WARNING------------------------\n\n You are about to delete the following group:\n\n " + document.frmEditMenu.name_e.value + " \n\nIf you choose OK, the group along with the webpage will be deleted.\n\nAre you sure you want to delete this group?")) {
            return true;
        }
        else {
            return false;
        }
    }
    if (whichObject == 'project') {
        if (confirm("------------------------WARNING------------------------\n\n You are about to delete the following project:\n\n " + document.frmEditMenu.name.value + " \n\nIf you choose OK, the project along with its attached releases and their related items will be deleted.\n\nAre you sure you want to delete this project?")) {
            return true;
        }
        else {
            return false;
        }
    }
    if (whichObject == 'release') {
        if (confirm("------------------------WARNING------------------------\n\n You are about to delete the following release:\n\n " + document.frmEditMenu.title.value + " \n\nIf you choose OK, the release along with its related items will be deleted.\n\nAre you sure you want to delete this release?")) {
            return true;
        }
        else {
            return false;
        }
    }
    if (whichObject == 'releaseItem') {
        if (confirm("------------------------WARNING------------------------\n\n You are about to delete the following item:\n\n \"" + document.frmEditMenu.description.value + "\"\n\nAre you sure you want to delete this item?")) {
            return true;
        }
        else {
            return false;
        }
    }

}

function taExtend(textarea, img)
{
    if (toolbarToggle(img) == 'on') {
	switch (textarea) {
            case document.frmEditMenu.pgCSS:
                textarea.style.height = '400px';
                break;
            case document.frmEditMenu.stream:
                textarea.style.height = '600px';
                break;
            case oPreview:
                textarea.style.height = '600px';
                break;
        }
    }
    else {
        switch (textarea) {
            case document.frmEditMenu.pgCSS:
                textarea.style.height = '80px';
                break;
            case document.frmEditMenu.stream:
                textarea.style.height = '280px';
                break;
            case oPreview:
                textarea.style.height = '250px';
                break;
        }
    }
 }

function updateFontSize(img, textarea) {
    if (toolbarToggle(img)=='off')
        textarea.style.fontSize = "1em";
    else
        textarea.style.fontSize = "1.3em";
        
}
function setbg(color) {
    document.getElementById("styled").style.background = color
}

function nTypeChange(elmValue) {
    switch (elmValue) {
        case "node":

            break;
        case "nodeleaf":

            break;
        case "leaf":

            break;
    }
 }
function showImage(imgToShow)
{
  
 		 if(document.all.imgDivContainer.hasChildNodes)
		 {
		  	var children = document.all.imgDivContainer.childNodes;

			for(var c=0; c < children.length; c++) 
			{
			    children[c].style.display='none';
			}
		  }


 document.getElementById(imgToShow).style.display="";
}


function format_sel(v) 
{
 switch (v)
 {
 	case "p":
	case "strong":
	case "em":
	case "h1":
	case "h2":
	case "h3":
	case "li":
	 	var str = document.selection.createRange().text;
		document.frmEditMenu.stream.focus();
		var sel = document.selection.createRange();
		sel.text = "<" + v + ">" + str + "</" + v + ">";
		return;
	 	break;
	case "br":
		document.frmEditMenu.stream.focus();
		var sel = document.selection.createRange();
		sel.text = "<br/>"
		break;
 	case "space":
		document.frmEditMenu.stream.focus();
		var sel = document.selection.createRange();
		sel.text = "&nbsp;"
		break;
	case "img":
		var rValue=window.showModalDialog("SAMImageSelector.aspx","", "dialogHeight: 700px; dialogWidth: 840px; edge: Raised; center: Yes; help: No; resizable: Yes; status: No;");
		if(rValue!='' || rValue!="undefined" || rValue!='cancel')
		{
			document.frmEditMenu.stream.focus();
			var sel = document.selection.createRange();
			sel.text = rValue;
		}
		break;
	case "table":
	case "ol":
	case "ul":
	case "a":
		var obj = new Object();
    	obj.tag = v;
    	var rValue = window.showModalDialog("SAMEditorSelector.aspx", obj, "dialogHeight: 380px; dialogWidth: 530px; edge: Raised; center: Yes; help: No; resizable: No; status: No;");
		if(rValue=='cancel' || rValue==undefined || rValue=='')
		{
			document.frmEditMenu.stream.focus();
			return;
		}
		document.frmEditMenu.stream.focus()
			if(v!='a') 
			{
				var sel = document.selection.createRange();
				if(sel.text=='')
				{
					sel.text=rValue;
				}
				else
				{
					sel.text=rValue+"\n"+sel.text;
				}
				document.frmEditMenu.stream.focus();
			}
			else
			{
				var str = document.selection.createRange().text;
				document.frmEditMenu.stream.focus();
				var sel = document.selection.createRange();
				sel.text = rValue + str + "</" + v + ">";
				return;
			}
		break;
	case "pgid":
	    var rValue = window.showModalDialog("SAMPageSelector.aspx", "", "dialogHeight: 600px; dialogWidth: 840px; edge: Raised; center: Yes; help: No; resizable: Yes; status: No;");
		if(rValue=='cancel' || rValue==undefined || rValue=='')
		{
			document.frmEditMenu.stream.focus();
			return;
		}
		document.frmEditMenu.stream.focus()
		var str = document.selection.createRange().text;
		document.frmEditMenu.stream.focus();
		var sel = document.selection.createRange();
		sel.text = rValue + str + "</a>";
		return;
		break;	
	} 
}

function removeGroup(groupid, empid) {
    var rValue = window.showModalDialog("content_manager_pages/sam_directory_group_selector.asp?op=delete&groupid=" + groupid + "&empid=" + empid, "", "dialogHeight: 180px; dialogWidth: 430px; edge: Raised; center: Yes; help: No; resizable: No; status: No;");
    if (rValue == 'cancel') {
        return;
    }
    else if (rValue == 'yes') {
        window.setTimeout("reloadDirectory()", 1000);
    }
}


function charChecker() {
    rrep = "";
    vMadeChanges = false;

    fEaigu = false;
    fEMajaigu = false;
    fEgrave = false;
    fEMajgrave = false;
    fEcircon = false;
    fEMajcircon = false;
    fEtrema = false;
    fEMajtrema = false;
    fAgrave = false;
    fAMajgrave = false;
    fItrema = false;
    fIMajtrema = false;
    fOcirco = false;
    fOMajcirco = false;
    fUgrave = false;
    fUMajgrave = false;
    fCcedille = false;
    fCMajcedille = false;
    fAmpersand = false;

    for (var i = 0; i < document.all.stream.value.length; i++) {

        var rrep = document.all.stream.value;

        if (document.all.stream.value.charAt(i) == "&" && document.all.stream.value.charAt(i - 1) == " " && document.all.stream.value.charAt(i + 1) == " " && !fAmpersand) {
            regAmp = /( )&( )/;
            rrep = rrep.replace(regAmp, " &amp; ");
            fAmpersand = true;
            vMadeChanges = true;
        }
        if (document.all.stream.value.charAt(i) == "é" && !fEaigu) {
            regé = /é/g;
            rrep = rrep.replace(regé, "&eacute;");
            fEaigu = true;
            vMadeChanges = true;
        }
        if (document.all.stream.value.charAt(i) == "É" && !fEMajaigu) {
            reÉ = /É/g;
            rrep = rrep.replace(reÉ, "&Eacute;");
            fEMajaigu = true;
            vMadeChanges = true;
        }
        if (document.all.stream.value.charAt(i) == "è" && !fEgrave) {
            regè = /è/g;
            rrep = rrep.replace(regè, "&egrave;");
            fEgrave = true;
            vMadeChanges = true;
        }
        if (document.all.stream.value.charAt(i) == "È" && !fEMajgrave) {
            regÈ = /È/g;
            rrep = rrep.replace(regÈ, "&Egrave;");
            fEMajgrave = true;
            vMadeChanges = true;
        }
        if (document.all.stream.value.charAt(i) == "ê" && !fEcircon) {
            regê = /ê/g;
            rrep = rrep.replace(regê, "&ecirc;");
            fEcircon = true;
            vMadeChanges = true;
        }
        if (document.all.stream.value.charAt(i) == "Ê" && !fEMajcircon) {
            regÊ = /Ê/g;
            rrep = rrep.replace(regÊ, "&Ecirc;");
            fEMajcircon = true;
            vMadeChanges = true;
        }
        if (document.all.stream.value.charAt(i) == "ë" && !fEtrema) {
            regë = /ë/g;
            rrep = rrep.replace(regë, "&euml;");
            fEtrema = true;
            vMadeChanges = true;
        }
        if (document.all.stream.value.charAt(i) == "Ë" && !fEMajcircon) {
            regË = /Ë/g;
            rrep = rrep.replace(regË, "&Euml;");
            fEMajtrema = true;
            vMadeChanges = true;
        }
        if (document.all.stream.value.charAt(i) == "à" && !fAgrave) {
            regà = /à/g;
            rrep = rrep.replace(regà, "&agrave;");
            fAgrave = true;
            vMadeChanges = true;
        }
        if (document.all.stream.value.charAt(i) == "À" && !fAMajgrave) {
            regÀ = /À/g;
            rrep = rrep.replace(regÀ, "&Agrave;");
            fAMajgrave = true;
            vMadeChanges = true;
        }
        if (document.all.stream.value.charAt(i) == "ï" && !fItrema) {
            regï = /ï/g;
            rrep = rrep.replace(regï, "&iuml;");
            fItrema = true;
            vMadeChanges = true;
        }
        if (document.all.stream.value.charAt(i) == "Ï" && !fIMajtrema) {
            regÏ = /Ï/g;
            rrep = rrep.replace(regÏ, "&Iuml;");
            fIMajtrema = true;
            vMadeChanges = true;
        }
        if (document.all.stream.value.charAt(i) == "ô" && !fOcirco) {
            regô = /ô/g;
            rrep = rrep.replace(regô, "&ocirc;");
            fOcirco = true;
            vMadeChanges = true;
        }
        if (document.all.stream.value.charAt(i) == "Ô" && !fOMajcirco) {
            regÔ = /Ô/g;
            rrep = rrep.replace(regÔ, "&Ocirc;");
            fOMajcirco = true;
            vMadeChanges = true;
        }
        if (document.all.stream.value.charAt(i) == "ù" && !fUgrave) {
            regù = /ù/g;
            rrep = rrep.replace(regù, "&ugrave;");
            fUgrave = true;
            vMadeChanges = true;
        }
        if (document.all.stream.value.charAt(i) == "Ù" && !fUMajgrave) {
            regÙ = /Ù/g;
            rrep = rrep.replace(regÙ, "&Ugrave;");
            fUMajgrave = true;
            vMadeChanges = true;
        }
        if (document.all.stream.value.charAt(i) == "ç" && !fCcedille) {
            regç = /ç/g;
            rrep = rrep.replace(regç, "&ccedil;");
            fCcedille = true;
            vMadeChanges = true;
        }
        if (document.all.stream.value.charAt(i) == "Ç" && !fCMajcedille) {
            regÇ = /Ç/g;
            rrep = rrep.replace(regÇ, "&Ccedil;");
            fCMajcedille = true;
            vMadeChanges = true;
        }


        document.all.stream.value = rrep;
    }
    if (vMadeChanges) {
        document.all.stream.value = rrep;
        alert('Character checker has made updates and is now completed.\n\nYou must save in order to keep the changes.');
    }
    else
        alert('No special characters were found. \n\nNo changes were made.');


}

function loadAssistants() {
    var obj = new Object();
    obj.officer = document.frmEditMenu.f_name.value + " " + document.frmEditMenu.l_name.value;
    var rValue = window.showModalDialog("content_manager_pages/sam_directory_assistant_selector.asp", obj, "dialogHeight: 450px; dialogWidth: 420px; edge: Raised; center: Yes; help: No; resizable: No; status: No;");
    if (rValue != 'cancel') {
        if (rValue == 'setToBlank') {
            clearAssistantValue();
        }
        else {
            document.frmEditMenu.assistant.value = rValue.substring(6, 100);
            document.frmEditMenu.assistant_id.value = rValue.substring(0, 5);
        }
    }
}
function clearAssistantValue() {
    document.frmEditMenu.assistant.value = "";
    document.frmEditMenu.assistant_id.value = "";
}

function loadGroups(empid) {
    var rValue = window.showModalDialog("/content_manager_pages/sam_directory_group_selector.asp?op=add&empid=" + empid, "", "dialogHeight: 580px; dialogWidth: 420px; edge: Raised; center: Yes; help: No; resizable: No; status: No;");
    if (rValue == 'cancel') {
        return;
    }
    else if (rValue == '') {
        window.setTimeout("reloadDirectory()", 1000);
    }
}
function reloadDirectory() {
    window.location.reload();
}

function resetImgUpload() {
    try {
        document.all.oNoFileSelected.style.display = 'none';
    }
    catch (e)
	{ } 
}

function clearAll()
{
	try
	{
		document.all.contextMenu.style.display="none";
		var tocLinks=document.all.tags("a");
		for(i=0;i<tocLinks.length;i++)
		{
			if(tocLinks[i].className=="contextHighlight")
			{
				tocLinks[i].className="";
			}
		}
	}
	catch(e)
	{}
	
}
function editorPrev()
{
	var obj = new Object();
    obj.contents = document.frmEditMenu.stream.value;

	//alert(textAreaContents);
	var rValue=window.showModalDialog("mcm_content_editor_preview.asp",obj, "dialogHeight: 435px; dialogWidth: 700px; edge: Raised; center: Yes; help: No; resizable: Yes; status: No;");
}

function CutTreeViewItem()
{
	if(CurrentCutItem!=null)
		CurrentCutItem.style.textDecoration="none";
		
	
	var colAnc=document.all.tags("a");
	for(i=0;i<colAnc.length;i++)
	{
	    if (colAnc[i].getAttribute("data-itemid") ==document.all.contextMenu.srcId)
			CurrentCutItem=colAnc[i];
	}
    
	CurrentCutItem.style.textDecoration="line-through";
	alert(CurrentCutItem.getAttribute('data-itemid'));

	contextMenu.children["PasteItem"].disabled=false;
	contextMenu.children["PasteItem"].className="menAnc";
	contextMenu.children["PasteItem"].innerHTML = '<img src="images/paste.png" border="0" alt="" height="16" width="16" style="margin-right:12px;vertical-align:middle;"/>Paste as Child ';
	contextMenu.children["PasteItem"].id = CurrentCutItem.getAttribute("data-itemid");

	contextMenu.children["PasteBrotherItem"].disabled = false;
	contextMenu.children["PasteBrotherItem"].className = "menAnc";
	contextMenu.children["PasteBrotherItem"].innerHTML = '<img src="images/paste.png" border="0" alt="" height="16" width="16" style="margin-right:12px;vertical-align:middle;"/>Paste as Sibiling ';
	contextMenu.children["PasteBrotherItem"].id = CurrentCutItem.getAttribute("data-itemid");

	
	document.all.pasteItemToRootBtn.itemid=CurrentCutItem.ItemId;
	document.all.pasteItemToRootBtn.style.display="";
}

function CutContainer() {
    if (CurrentCutItem != null)
        CurrentCutItem.style.textDecoration = "none";
    CurrentCutItem = null;

    var colAnc = document.all.tags("a");
    //loop through containers
    for (i = 0; i < colAnc.length; i++) {
        if (colAnc[i].ContainerId == document.all.contextMenu.srcId) {
            CurrentCutItem = colAnc[i];
            CurrentCutItem.itemType = "Container";
            CurrentCutItem.SourceId = CurrentCutItem.ContainerId;
        }
    }
    //if no container, loop through images
    if (CurrentCutItem == null) {
        for (i = 0; i < colAnc.length; i++) {
            if (colAnc[i].ImageId == document.all.contextMenu.srcId) {
                CurrentCutItem = colAnc[i];
                CurrentCutItem.itemType = "Image";
                CurrentCutItem.SourceId = CurrentCutItem.ImageId;
                
            }
        }
    }
    
    CurrentCutItem.style.textDecoration = "line-through";

    contextMenu.children["PasteItem"].disabled = false;
    contextMenu.children["PasteItem"].className = "menAnc";
    contextMenu.children["PasteItem"].innerHTML = '<img src="images/paste.png" border="0" alt="" height="16" width="16" style="margin-right:12px;vertical-align:middle;"/>Paste as Child';
    contextMenu.children["PasteItem"].id = CurrentCutItem.SourceId;

    contextMenu.children["PasteBrotherItem"].disabled = false;
    contextMenu.children["PasteBrotherItem"].className = "menAnc";
    contextMenu.children["PasteBrotherItem"].innerHTML = '<img src="images/paste.png" border="0" alt="" height="16" width="16" style="margin-right:12px;vertical-align:middle;"/>Paste as Sibling';
    contextMenu.children["PasteBrotherItem"].id = CurrentCutItem.SourceId;
    

    document.all.pasteItemToRootBtn.itemid = CurrentCutItem.SourceId;
    document.all.pasteItemToRootBtn.style.display = "";
}
//new, added Nov2014
function showListContextMenu(vLevel) {
    var aMenu = document.all.contextMenu;
    var menuItemCount = aMenu.children.length;

    aMenu.children["editOpen"].className = "menAnc";
    aMenu.children["editOpen"].disabled = false;

   

    src = event.srcElement;
    aMenu.srcId = src.getAttribute("data-itemid");


    clearAll();

    var ow = aMenu.style.width.substr(0, aMenu.style.width.length - 2); // width of menu
    var oh = 20 *( menuItemCount + 4);										// height of menu - each item 20 pixels high + 2 for top & bottom border
    var aw = document.body.clientWidth - ow;							// doc width minus menu width
    var ah = document.body.clientHeight - oh;							// doc height minus menu height


    if (event.clientX < aw) {
        aMenu.style.posLeft = event.offsetX + 70;
    }
    else {
        if (event.clientX - ow < 0) {
            aMenu.style.posLeft = aw - 18;
        }
        else {
            aMenu.style.posLeft = event.clientX - ow;
        }
    }

    if (event.offsetY < ah) {
        aMenu.style.posTop = mouseY(event) - oh;
    }
    else {
        if (event.offsetY - oh < 0) {
            aMenu.style.posTop = 4;
        }
        else {
            aMenu.style.posTop = event.event.offsetY - oh - 6;
        }
    }
    $(aMenu).fadeIn('fast');
}


function showContextMenu(vLevel)
{
	var aMenu = document.all.contextMenu;
	var menuItemCount = aMenu.children.length;

	aMenu.children["insNode"].className="menAnc";
	aMenu.children["insNode"].disabled=false;
	aMenu.children["insLeaf"].className="menAnc";
	aMenu.children["insLeaf"].disabled=false;
	aMenu.children["moveUp"].className="menAnc";
	aMenu.children["moveUp"].disabled=false;
	aMenu.children["moveDown"].className="menAnc";
	aMenu.children["moveDown"].disabled=false;
	aMenu.children["CutItem"].className="menAnc";
	aMenu.children["CutItem"].disabled=false;
	aMenu.children["PasteItem"].className="menAnc";
	aMenu.children["PasteItem"].disabled = false;
	aMenu.children["PasteBrotherItem"].className = "menAnc";
	aMenu.children["PasteBrotherItem"].disabled = false;
	aMenu.children["editOpen"].className = "menAnc";
	aMenu.children["editOpen"].disabled = false;
	
		
	if (vLevel=='3') //is a leaf - cant insert leaf or node
	{
		aMenu.children["insNode"].className="menAncDisabled";
		aMenu.children["insNode"].disabled=true;
		aMenu.children["insLeaf"].className="menAncDisabled";
		aMenu.children["insLeaf"].disabled=true;
	} 
	try
	{
		event.srcElement.parentElement.previousSibling.previousSibling;
	}
	catch(e)
	{
		aMenu.children["moveUp"].className="menAncDisabled";
		aMenu.children["moveUp"].disabled=true;
	}
	try
	{
		event.srcElement.parentElement.nextSibling.nextSibling;
	}
	catch(e)
	{
		aMenu.children["moveDown"].className="menAncDisabled";
		aMenu.children["moveDown"].disabled=true;
	}
	
	src=event.srcElement;
	aMenu.srcId = src.getAttribute("data-itemid");

	if (src.getAttribute("data-itemid") == 1) {
	    aMenu.children["moveDown"].className = "menAncDisabled";
	    aMenu.children["moveDown"].disabled = true;
	    aMenu.children["moveUp"].className = "menAncDisabled";
	    aMenu.children["moveUp"].disabled = true;
	    aMenu.children["CutItem"].className = "menAncDisabled";
	    aMenu.children["CutItem"].disabled = true;
    }
	
	if (CurrentCutItem == null || (CurrentCutItem != null && src.getAttribute("data-itemid") == CurrentCutItem.getAttribute("data-itemid")) || src.nodeType== 'leaf')
	{
		aMenu.children["PasteItem"].className="menAncDisabled";
		aMenu.children["PasteItem"].disabled = true;

		aMenu.children["PasteBrotherItem"].className = "menAncDisabled";
		aMenu.children["PasteBrotherItem"].disabled = true;
		
	}

	clearAll();
	
	var ow		=	aMenu.style.width.substr(0,aMenu.style.width.length-2); // width of menu
	var oh		=	20*menuItemCount+2;										// height of menu - each item 20 pixels high + 2 for top & bottom border
	var aw		=	document.body.clientWidth-ow;							// doc width minus menu width
	var ah		=	document.body.clientHeight-oh;							// doc height minus menu height

	if (event.clientX < aw) {
	    aMenu.style.posLeft = event.offsetX+70;
	}
	else {
	    if (event.clientX - ow < 0) {
	        aMenu.style.posLeft = aw - 18;
	    }
	    else {
	        aMenu.style.posLeft = event.clientX - ow;
	    }
	}

	if (event.offsetY < ah) {
	    aMenu.style.posTop = mouseY(event)-oh +36; 
    }
	else {
	    if (event.offsetY - oh < 0) {
	        aMenu.style.posTop = 4;
	    }
	    else {
	        aMenu.style.posTop = event.event.offsetY - oh - 6;
	    }
	}
	$(aMenu).fadeIn('fast');   
}

function showContextMenuContainer() {
    var aMenu = document.all.contextMenu;
    var menuItemCount = aMenu.children.length;

    
    aMenu.children["insContainer"].className = "menAnc";
    aMenu.children["insContainer"].disabled = false;
    aMenu.children["moveUp"].className = "menAnc";
    aMenu.children["moveUp"].disabled = false;
    aMenu.children["moveDown"].className = "menAnc";
    aMenu.children["moveDown"].disabled = false;
    aMenu.children["CutItem"].className = "menAnc";
    aMenu.children["CutItem"].disabled = false;
    aMenu.children["PasteItem"].className = "menAnc";
    aMenu.children["PasteItem"].disabled = false;

    aMenu.children["PasteBrotherItem"].className = "menAnc";
    aMenu.children["PasteBrotherItem"].disabled = false;
    

    var MoveUpId;
    var MoveDownId;
    var canMoveUp = false;
    var canMoveDown = false;
    try {
        previousElement=event.srcElement.parentElement.previousSibling.childNodes(2).ContainerId;
        canMoveUp = true;
        MoveUpId = previousElement;
    }
    catch (e) {
        aMenu.children["moveUp"].className = "menAncDisabled";
        aMenu.children["moveUp"].disabled = true;
    }
    try {

        nextElement = event.srcElement.parentElement.nextSibling.childNodes(2).ContainerId;
        canMoveDown = true;
        MoveDownId = nextElement;
    }
    catch (e) {
        aMenu.children["moveDown"].className = "menAncDisabled";
        aMenu.children["moveDown"].disabled = true;
    }

    src = event.srcElement;
    aMenu.srcId = src.ContainerId;
    aMenu.srcType = "container";
    if(canMoveUp)
        aMenu.MoveUpTargetId=MoveUpId;
    if(canMoveDown)
        aMenu.MoveDownTargetId = MoveDownId;

    /*if (src.ContainerId == 1) {
        aMenu.children["moveDown"].className = "menAncDisabled";
        aMenu.children["moveDown"].disabled = true;
        aMenu.children["moveUp"].className = "menAncDisabled";
        aMenu.children["moveUp"].disabled = true;
        aMenu.children["CutItem"].className = "menAncDisabled";
        aMenu.children["CutItem"].disabled = true;
    }*/

    if (CurrentCutItem == null || (CurrentCutItem != null && src.ContainerId == CurrentCutItem.ContainerId)) {
        aMenu.children["PasteItem"].className = "menAncDisabled";
        aMenu.children["PasteItem"].disabled = true;
        
        aMenu.children["PasteBrotherItem"].className = "menAncDisabled";
        aMenu.children["PasteBrotherItem"].disabled = true;
    }

    clearAll();

    var ow = aMenu.style.width.substr(0, aMenu.style.width.length - 2); // width of menu
    var oh = 20 * menuItemCount + 2; 									// height of menu - each item 20 pixels high + 2 for top & bottom border
    var aw = document.body.clientWidth - ow; 						// doc width minus menu width
    var ah = document.body.clientHeight - oh; 						// doc height minus menu height

    if (event.clientX < aw) {
        aMenu.style.posLeft = event.offsetX + 20;
    }
    else {
        if (event.clientX - ow < 0) {
            aMenu.style.posLeft = aw - 18;
        }
        else {
            aMenu.style.posLeft = event.clientX - ow;
        }
    }

    if (event.offsetY < ah) {
        aMenu.style.posTop = mouseY(event) - oh + 15;
    }
    else {
        if (event.offsetY - oh < 0) {
            aMenu.style.posTop = 4;
        }
        else {
            aMenu.style.posTop = event.event.offsetY - oh - 6;
        }
    }
    $(aMenu).fadeIn('fast');
}

function showContextMenuImg() {
    var aMenu = document.all.contextMenu;
    var menuItemCount = aMenu.children.length;

    aMenu.children["insContainer"].className = "menAncDisabled";
    aMenu.children["insContainer"].disabled = true;
    aMenu.children["moveUp"].className = "menAnc";
    aMenu.children["moveUp"].disabled = false;
    aMenu.children["moveDown"].className = "menAnc";
    aMenu.children["moveDown"].disabled = false;
    aMenu.children["CutItem"].className = "menAnc";
    aMenu.children["CutItem"].disabled = false;
    aMenu.children["PasteItem"].className = "menAncDisabled";
    aMenu.children["PasteItem"].disabled = true;
    aMenu.children["PasteBrotherItem"].className = "menAncDisabled";
    aMenu.children["PasteBrotherItem"].disabled = false;

    var MoveUpId;
    var MoveDownId;
    canMoveUp = false;
    canMoveDown = false;
    try {
        previousElement = event.srcElement.parentElement.previousSibling.childNodes(1).ImageId;
        if (previousElement == undefined)
            throw "node found - but not image node";
        canMoveUp = true;
        MoveUpId = previousElement;
    }
    catch (e) {
        aMenu.children["moveUp"].className = "menAncDisabled";
        aMenu.children["moveUp"].disabled = true;
    }
    try {

        nextElement = event.srcElement.parentElement.nextSibling.childNodes(1).ImageId;
        canMoveDown = true;
        MoveDownId = nextElement;
    }
    catch (e) {
        aMenu.children["moveDown"].className = "menAncDisabled";
        aMenu.children["moveDown"].disabled = true;
    }

    src = event.srcElement;
    aMenu.srcId = src.ImageId;
    aMenu.srcType = "image";
    if (canMoveUp)
        aMenu.MoveUpTargetId = MoveUpId;
    if (canMoveDown)
        aMenu.MoveDownTargetId = MoveDownId;

    clearAll();

    var ow = aMenu.style.width.substr(0, aMenu.style.width.length - 2); // width of menu
    var oh = 20 * menuItemCount + 2; 									// height of menu - each item 20 pixels high + 2 for top & bottom border
    var aw = document.body.clientWidth - ow; 						// doc width minus menu width
    var ah = document.body.clientHeight - oh; 						// doc height minus menu height

    if (event.clientX < aw) {
        aMenu.style.posLeft = event.offsetX + 20;
    }
    else {
        if (event.clientX - ow < 0) {
            aMenu.style.posLeft = aw - 18;
        }
        else {
            aMenu.style.posLeft = event.clientX - ow;
        }
    }

    if (event.offsetY < ah) {
        aMenu.style.posTop = mouseY(event) - oh + 15;
    }
    else {
        if (event.offsetY - oh < 0) {
            aMenu.style.posTop = 4;
        }
        else {
            aMenu.style.posTop = event.event.offsetY - oh - 6;
        }
    }
    $(aMenu).fadeIn('fast');
}


function mouseX(evt) {
    if (evt.pageX) return evt.pageX;
    else if (evt.clientX) {
        return evt.clientX + (document.documentElement.scrollLeft ? document.documentElement.scrollLeft : document.body.scrollLeft);
    }
    else return null;
}
function mouseY(evt) {
    if (evt.pageY) return evt.pageY;
    else if (evt.clientY)
        return evt.clientY + (document.documentElement.scrollTop ?
   document.documentElement.scrollTop :
   document.body.scrollTop);
    else return null;
}

function ExpandCollapseAll()
{
	var ulTags=document.all.tags("ul");
	for(i=0;i<ulTags.length;i++)
	{
	    if (ulTags[i].getAttribute("top") == "Y") 
        {
			if(event.srcElement.init=="1")
			{
				ulTags[i].style.display="none";
			}
			else
			{
				ulTags[i].style.display="";
			}
		}
	}
	var AncTags = document.all.tags("a");
	var ckState = "";
	for(i=0;i<AncTags.length;i++)
	{
	    if(AncTags[i].getAttribute("vid")=="xc")
		{
			if(event.srcElement.init=="1")
			{
			    AncTags[i].innerHTML = "<img src='images/plus.gif' border='0' style='margin-right:4px;'/>";
			    ckState += AncTags[i].id;
			}
			else
			{
			    AncTags[i].innerHTML = "<img src='images/minus.gif' border='0' style='margin-right:4px;'/>";
			}
		}
	}
	$.cookie("STATE", ckState, { expires: 2 });;
	if (event.srcElement.init == "1") {
	    event.srcElement.init = "2";
	    event.srcElement.children[0].className = 'bImg bExpCol';
	    event.srcElement.children[1].innerText = 'Expand All';
	}
	else {
	    event.srcElement.init = "1";
	    event.srcElement.children[0].className = 'bImg bExpCol2';
	    event.srcElement.children[1].innerText = 'Collapse All';
	}
}

function validateAcronym() {
    var submitFailed = false;
    var engAcronym = "";
    var freAcronym = "";
    var engTitle = "";
    var freTitle = "";

    if (document.forms.aspnetForm.english.value == '') {
        submitFailed = true;
        engAcronym = "Acronym (eng) field cannot be blank.\n";
    }
    if (document.forms.aspnetForm.french.value == '') {
        submitFailed = true;
        freAcronym = "Acronym (fre) field cannot be blank.\n";
    }
    if (document.forms.aspnetForm.desc_e.value == '') {
        submitFailed = true;
        engTitle = "Description (eng) field cannot be blank.\n";
    }
    if (document.forms.aspnetForm.desc_f.value == '') {
        submitFailed = true;
        freTitle = "Description (fre) field cannot be blank.\n";
    }

    if (submitFailed) {
        alert("The following error(s) occurred:\n\n" + engAcronym + freAcronym + engTitle + freTitle);
        return false;
    }
}

function acrnmLetter(language, value) {
    var letter;
    var letter2;
    if (language == 'eng') {
        letter = value.substring(0, 1)
        letter2 = letter.toUpperCase()
        document.all.letter_e.value = letter2
    }
    else {
        letter = value.substring(0, 1)
        letter2 = letter.toUpperCase()
        document.all.letter_f.value = letter2
    }
}

function insertAcronym() {

    var str = document.selection.createRange().text;
    document.frmEditMenu.stream.focus();
    var sel = document.selection.createRange();
    if (event.srcElement.value != "") {
        sel.text = "<abbr title=\"" + event.srcElement.value + "\">" + $("#acronymInsert option:selected").html() + "</abbr>";
        //sel.text = "<%=setAcronym(\"" + event.srcElement.value + "\")%>";
    }
    event.srcElement.value = "";
    return;
}

function validateNewImage()
{
	if(formUpload.Name.value=="")
	{
		alert("Name cannot be blank");
		return false;
	}
	return true;
}

function DeleteImage()
{
	if(confirm("Deleting an image will not delete its references.  Please ensure all pointers to this image no longer exist before deleting.\n\nPress OK to delete, or Cancel to return to the page without deleting."))
		return true;

	return false;
}
function DeleteImageFolder() {
    if (confirm("Are you sure you want to delete this folder?\n\nPress OK to delete, or Cancel to return to the page without deleting."))
        return true;

    return false;
}



function userConfirm(nodetype)
{
	var sMessage;
	if(nodetype=="leaf")
		sMessage="YOU ARE ABOUT TO DELETE A LEAF AND THE CONTENTS OF ITS PAGE\n\nAre you sure you want to delete this leaf along with the contents of its page?";
	else
		sMessage="YOU ARE ABOUT TO DELETE A NODE\n\nAre you sure you want to delete this node?";
		
	if(confirm(sMessage+"\n\nPress OK to delete, or Cancel to return to the page without deleting."))
	{
		return true;
	}
	else
	{
		return false;
	}
}
function rowover(oid)
{
	oid.style.color='blue';
	oid.style.cursor='hand';
}
function rowout(oid)
{
	oid.style.color='black';
	oid.style.cursor='normal';
}
function loadRec(opgid,oid)
{
	location='default.asp?pgid='+opgid+'&id='+oid;
}
function WhatsNewPreview()
{	
	oHeader='<h3>What\'s new as of <u><em>'+document.frmEditMenu.date.value+'</em></u></h3><h4>'+document.frmEditMenu.title.value+'</h4>';
	oTA='<p>'+document.frmEditMenu.stream.value+'</p>';
	document.all.oWhatsNew.innerHTML=oHeader+oTA;
	document.frmEditMenu.stream.focus();
}
function editorWrap(chkElm)
{
	if(chkElm.checked)
	{
		resizeTA('soft');
		setCookie("wrapEditor","true",365);
	}
	else
	{
		resizeTA('off');
		setCookie("wrapEditor","false",365);
	}
}

function resizeTA(elmt, wrapValue)
{
    elmt.wrap = wrapValue;
}	

function contentPreview()
{
	document.all.oPreview.innerHTML=document.frmEditMenu.stream.value;
	//document.all.oPreviewDiv.style.display = "";
	//document.all.chkPrev.checked=true;
	//setCookie("showPreview",true,365);
	try
	{
		document.frmEditMenu.stream.focus();
	}
	catch(e){}
}

function CheckEditorPreviewCookies()
{
	if(readCookie("showPreview")==null)
		setCookie("showPreview","false",365);
	//if(readCookie("showEditor")==null)
	//	setCookie("showEditor","true",365);
	//if(readCookie("wrapEditor")==null)
	//	setCookie("wrapEditor","true",365);

	//if(readCookie("showPreview")=="true")
	//	document.all.oChkPrev.checked=true;
	//else
	//	document.all.oChkPrev.checked=false;
	//showHideEditor(document.all.oChkPrev);
	
	/*if(readCookie("showEditor")=="true")
		document.all.oChkEditor.checked=true;
	else
		document.all.oChkEditor.checked=false;
	showHideEditor(document.all.oChkEditor);
	
	if(readCookie("wrapEditor")=="true")
		document.all.oChkWrap.checked=true;
	else
		document.all.oChkWrap.checked=false;	
	editorWrap(document.all.oChkWrap);
    */
}

function showHideEditor(chkElm)
{
	if(chkElm.name=="chkEditor")
	{
		if(chkElm.checked)
		{
			document.all.oEditorDiv.style.display="";
			setCookie("showEditor",true,365);
		}
		else
		{
			document.all.oEditorDiv.style.display="none";
			setCookie("showEditor",false,365);
		}
	}
	else if(chkElm.name=="chkPrev")
	{
		if(chkElm.checked)
		{
			document.all.oPreview.innerHTML=document.frmEditMenu.stream.value;
			document.all.oPreviewDiv.style.display="";
			setCookie("showPreview",true,365);
			try
			{
				document.frmEditMenu.stream.focus();
			}
			catch(e){}
		}
		else
		{
			document.all.oPreview.innerHTML="";
			document.all.oPreviewDiv.style.display="none";
			setCookie("showPreview",false,365);
			try
			{
				document.frmEditMenu.stream.focus();
			}
			catch(e){}
		}
	}
}
function scrollToNode() {
    //if(document.all.oHighlightNode.value!='')
    //{
    var src = "scrollTo" + location.hash.replace("#","");// document.all.oHighlightNode.value;
    var elmnt = document.getElementById(src);
    if (elmnt != null) {
        elmnt.scrollIntoView(true);
        elmnt.focus();
    }
    //}
}
function CollapseSection(vulid, isSelector) {
	var src = "ExpCol" + vulid;
	var srcElm = document.getElementById(src);
	
	var ckState = $.cookie("STATE");
	if (ckState == null)
	    ckState = "";

	ckState = ckState.replace(src, "");

	if (srcElm.innerHTML.indexOf('plus.gif')!=-1) {
	   // $.cookie(src, 'Expanded', { expires: 2 });
	    //setCookie(src, "Expanded", 365);
	    $.cookie("STATE", ckState, { expires: 2 });
	}
	else {
	    //alert("saving cookie");
	    //alert(src);
	   // $.cookie(src, 'Collapsed', { expires: 2 });
	    //setCookie(src, "Collapsed", 365);
	    ckState += src;
	    $.cookie("STATE", ckState, { expires: 2 });
	}

	
    var ulidTags=document.all.tags("ul");
	var imgSource="";
	
	if(isSelector)
		  imgSource="../../";
	
	for(i=0;i<ulidTags.length;i++) {

	    if ( ulidTags[i].getAttribute("ulid")== vulid)
		{
			if(ulidTags[i].style.display=="none")
			{
			    ulidTags[i].style.display = "";
				srcElm.innerHTML = "<img src='"+imgSource+"images/minus.gif' border='0' style='margin-right:4px;'/>";
			}
			else
			{
			    ulidTags[i].style.display="none";
				srcElm.innerHTML = "<img src='"+imgSource+"images/plus.gif' border='0' style='margin-right:4px;'/>";
			}
		}
	}
		
	//location='default.asp?pgid=6017&ColId='+vulid+'&colExp='+srcElm.innerText;
}
function SetCollapseExpandSections()
{
	var ulidTags=document.all.tags("ul");
	var expColText = $.cookie("STATE");

	for(i=0;i<ulidTags.length;i++)
	{
	    if(ulidTags[i].getAttribute("top"))
		{
		    var colId = "ExpCol" + ulidTags[i].getAttribute("ulid");
	        
			//if ($.cookie(colId) == null) {
			//    $.cookie(colId, 'Expanded', { expires: 2 });
			    //setCookie(colId, "Expanded", 365);
			//}

			//var expColText = $.cookie(colId);
			var ancElement = document.getElementById(colId);
			//if (expColText == "Collapsed")
		    //{
			if (expColText!="undefined" && expColText.indexOf(colId) >= 0)
			{
			    //alert("collapsed!");
			    //alert(i);
			    //alert(colId);
			    ancElement.innerHTML = "<img src='images/plus.gif' border='0' style='margin-right:4px;'/>";
				ulidTags[i].style.display="none";
			}
			else
			{
			    ancElement.innerHTML = "<img src='images/minus.gif'  border='0' style='margin-right:4px;'/>";
				ulidTags[i].style.display="";
			}
		}
	}
}

function loadMembersList() {
    var rValue = window.showModalDialog("content_manager/content_manager_pages/sam_groups_newMember.asp", "", "dialogHeight: 420px; dialogWidth: 580px; edge: Raised; center: Yes; help: No; resizable: No; status: No;");
    if (rValue.cancel == 'cancel') {
        return;
    }
    else {
        document.frmEditMenu.memberName.value = rValue.memberName;
        document.frmEditMenu.empid.value = rValue.id;
    }
}


function deleteWhatsNew()
{
	if(confirm("DELETE WHAT'S NEW ENTRY\n\nAre you sure you want to delete this entry?\n\nPress OK to delete, or Cancel to return to the page without deleting."))
	{
		return true;
	}
	else
	{
		return false;
	}
}
function confirmPublish()
{
	if(confirm("PUBLISH WHAT'S NEW TO CLASMATE\n\nAre you sure you want to publish the What's New to Production?\n\nPress OK to continue, or Cancel to return to the page without publishing."))
	{
		return true;
	}
	else
	{
		return false;
	}
}

function DontSubmitOnEnter() {
    if (event.keyCode == 13) {
        event.returnValue = false;
    }
}

function refreshKeyDown()
{
	if(event.keyCode==116)
	{
		event.returnValue=false;
	}
}
function launchAdminWindow()
{
	window.open('content_manager/','admin','fullscreen=yes,directories=yes,location=no,status=yes,menubar=yes,resizable=yes,scrollbars=yes');
}
function launchEditorWindow(id,inc)
{
    window.open('Editor.aspx?id=' + id + '&inc=' + inc , '', 'fullscreen=no,directories=yes,location=no,status=yes,menubar=yes,resizable=yes,scrollbars=yes');
}
function endSession()
{
	if (confirm('Are you sure you want to end you session?\n\nClick OK to terminate your session or Cancel to return to the application.'))
	{
		window.close();
	}
}
function setCookie(name,value,days)
{
	if(days)
	{
		var date = new Date();
		date.setTime(date.getTime()+(days*24*60*60*1000));
		var expires= "; expires="+date.toGMTString();
	}
	else
	{
		var expires="";
	}
	document.cookie = name+"="+value+expires+"; path=/";
}
function readCookie(name)
{
	var vName = name+"=";
	var ca = document.cookie.split(";");
	for(var i=0 ; i < ca.length ; i++)
	{
		
		var c = ca[i];
		while (c.charAt(0)==" ") c = c.substring(1,c.length);
		if(c.indexOf(vName) == 0) return c.substring(vName.length,c.length);
	}
	return null;
}
function removeCookie(name)
{
	setCookie(name,"",-1);
}
function refreshEditor()
{
	if(confirm("If you refresh, you will lose any changes since you last saved/loaded the page.\n\nPress OK to Refresh, or Cancel to return to the page without losing your changes."))
		window.location.href = window.location.href;
}
function ValidateNewPage()
{
	var EngTitle=document.frmEditMenu.eng.value;
	var FreTitle=document.frmEditMenu.fre.value;
	var okToSave=true;
	var msg="";
	
	if(EngTitle.length<1)
	{
		okToSave=false;
		msg="English Title cannot be blank.\n";
	}
		
	if(FreTitle.length<1)
	{
		okToSave=false;
		msg+="French Title cannot be blank.\n";
	}	
	
	if(!okToSave)
	{
		alert(msg);
		return false;
	}
	return true;	
}