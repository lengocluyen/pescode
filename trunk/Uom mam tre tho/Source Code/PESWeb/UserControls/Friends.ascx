<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Friends.ascx.cs" Inherits="PESWeb.UserControls.Friends" %>
<%@ Register Src="~/UserControls/ProfileDisplay.ascx" TagPrefix="PES" TagName="ProfileDisplay" %>
<h2>
    Bạn bè</h2>
<div class="block-c">
    <div class="h-list">
        <asp:UpdatePanel ID="udFriends" runat="server">
            <ContentTemplate>
                <asp:Repeater ID="repFriends" runat="server" OnItemDataBound="repFriends_ItemDataBound">
                    <ItemTemplate>
                        <PES:ProfileDisplay ShowFriendRequestButton="false" ShowDeleteButton="false" ID="pdProfileDisplay"
                            runat="server" />
                    </ItemTemplate>
                </asp:Repeater>
                <div class="clear">
                </div>
                <div>
                    <div style="float: left;">
                        <asp:ImageButton ID="btPrevious" Width="22px" Height="22px" runat="server" ImageUrl="/images/menu_ico_prev.gif"
                            OnClick="btPrevious_Click" /></div>
                    <div style="float: left;">
                        <asp:ImageButton ID="btNext" Width="22px" Height="22px" runat="server" ImageUrl="/images/menu_ico_next.gif"
                            OnClick="btNext_Click" /></div>
                </div>
            </ContentTemplate>
            <Triggers>
            <asp:AsyncPostBackTrigger EventName="Click" ControlID="btNext" />
            <asp:AsyncPostBackTrigger EventName="Click" ControlID="btPrevious" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</div>
