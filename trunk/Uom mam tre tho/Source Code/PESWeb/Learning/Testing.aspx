<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Testing.aspx.cs" Inherits="PESWeb.Learning.Testing" %>

<%@ Register Assembly="System.Web.Silverlight" Namespace="System.Web.UI.SilverlightControls"
    TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            padding: 0;
            margin: 0;
            background:#f8f8fc url(../ClientBin/Images/Test/bg.png) top left repeat-x;
        }
        #silverlightControlHost
        {
            margin: 0 auto;
            width: 954px;
            background:transparent;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="silverlightControlHost">
        <asp:Silverlight ID="Silverlight1" runat="server" Source="~/ClientBin/PrimaryEducationSystem.Tests.xap" Width="100%" Height="900px" />
    </div>
    </form>
</body>
</html>
