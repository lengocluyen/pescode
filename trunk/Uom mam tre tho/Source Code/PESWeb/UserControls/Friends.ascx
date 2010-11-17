<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Friends.ascx.cs" Inherits="PESWeb.UserControls.Friends" %>
<%@ Register Src="~/UserControls/ProfileDisplay.ascx" TagPrefix="PES" TagName="ProfileDisplay" %>
<div class="grid_5 omega">
    <div class="widget">
        <h2>
            Bạn bè</h2>
        <asp:UpdatePanel ID="udFriends" runat="server">
            <ContentTemplate>
                <asp:Repeater ID="repFriends" runat="server" OnItemDataBound="repFriends_ItemDataBound">
                    <ItemTemplate>
                        <div class="friendBox">
                            <div class="f-gravatar">
                                <asp:HyperLink ID="linkProfile" runat="server">
                                    <asp:Image ImageAlign="Left" ID="imgAvatar" ImageUrl="~/images/ProfileAvatar/ProfileImage.aspx"
                                        runat="server" />
                                </asp:HyperLink>
                            </div>
                            <div class="clear">
                            </div>
                            <div class="friendName">
                                <asp:HyperLink ID="linkProfileName" runat="server">
                                    <asp:Label ID="lblName" runat="server"></asp:Label>
                                </asp:HyperLink>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="clear">
                </div>
                <div>
                    <div style="float: left;">
                        <asp:ImageButton ID="btPrevious" Width="15px" Height="15px" runat="server" ImageUrl="/images/menu_ico_prev.gif"
                            OnClick="btPrevious_Click" /></div>
                    <div style="float: left;">
                        <asp:ImageButton ID="btNext" Width="15px" Height="15px" runat="server" ImageUrl="/images/menu_ico_next.gif"
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
