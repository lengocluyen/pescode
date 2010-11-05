<%@ Page Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ViewPhoto.aspx.cs" Inherits="PESWeb.Photos.ViewPhotos" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
Trở lại Tiếp
<asp:HyperLink NavigateUrl="~/Photos/ViewLargePhoto.aspx" Target="_blank" Text="Photo" runat="server"></asp:HyperLink>
</asp:Content>