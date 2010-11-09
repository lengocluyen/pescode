<%@ Page Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Tags.aspx.cs" Inherits="PESWeb.Tags.Tags" %>

<asp:Content runat="server" ContentPlaceHolderID="Content">
<div class="grid_13">
    <div class="page-heading hr">
	    <h2>Bảng từ khóa</h2>
    </div>
    
    
</div>
  <div class="grid_13">
                <table width="100%">
                    <tr>
                        <td colspan="2"><b>Tài Khoản</b></td>
                    </tr>
                    <asp:Repeater ID="repAccounts" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td></td>
                                <td></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    
                    <tr>
                        <td colspan="2"><b>Thông tin cá nhân</b></td>
                    </tr>
                    <asp:Repeater ID="repProfiles" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td></td>
                                <td></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    
                    <tr>
                        <td colspan="2"><b>Blogs</b></td>
                    </tr>
                    <asp:Repeater ID="repBlogs" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td></td>
                                <td></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    
                    <tr>
                        <td colspan="2"><b>Bài đăng</b></td>
                    </tr>
                    <asp:Repeater ID="repPosts" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td></td>
                                <td></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    
                    <tr>
                        <td colspan="2"><b>Files</b></td>
                    </tr>
                    <asp:Repeater ID="repFiles" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%#((SystemObjectTagWithObjects)Container.DataItem).File.FileName %></td>
                                <td>
                                    <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# "Nhấn để xem album: " + ((SystemObjectTagWithObjects)Container.DataItem).Folder.Name %>' NavigateUrl='<%# "~/photos/ViewAlbum.aspx?AlbumID=" + ((SystemObjectTagWithObjects)Container.DataItem).File.DefaultFolderID %>'></asp:HyperLink> or 
                                    <asp:HyperLink ID="HyperLink2" runat="server" Text='<%# "Nhấn để xem hình ảnh: " + ((SystemObjectTagWithObjects)Container.DataItem).File.FileName %>' NavigateUrl='<%# "~/files/photos/" + ((SystemObjectTagWithObjects)Container.DataItem).File.CreateDate.Year.ToString() + ((SystemObjectTagWithObjects)Container.DataItem).File.CreateDate.Month.ToString() + "/" + ((SystemObjectTagWithObjects)Container.DataItem).File.FileSystemName + "__O." + ((SystemObjectTagWithObjects)Container.DataItem).File.Extension %>'></asp:HyperLink>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    
                    <tr>
                        <td colspan="2"><b>Nhóm</b></td>
                    </tr>
                    <asp:Repeater ID="repGroups" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td></td>
                                <td></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>  

</asp:Content>