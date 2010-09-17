var idControl;
function ShowDiv(DivID) {
    //Show hide.                
    if (document.getElementById) { // DOM3 = IE5, NS6
        document.getElementById(DivID).style.display = 'block';
    }
    else {
        if (document.layers) { // Netscape 4
            document.DivID.display = 'block';
        }
        else { // IE 4
            document.all.DivID.style.display = 'block';
        }
    }
}


function HideDiv(DivID) {
    alert("hello");
    if (document.getElementById) { // DOM3 = IE5, NS6
        document.getElementById(DivID).style.display = 'none';
    }
    else {
        if (document.layers) { // Netscape 4
            document.DivID.display = 'none';
        }
        else { // IE 4
            document.all.DivID.style.display = 'none';
        }
    }
}

function callShowHide(DivID, imagename, srcShow, srcHide) {
    var x = document[imagename].src;
    var inde = x.indexOf(srcShow);

    if (inde == "-1") {
        ShowDiv(DivID, imagename, srcShow);
    }
    else {
        HideDiv(DivID, imagename, srcHide);
    }
}
//function DHTMLSound(surl) {
//    document.getElementById("hk").innerHTML =
//"<embed src='" + surl + "' hidden=true autostart=true loop=true>";
//}
// DHTML Sound
function DHTMLSound(surl) {
    var str = document.location.href;
    var vitri = 0;
    str = str.toLowerCase();
    if (str.indexOf("/admin/lessions.aspx") != -1)
        vitri = str.indexOf("/admin/lessions.aspx");
    if (str.indexOf("/displaypart.aspx") != -1)
        vitri = str.indexOf("/displaypart.aspx");
    var resul = str.substring(0, vitri) + surl;
    document.getElementById("divSound").innerHTML =
            "<object id='MediaPlayerLession' width='0' height='0' classid='CLSID:22D6f312-B0F6-11D0-94AB-0080C74C7E95' standby='Đang tải âm thanh...' type='application/x-oleobject' codebase='http://activex.microsoft.com/activex/controls/mplayer/en/nsmp2inf.cab#Version=6,4,7,1112'>" +
                "<param name='filename' value='" + resul + "'>" +
                "<param name='Showcontrols' value='False'>" +
                "<param name='autoStart' value='True'>" +
                "<param name='volume' value='90'>" +
                "<embed type='application/x-mplayer2' src='" + resul + "' name='MediaPlayer' width=0 height=0></embed>" +
            "</object>";
}