<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PreView.aspx.cs" Inherits="PESWeb.LearningVietNamese.PreView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Xin cho mot lat...</title>
    <script language="javascript" type="text/javascript">
        var width = screen.width;
        var height = screen.height;
        window.location = "View.aspx?width=" + width + "&height=" + height + "&" + window.location.search.substring(1);
    </script>        
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>