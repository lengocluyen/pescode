<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true"
    CodeBehind="ReadMessage.aspx.cs" Inherits="PESWeb.Mail.ReadMessage" %>

<%@ Register Src="~/Mail/UserControls/Folders.ascx" TagPrefix="PES" TagName="Folders" %>
<asp:Content ID="Content2" ContentPlaceHolderID="FoldersMail" runat="server">
    <PES:Folders ID="Fmail" runat="server" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div class="grid_13">
        <div class="page-heading hr">
            <h2>
                Read Message</h2>
        </div>
        <div class="divContainerCellHeader">
            From:</div>
        <div class="divContainerCell">
            <asp:HyperLink ID="linkFrom" runat="server"></asp:HyperLink></div>
        <div class="divContainerCellHeader">
            Subject:</div>
        <div class="divContainerCell">
            <asp:Label ID="lblSubject" runat="server"></asp:Label></div>
        <div class="divContainerCellHeader">
            Message:</div>
        <div class="divContainerCell">
            <asp:Label ID="lblMessage" runat="server"></asp:Label><br />
            <br />
        </div>
        <div class="divContainerCell">
            <asp:Button CssClass="button" Style="text-align: center;" ID="btnReply" runat="server" OnClick="btnReply_Click"
                Text="Reply" /></div>
    </div>
</asp:Content>
