function launchGlobalRole(roleCode) {
    window.open("officerrole.aspx?grole=" + roleCode, "", "toolbar=yes, scrollbars=yes, resizable=yes, top=200, left=200, width=700, height=400");

}
function launchAcDocNote(isInsert, linkTable, linkId, pType, acDocId) {
    if (isInsert) {
        var r = window.showModalDialog('note.aspx?insert=Y&linktable=' + linkTable + '&linkid=' + linkId + '&kind=' + pType, "", "dialogWidth: 790px; dialogHeight: 500px; edge: Raised; center: yes; resizable: yes; status: no;");
        if (r == "Y")
            refresh();
    }
    else {
        var r = window.showModalDialog('note.aspx?edit=Y&acdocid=' + acDocId + '&kind=' + pType, "", "dialogWidth: 790px; dialogHeight: 500px; edge: Raised; center: yes; resizable: yes; status: no;");
        if (r == "Y")
            refresh();
    }
}

function refresh() {
    document.location.reload(true);
}

function deleteAcDocNote(acDocId) {
    var r = window.showModalDialog('note.aspx?delete=Y&acdocid=' + acDocId, "", "dialogWidth: 790px; dialogHeight: 500px; edge: Raised; center: yes; resizable: yes; status: no;");
    if (r == "Y")
        refresh();
}

function toggleWFView(showList) {
    if (showList) {
        document.all.wfList.style.display = '';
        document.all.wfTbl.style.display = 'none';
    }
    else {
        document.all.wfList.style.display = 'none';
        document.all.wfTbl.style.display = '';
    }
}

function toggleGrp(trName) {
    var img = event.srcElement;
    var vdisplay;
    if (img.src.substr(img.src.length - 9) == 'minus.gif') {
        img.src = "images/plus.gif";
        vdisplay = "none";
    }
    else {
        img.src = "images/minus.gif";
        vdisplay = "";
    }

    var trArray = document.getElementsByTagName("tr");
    for (i = 0; i < trArray.length; i++) {
        if (trArray[i].name == trName)
            trArray[i].style.display = vdisplay;
    }
}

function xpnd(xpand) {
    var vdisplay;
    if (xpand) {
        document.all.oExpand.style.display = "none";
        document.all.oCollapse.style.display = "";
        vdisplay = "";
    }
    else {
        document.all.oExpand.style.display = "";
        document.all.oCollapse.style.display = "none";
        vdisplay = "none";
    }

    var trArray = document.getElementsByTagName("tr");
    for (i = 0; i < trArray.length; i++) {
        if (trArray[i].id == 'xpndcol') {
            trArray[i].style.display = vdisplay;
        }

        if (trArray[i].name == "trGrp") {
            var img = trArray[i].childNodes[0].childNodes[0];
            if (img.src.substr(img.src.length - 9) == 'minus.gif') {
                img.src = "images/plus.gif";
            }
            else {
                img.src = "images/minus.gif";
            }
        }
    }
}

function obsCheck() {
    document.getElementById("incObs").checked = !document.getElementById("incObs").checked;
    document.getElementById("incObs").disabled = true;
    document.getElementById("aIncObs").disabled = true;
    document.getElementById("incObsReload").className = 'obsReloadA';

    var loc = location.href;

    //need regex to handle the clearing of qs
    var newloc;
    newloc = loc.replace("&incObs=Y", "");
    newloc = newloc.replace("?incObs=Y", "");
    newloc = newloc.replace("&incObs=N", "");
    newloc = newloc.replace("?incObs=N", "");

    if (document.getElementById("incObs").checked)
        location.href = newloc + "&incObs=Y";
    else
        location.href = newloc + "&incObs=N";
}