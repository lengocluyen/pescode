<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PESWeb.Friends.Default" %>
<%@ Import namespace="Pes.Core"%>
<%@ Register Src="~/UserControls/ProfileDisplay.ascx" TagPrefix="uc" TagName="ProfileDisplay" %>
<asp:Content ID="Content6" ContentPlaceHolderID="Content" runat="server">


<div class="grid_13">
    <div class="page-heading hr">
	    <h2>Bạn bè</h2>
    </div>
</div>

<div class="grid_9">
    <div class="f-list">
        <asp:Repeater ID="repFriends" runat="server" OnItemDataBound="repFriends_ItemDataBound">
            <ItemTemplate>
                <uc:ProfileDisplay ShowFriendRequestButton="false" ID="pdProfileDisplay" runat="server" />
            </ItemTemplate>
            <SeparatorTemplate>
                <div class="FriendSeparator"></div>
            </SeparatorTemplate>
        </asp:Repeater>
    </div>
</div>
</asp:Content>
