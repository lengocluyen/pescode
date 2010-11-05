<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Friends.ascx.cs" Inherits="PESWeb.Mail.UserControls.Friends" %>
    <h2>
        <a href="#" id="toggle-hk2-menu" class="more">Bạn bè</a></h2>
    <div id="hk2-menu">
        <ul class="menu2">
        <li></li>
            <asp:Repeater OnItemDataBound="repFriends_ItemDataBound" ID="repFriends" runat="server">
                <ItemTemplate>
                    <li>
                        <asp:HyperLink ID="linkFriend" NavigateUrl="javascript:void;" runat="server" Text='<%# ((Account)Container.DataItem).Username %>'></asp:HyperLink></li></ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
