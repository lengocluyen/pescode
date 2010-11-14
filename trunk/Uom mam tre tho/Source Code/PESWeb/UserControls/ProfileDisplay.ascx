<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProfileDisplay.ascx.cs"
    Inherits="PESWeb.UserControls.ProfileDisplay" %>
<div class="friend">
    <div class="f-gravatar">
        <a class="image" href="/Profiles/Profile.aspx?AccountID=<asp:Literal id='litAccountID' runat='server'></asp:Literal>">
            <asp:Image ImageAlign="Left" ID="imgAvatar" ImageUrl="~/images/ProfileAvatar/ProfileImage.aspx"
                runat="server" /></a>
    </div>
    <div class="f-edit">
        <asp:LinkButton ID="ibDelete" runat="server" OnClick="ibDelete_Click" rel="bookmark" CssClass="del15" />
      
    </div>
    <div class="f-content">
        <div class="f-name">
            <a class="bold" href="/Profiles/Profile.aspx?AccountID=<asp:Literal id='litAccountID2' runat='server'></asp:Literal>">
                <asp:Label ID="lblName" runat="server"></asp:Label>
            </a>
        </div>
        <div>
            <asp:LinkButton ID="ibInviteFriend" runat="server" Text="Kết bạn" OnClick="lbInviteFriend_Click" />
        </div>
        <asp:Label ID="lblFriendID" runat="server" Visible="false"></asp:Label>
        <%-- <asp:Label ID="lblUsername" runat="server"></asp:Label>
    <asp:Label ID="lblFirstName" runat="server"></asp:Label> <asp:Label ID="lblLastName" runat="server"></asp:Label>
    Since: <asp:Label ID="lblCreateDate" runat="server"></asp:Label><br />--%>
    </div>
    <div class="clear">
    </div>
</div>
