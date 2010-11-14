<%@ Page Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true"
    CodeBehind="MyPosts.aspx.cs" Inherits="PESWeb.Blogs.MyPosts" %>

<%@ Register Src="~/UserControls/Friends.ascx" TagPrefix="PES" TagName="Friends" %>
<%@ Register TagPrefix="PES" Namespace="PESWeb" Assembly="PESWeb" %>
<asp:Content ContentPlaceHolderID="Content" runat="server">
    <div class="grid_15">
        <div id="title">
            <h1>
                Blogs của tôi</h1>
            <div class="alignright">
                <a href="#" class="button gray">Viết Blogs</a>
            </div>
        </div>
        <div class="clear">
        </div>
        <div id="photos">
            <asp:ListView ID="lvBlogs" runat="server" GroupItemCount="4" OnItemDataBound="lvBlogs_ItemDataBound">
                <LayoutTemplate>
                    <asp:PlaceHolder ID="groupPlaceholder" runat="server"></asp:PlaceHolder>
                </LayoutTemplate>
                <GroupTemplate>
                    <table class="photo-grid">
                        <tr>
                            <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                        </tr>
                    </table>
                </GroupTemplate>
                <ItemTemplate>
                    <td>
                        <h2 class="blogsTitle">
                            <asp:HyperLink ID="linkTitle" runat="server" Text='<%#((Blog)Container.DataItem).Title %>'></asp:HyperLink></h2>
                        <br />
                        <p class="blogsDescription">
                            <asp:LinkButton ID="lbEdit" runat="server" CssClass="blogsActionLink" OnClick="lbEdit_Click">Chỉnh sửa</asp:LinkButton>
                            -
                            <asp:LinkButton ID="lbDelete" runat="server" CssClass="blogsActionLink" OnClick="lbDelete_Click">Xóa</asp:LinkButton><br />
                            Ngày tạo:
                            <%#((Blog)Container.DataItem).CreateDate %><br />
                            Người đăng:
                            <%#Account.GetAccountByID(((Blog)Container.DataItem).AccountID).Username %><br />
                            <%#((Blog)Container.DataItem).Subject %><asp:Literal Visible="false" ID="litBlogID"
                                runat="server" Text='<%#((Blog)Container.DataItem).BlogID %>'></asp:Literal>
                            <asp:Literal ID="litPageName" runat="server" Visible="false" Text='<%#((Blog)Container.DataItem).PageName %>'></asp:Literal>
                            <asp:Literal ID="litUsername" runat="server" Visible="false" Text='<%#Account.GetAccountByID(((Blog)Container.DataItem).AccountID).Username %>'></asp:Literal>
                        </p>
                    </td>
                </ItemTemplate>
                <EmptyDataTemplate>
                    Bạn chưa đăng bài Blogs nào!
                </EmptyDataTemplate>
            </asp:ListView>
        </div>
        <div class="clear">
        </div>
        <div style="text-align: center">
            <PES:Pager ID="pager" runat="server" />
            </center>
        </div>
    </div>
    <div class="grid_3" style="margin-top: 35px">
        <div class="box">
            <PES:Friends runat="server" ID="friens" />
        </div>
    </div>
</asp:Content>
