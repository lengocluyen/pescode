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
    <div class="grid_19 omega">
        <div id="title">
            <h2>
                Tìm kiếm</h2>
        </div>
        <div class="clear">
        </div>
        <div class="post">
            <asp:Label ID="lblSearchTerm" runat="server"></asp:Label><br /><br />
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
</asp:Content>
