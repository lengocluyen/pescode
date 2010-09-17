<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowGroup.aspx.cs" Inherits="ShowGroup" %>

<%@ Register src="UserControls/ShowGroup.ascx" tagname="ShowGroup" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/V_cs.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:ShowGroup ID="ShowGroup1" runat="server" />
    </div>
    </form>
</body>
</html>
