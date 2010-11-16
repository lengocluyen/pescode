<%@ Page MasterPageFile="~/SiteMaster.Master" Language="C#" AutoEventWireup="true"
    CodeBehind="ViewGroup.aspx.cs" Inherits="PESWeb.Groups.ViewGroup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Groups" runat="server">
    <div style="padding-left: 10px;">
        <ul class="menu1" style="margin-top: 8px;">
            <li><a href="/Groups/ManageGroup.aspx">
                <img src="/images/group.gif" alt="" />Tạo nhóm mới</a></li>
            <li><a href="/Groups/mygroups.aspx">
                <img src="/images/group.gif" alt="" />Nhóm của tôi</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ContentPlaceHolderID="Content" runat="server">
    <div class="grid_20">
        <div id="title">
            <h1>
                Nhóm</h1>
            <%--<div class="alignright">
                <a href="../Groups/ManageGroup.aspx" class="button green">Tạo nhóm mới</a>
            </div>--%>
        </div>
        <div class="clear">
        </div>
        <div class="toolbar">
            <div class="buttons">
                <div class="alignleft">
                        <asp:Label ForeColor="Red" ID="lblMessage" runat="server"></asp:Label>
                        &nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblPrivateMessage" ForeColor="Red" runat="server" Text="Nhóm riêng tư!"></asp:Label>
                        
                </div>
                <div class="alignright">
                    <asp:LinkButton ID="lbViewMembers" CssClass="button green" OnClick="lbViewMembers_Click"
                        Text="Danh sách thành viên" runat="server"></asp:LinkButton>
                    &nbsp;<asp:LinkButton CssClass="button green" ID="lbRequestMembership" OnClick="lbRequestMembership_Click"
                        Text="Gia nhập nhóm" runat="server"></asp:LinkButton>
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
        
        <asp:Panel ID="pnlPublic" runat="server">
            <div class="post-gravatar">
                <asp:HyperLink ID="linkAvatar" runat="server">
                    <asp:Image ID="imgGroupLogo" runat="server" Width="100" Height="100" CssClass="avatar" />
                </asp:HyperLink>
            </div>
            <div class="post-text">
                <h2 class="title">
                    <asp:HyperLink ID="linkTitle" runat="server"></asp:HyperLink></h2>
                <div class="body">
                    <asp:Label ID="lblDescription" runat="server"></asp:Label><br />
                </div>
                <div class="meta">
                    <asp:Label ID="lblCreateDate" runat="server"></asp:Label><br />
                    <br />
                    <asp:Label ID="lblUpdateDate" runat="server"></asp:Label><br />
                    <br />
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="pnlPrivate" runat="server">
            <asp:Label ID="lblBody" runat="server"></asp:Label>
        </asp:Panel>
    </div>
</asp:Content>
