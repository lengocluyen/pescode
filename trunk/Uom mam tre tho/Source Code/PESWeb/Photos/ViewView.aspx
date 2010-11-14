<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/SiteMaster.Master"
    AutoEventWireup="true" CodeBehind="ViewView.aspx.cs" Inherits="PESWeb.Photos.ViewView" %>

<%@ Register Src="~/UserControls/Tags.ascx" TagName="Tags" TagPrefix="PES" %>
<%@ Register Src="~/UserControls/Comments.ascx" TagName="Comments" TagPrefix="PES" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div class="grid_18">
        <div id="title">
            <h1>
                Album Ảnh:
                <asp:Label ID="lblAlbumName" runat="server" /></h1>
        </div>
        <div id="photos">
            <asp:Label Style="font-weight: bold;" ID="lblFileName" runat="server"></asp:Label>
            <br />
            <asp:HyperLink ID="linkImage" runat="server"></asp:HyperLink>
            <asp:Literal Visible="false" ID="litImageName" runat="server"></asp:Literal>
            <asp:Literal Visible="false" ID="litFileExtension" runat="server"></asp:Literal><br />
            <asp:Label ID="lblDescription" runat="server"> </asp:Label>
            <asp:Literal Visible="false" ID="litFileID" runat="server"></asp:Literal>
            <PES:Tags ID="Tags1" runat="server" SystemObjectID="5" Display="ShowCloudAndTagBox" />
            <PES:Comments ID="Comments1" runat="server" SystemObjectID="5"  />
         
        </div>
    </div>
</asp:Content>
