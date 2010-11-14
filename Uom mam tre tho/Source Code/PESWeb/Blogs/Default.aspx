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
                <a href="#" class="button gray">Viết Blogs</a>
            </div>
            <%--<div id="desc">
                <div class="alignleft">
                    By <a href="#">Cuong Do</a>
                </div>
            </div>--%>
        </div>
        <div class="clear">
        </div>
        <div id="photos">
            <asp:ListView ID="lvBlogs" GroupItemCount="3" runat="server" OnItemDataBound="lvBlogs_ItemDataBound">
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
                            Ngày tạo:
                            <%#((Blog)Container.DataItem).CreateDate %><br />
                            Người đăng:
                            <%#Account.GetAccountByID(((Blog)Container.DataItem).AccountID).Username %><br />
                            <%#((Blog)Container.DataItem).Subject %><asp:Literal ID="litBlogID" runat="server"
                                Text='<%#((Blog)Container.DataItem).BlogID %>'></asp:Literal>
                            <asp:Literal ID="litPageName" runat="server" Visible="false" Text='<%#((Blog)Container.DataItem).PageName %>'></asp:Literal>
                            <asp:Literal ID="litUsername" runat="server" Visible="false" Text='<%#Account.GetAccountByID(((Blog)Container.DataItem).AccountID).Username %>'></asp:Literal>
                        </p>
                    </td>
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
    </div>
    <div class="grid_5" style="margin-top: 35px">
        <PES:Friends runat="server" ID="friens" />
    </div>
</asp:Content>
