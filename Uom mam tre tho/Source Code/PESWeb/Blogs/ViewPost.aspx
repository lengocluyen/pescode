<%@ Page Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true"
    CodeBehind="ViewPost.aspx.cs" Inherits="PESWeb.Blogs.ViewPost" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <div class="grid_20">
        <div id="title">
            <h1>
                Blogs</h1>
            <div class="alignright">
                <a href="../blogs/post.aspx" class="button gray">Viết Blogs</a>
            </div>
        </div>
        <div class="clear">
        </div>
        <div class="textJustify">
            <br />
            <div class="divContainerCell" style="min-height: 300px;">
                <h2 style="padding-left: 7px;">
                    <asp:Label ID="lblTitle" runat="server"></asp:Label></h2>
                <br />
                <asp:HyperLink ID="linkProfile" runat="server">
                    <asp:Image Style="padding-bottom: 5px; float: left; margin: 10px;" Width="100" Height="100"
                        ID="imgAvatar" runat="server" ImageUrl="/images/profileavatar/profileimage.aspx" />
                </asp:HyperLink>
                Ngày tạo:
                <asp:Label ID="lblCreated" runat="server"></asp:Label>
                Lần cập nhật cuối:
                <asp:Label ID="lblUpdated" runat="server"></asp:Label><br />
                <br />
                <asp:Label ID="lblPost" runat="server"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
