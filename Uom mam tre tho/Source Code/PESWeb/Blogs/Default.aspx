<%@ Page Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="PESWeb.Blogs.Default" %>

<%@ Register Src="~/UserControls/Friends.ascx" TagPrefix="PES" TagName="Friends" %>
<%@ Register TagPrefix="PES" Namespace="PESWeb" Assembly="PESWeb" %>
<asp:Content ContentPlaceHolderID="Content" runat="server">
    <div class="grid_14">
        <div id="title">
            <h1>
                Blogs</h1>
            <div class="alignright">
                <a href="../blogs/Post.aspx" class="button gray">Viết Blogs</a>
            </div>
        </div>
        <div class="clear">
        </div>
        <asp:ListView ID="lvBlogs" runat="server" OnItemDataBound="lvBlogs_ItemDataBound">
            <LayoutTemplate>
                <div class="post-list">
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <div class="post" id='post-<%#((Blog)Container.DataItem).BlogID %>'>
                    <div class="post-gravatar">
                        <asp:HyperLink ID="linkAvatar" runat="server">
                            <asp:Image ID="imaAvatar" runat="server" Width="50" Height="50" CssClass="avatar" />
                        </asp:HyperLink>
                    </div>
                    <div class="post-text">
                        <h2 class="title">
                            <asp:HyperLink ID="linkTitle" runat="server" Text='<%#((Blog)Container.DataItem).Title %>'></asp:HyperLink></h2>
                        <div class="body">
                            <%#((Blog)Container.DataItem).Subject %><asp:Literal ID="litBlogID" runat="server"
                                Text='<%#((Blog)Container.DataItem).BlogID %>'></asp:Literal>
                            <asp:Literal ID="litPageName" runat="server" Visible="false" Text='<%#((Blog)Container.DataItem).PageName %>'></asp:Literal>
                            <asp:Literal ID="litUsername" runat="server" Visible="false" Text='<%#Account.GetAccountByID(((Blog)Container.DataItem).AccountID).Username %>'></asp:Literal>
                        </div>
                        <div class="meta">
                            <%# Eval("CreateDate", "{0:dd-MM-yyyy lúc HH:mm}")  %>
                        </div>
                        <%--<PES:Comments runat="server" SystemObject="Alerts" SystemObjectRecordID='<%#((Alert)Container.DataItem).AlertID%>' />--%>
                    </div>
                </div>
            </ItemTemplate>
            <EmptyDataTemplate>
                Bạn chưa đăng bài blogs nào!
            </EmptyDataTemplate>
        </asp:ListView>
        <div class="clear">
        </div>
        <div style="text-align: center;">
            <PES:Pager ID="pager" runat="server" />
        </div>
    </div>
    <div class="grid_5" style="margin-top: 35px">
        <PES:Friends runat="server" ID="friens" />
    </div>
</asp:Content>
