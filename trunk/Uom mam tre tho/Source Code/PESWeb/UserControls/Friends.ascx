<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Friends.ascx.cs" Inherits="PESWeb.UserControls.Friends" %>
<%@ Register Src="~/UserControls/ProfileDisplay.ascx" TagPrefix="PES" TagName="ProfileDisplay" %>
<div class="grid_5">
    <div id="title">
        <h2>
            Bạn bè</h2>
    </div>
    <div class="clear">
    </div>
    <asp:UpdatePanel ID="udFriends" runat="server">
        <ContentTemplate>
            <asp:Repeater ID="repFriends" runat="server" OnItemDataBound="repFriends_ItemDataBound">
                <ItemTemplate>
                    <div class="friendBox">
                        <div class="f-gravatar">
                            <a class="image" href="/Profiles/Profile.aspx?AccountID=<asp:Literal id='litAccountID' runat='server'></asp:Literal>">
                                <asp:Image ImageAlign="Left" ID="imgAvatar" ImageUrl="~/images/ProfileAvatar/ProfileImage.aspx"
                                    runat="server" /></a>
                        </div>
                        <div class="clear">
                        </div>
                        <div class="friendName">
                            <a class="bold" href="/Profiles/Profile.aspx?AccountID=<asp:Literal id='litAccountID2' runat='server'></asp:Literal>">
                                <asp:Label ID="lblName" runat="server"></asp:Label>
                            </a>
                        </div>
                    </div>
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
