<%@ Page Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true"
    CodeBehind="Tags.aspx.cs" Inherits="PESWeb.Tags.Tags" %>

<asp:Content runat="server" ContentPlaceHolderID="Content">
    <div class="grid_19">
        <div id="title">
            <h1>
                Bảng từ khóa</h1>
        </div>
        <table class="tag-list">
            <tr>
                <td colspan="2">
                    <b>Tài Khoản</b>
                </td>
            </tr>
            <asp:Repeater ID="repAccounts" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr>
                <td colspan="2">
                    <b>Thông tin cá nhân</b>
                </td>
            </tr>
            <asp:Repeater ID="repProfiles" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr>
                <td colspan="2">
                    <b>Blogs</b>
                </td>
            </tr>
            <asp:Repeater ID="repBlogs" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr>
                <td colspan="2">
                    <b>Bài đăng</b>
                </td>
            </tr>
            <asp:Repeater ID="repPosts" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr>
                <td colspan="2">
                    <b>Files</b>
                </td>
            </tr>
            <asp:Repeater ID="repFiles" runat="server">
                <ItemTemplate>
                    <tr>
                        <td class="label">
                            <%#((SystemObjectTagWithObjects)Container.DataItem).File.FileName %>
                        </td>
                        <td>
                            <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# "Xem album: " + ((SystemObjectTagWithObjects)Container.DataItem).Folder.Name %>'
                                NavigateUrl='<%# "~/photos/ViewAlbum.aspx?AlbumID=" + ((SystemObjectTagWithObjects)Container.DataItem).File.DefaultFolderID %>'></asp:HyperLink>
                            <asp:HyperLink ID="HyperLink2" runat="server" Text='<%# "Xem hình ảnh: " + ((SystemObjectTagWithObjects)Container.DataItem).File.FileName %>'
                                NavigateUrl='<%#"~/photos/viewview.aspx?FileID=" + ((SystemObjectTagWithObjects)Container.DataItem).File.FileID %>'></asp:HyperLink>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr>
                <td colspan="2">
                    <b>Nhóm</b>
                </td>
            </tr>
            <asp:Repeater ID="repGroups" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
</asp:Content>
