<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CropImage.aspx.cs" Inherits="Admin_CropImage" %>


<%@ Register src="../../../../../../UserControls/CropImageControl.ascx" tagname="CropImageControl" tagprefix="uc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Chỉnh Sửa Hình Ảnh</title>
    <link href="../../../../../../JCropCSS/Jcrop.css" rel="stylesheet" type="text/css" />
    <link href="../../../../../../JCropCSS/CropPageStyle.css" rel="stylesheet" type="text/css" />
    <script src="../../../../../../js/jquery.min.js" type="text/javascript"></script>
    <script src="../../../../../../js/jquery.Jcrop.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="mainbody">
        <uc1:CropImageControl ID="CropImageControl1" runat="server" />
    </div>
    </form>
</body>
</html>
