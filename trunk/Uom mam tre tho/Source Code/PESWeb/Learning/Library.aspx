<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Library.aspx.cs" Inherits="PESWeb.Learning.Library" %>

<%@ Register Assembly="System.Web.Silverlight" Namespace="System.Web.UI.SilverlightControls"
    TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>.:Flychips Spaces for Education:.</title>
   
</head>
<body style="margin:0 auto;">
    <form id="form1" runat="server" >
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>
        <asp:Silverlight ID="dienroi" runat="server" Height="750px" Width="100%" Source="~/ClientBin/LibraryBooks.xap"
            MinimumVersion="3.0.40624.0" Windowless="true" />
   </center>
   </form>
</body>
</html>
