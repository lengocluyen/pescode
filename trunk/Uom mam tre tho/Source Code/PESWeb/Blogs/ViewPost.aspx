<%@ Page Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true"
    CodeBehind="ViewPost.aspx.cs" Inherits="PESWeb.Blogs.ViewPost" %>

<%@ Register Src="~/UserControls/Comments.ascx" TagPrefix="PES" TagName="Comments" %>
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
        <div class="post" id='post-<%=blogID %>'>
            <div class="post-gravatar">
                <asp:HyperLink ID="linkProfile" runat="server">
                    <asp:Image ID="imgAvatar" ImageUrl="/images/profileavatar/profileimage.aspx" runat="server"
                        Width="50" Height="50" CssClass="avatar" />
                </asp:HyperLink>
            </div>
            <div class="post-text">
                <h2 class="title">
                    <asp:Label ID="lblTitle" runat="server"></asp:Label></h2>
                <div class="body">
                    <asp:Label ID="lblPost" runat="server"></asp:Label>
                </div>
                <div class="meta">
                    Ngày viết:
                    <asp:Label ID="lblCreated" runat="server"></asp:Label> - <a href="#" id='respondlink-<%=blogID %>' class="respondlink">Cảm nhận</a>
                   <%-- Lần cập nhật cuối:
                    <asp:Label ID="lblUpdated" runat="server"></asp:Label><br />--%>
                </div>
                <PES:Comments ID="comments" runat="server" 
                    SystemObject="Blogs" />
            </div>
        </div>
        
    </div>
</asp:Content>
