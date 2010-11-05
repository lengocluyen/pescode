<%@ Page Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true"
    CodeBehind="MyPosts.aspx.cs" Inherits="PESWeb.Blogs.MyPosts" %>

<%@ Register Src="~/UserControls/Friends.ascx" TagPrefix="PES" TagName="Friends" %>
<%@ Register TagPrefix="PES" Namespace="PESWeb" Assembly="PESWeb" %>
<asp:Content ContentPlaceHolderID="Content" runat="server">
    <div class="grid_10">
        <div class="page-heading hr">
            <h2>
                Blogs của tôi</h2>
        </div>
        <table width="100%">
            <tr>
                <td>
                    <asp:ListView ID="lvBlogs" runat="server" OnItemDataBound="lvBlogs_ItemDataBound">
                        <LayoutTemplate>
                            <ul class="blogsList">
                                <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                            </ul>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <li>
                                <h2 class="blogsTitle">
                                    <asp:HyperLink ID="linkTitle" runat="server" Text='<%#((Blog)Container.DataItem).Title %>'></asp:HyperLink></h2>
                                <p class="blogsDescription">
                                    <asp:LinkButton ID="lbEdit" runat="server" CssClass="blogsActionLink"
                                        OnClick="lbEdit_Click">Chỉnh sửa</asp:LinkButton>
                                    -
                                    <asp:LinkButton ID="lbDelete" runat="server"  CssClass="blogsActionLink"
                                        OnClick="lbDelete_Click">Xóa</asp:LinkButton><br />
                                    Ngày tạo:
                                    <%#((Blog)Container.DataItem).CreateDate %>
                                    Người đăng:
                                    <%#Account.GetAccountByID(((Blog)Container.DataItem).AccountID).Username %><br />
                                    <%#((Blog)Container.DataItem).Subject %><asp:Literal Visible="false" ID="litBlogID"
                                        runat="server" Text='<%#((Blog)Container.DataItem).BlogID %>'></asp:Literal>
                                    <asp:Literal ID="litPageName" runat="server" Visible="false" Text='<%#((Blog)Container.DataItem).PageName %>'></asp:Literal>
                                    <asp:Literal ID="litUsername" runat="server" Visible="false" Text='<%#Account.GetAccountByID(((Blog)Container.DataItem).AccountID).Username %>'></asp:Literal>
                                </p>
                            </li>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            Bạn chưa đăng bài Blogs nào!
                        </EmptyDataTemplate>
                    </asp:ListView>
                </td>
            </tr>
            <tr>
                <td><center>
                    <PES:Pager ID="pager" runat="server" /></center>
                </td>
            </tr>
        </table>
    </div>
    <div class="grid_3" style="margin-top: 35px">
        <div class="box">
            <PES:Friends runat="server" ID="friens" />
        </div>
    </div>
</asp:Content>
