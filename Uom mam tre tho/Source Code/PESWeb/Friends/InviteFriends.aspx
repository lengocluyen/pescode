<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true"
    CodeBehind="InviteFriends.aspx.cs" Inherits="PESWeb.Friends.InviteFriends" %>

<asp:Content ID="Content6" ContentPlaceHolderID="Content" runat="server">
    <div class="grid_20">
        <div id="title">
            <h1>
            Mời bạn bè</h2>
        </div>
        <div class="clear">
        </div>
        <div class="post">
            <asp:Panel ID="pnlInvite" runat="server">
                <asp:Label ID="lblFrom" runat="server" Visible="false"></asp:Label>
                <dl>
                    <dt>Email người nhận:</dt>
                    <dd>
                        <asp:TextBox ID="txtTo" runat="server" Width="400"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqTo" runat="server" ControlToValidate="txtTo" ErrorMessage="*" />
                    </dd>
                    <dt>Nội dung:</dt>
                    <dd>
                        <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" Width="400" Rows="5"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqMessage" runat="server" ControlToValidate="txtMessage"
                            ErrorMessage="*" />
                    </dd>
                    <dt></dt>
                    <dd class="align-center">
                        <asp:Button ID="btnInvite" runat="server" Text="Gửi" OnClick="btnInvite_Click" CssClass="button" /></dd>
                </dl>
            </asp:Panel>
            <asp:Label ID="lblMessage" runat="server" Font-Bold="true"></asp:Label>
        </div>
    </div>
   
</asp:Content>
