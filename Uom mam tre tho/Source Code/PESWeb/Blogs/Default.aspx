<%@ Page Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="PESWeb.Blogs.Default" %>

<%@ Register Src="~/UserControls/Friends.ascx" TagPrefix="PES" TagName="Friends" %>
<%@ Register TagPrefix="PES" Namespace="PESWeb" Assembly="PESWeb" %>
<asp:Content ContentPlaceHolderID="Content" runat="server">
    <div class="grid_10">
        <div class="page-heading hr">
            <h2>
                Blogs</h2>
        </div>
        <asp:UpdatePanel ID="upListView" runat="server">
            <ContentTemplate>
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
                                            Ngày tạo:
                                            <%#((Blog)Container.DataItem).CreateDate %>
                                            Người đăng:
                                            <%#Account.GetAccountByID(((Blog)Container.DataItem).AccountID).Username %><br />
                                            <%#((Blog)Container.DataItem).Subject %><asp:Literal ID="litBlogID" runat="server"
                                                Text='<%#((Blog)Container.DataItem).BlogID %>'></asp:Literal>
                                            <asp:Literal ID="litPageName" runat="server" Visible="false" Text='<%#((Blog)Container.DataItem).PageName %>'></asp:Literal>
                                            <asp:Literal ID="litUsername" runat="server" Visible="false" Text='<%#Account.GetAccountByID(((Blog)Container.DataItem).AccountID).Username %>'></asp:Literal>
                                        </p>
                                    </li>
                                </ItemTemplate>
                                <EmptyDataTemplate>
                                    Bạn chưa đăng bài blogs nào!
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
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="grid_3" style="margin-top: 35px">
        <div class="box">
            <PES:Friends runat="server" ID="friens" />
        </div>
    </div>
</asp:Content>
