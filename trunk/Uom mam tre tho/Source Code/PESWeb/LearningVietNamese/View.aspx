<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="PESWeb.LearningVietNamese.View" %>

<%@ Register Assembly="System.Web.Silverlight" Namespace="System.Web.UI.SilverlightControls"
    TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" style="height: 100%;">
<head id="Head1" runat="server">    
<title></title>
<script type="text/javascript" language="javascript">
function DHTMLSound(surl) {
document.getElementById("hk").innerHTML=
"<embed src='"+surl+"' hidden=true autostart=true loop=true>";
}
</script>
</head>
<body style="height: 100%; margin: 0; background: url(ClientBin/Images/Home/bg_body.png) top left repeat-x;">
    
    <form id="form1" runat="server" style="height: 100%;">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="height: 100%;">
        <asp:Silverlight ID="Xaml1" runat="server" Source="~/ClientBin/ITBusSilverlight.xap"
            MinimumVersion="2.0.31005.0" Width="100%" Height="100%" Windowless="true" />
    </div>
    <iframe id="iframeContentPart" style="width:1px; height:1px; background-color:White" frameborder="0">
    </iframe>
    </form>
</body>
</html>