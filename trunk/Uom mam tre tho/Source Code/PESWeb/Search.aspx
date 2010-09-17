<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true"
    CodeBehind="Search.aspx.cs" Inherits="PESWeb.Search" %>

<%@ Import Namespace="Pes.Core" %>
<%@ Register Src="~/UserControls/ProfileDisplay.ascx" TagPrefix="uc" TagName="ProfileDisplay" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="SecondaryNav" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftNavTop" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftNavBottom" runat="server">
</asp:Content>--%>
<asp:Content ID="Content4" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Content" runat="server">
    <div class="grid_10">
        <div class="page-heading hr">
            <h2>
                Search</h2>
        </div>
        <div class="divContainerTitle">
            <asp:Label ID="lblSearchTerm" runat="server"></asp:Label></div>
        <div class="divContainerRow" style="height: 350px;">
            <div class="divContainerCell">
                <asp:Panel ID="pnlFriends" Height="350" runat="server">
                    <asp:Repeater ID="repAccounts" runat="server" OnItemDataBound="repAccounts_ItemDataBound">
                        <ItemTemplate>
                            <uc:ProfileDisplay ShowDeleteButton="false" ID="pdProfileDisplay" runat="server">
                            </uc:ProfileDisplay>
                        </ItemTemplate>
                    </asp:Repeater>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
