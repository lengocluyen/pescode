<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DisplayPart.aspx.cs" Inherits="PESWeb.LearningVietNamese.DisplayPart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title></title>

<script language="JavaScript">
    function DHTMLSound(surl) {
        document.getElementById("hk").innerHTML =
"<embed src='" + surl + "' hidden=true autostart=true loop=false>";
    }
</script>
</head>
<body>
<div id="hk"></div>
    <form id="form1" runat="server">
    <div id="content" runat="server">
    
    </div>
    </form>
</body>
</html>
