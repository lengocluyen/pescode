<%@ Page Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true"
    CodeBehind="MyPhotos.aspx.cs" Inherits="PESWeb.Photos.MyPhotos" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <div class="grid_18">
        <div id="title">
            <h1>
                Ảnh của tôi</h1>
        </div>
        <div class="clear">
        </div>
        <div id="photos">
            <asp:ListView ID="lvAlbums" GroupItemCount="4" runat="server" OnItemDataBound="lbAlbums_ItemDataBound">
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
                        <asp:HyperLink CssClass="albumsActionLink" ID="linkEditAlbum" NavigateUrl="~/Photos/EditAlbum.aspx"
                            Text="Chỉnh sửa" runat="server"></asp:HyperLink>
                        -
                        <asp:HyperLink CssClass="albumsActionLink" ID="linkViewAlbum" NavigateUrl="~/Photos/ViewAlbum.aspx"
                            Text="Xem" runat="server"></asp:HyperLink>
                        -
                        <asp:LinkButton CssClass="albumsActionLink" ID="linkDeleteAlbum" Text="Xóa" OnClick="linkDeleteAlbum_Click"
                            runat="server"></asp:LinkButton><br />
                        <asp:Label CssClass="albumsTitle" ID="lblName" Text='<%#((Folder)Container.DataItem).Name %>'
                            runat="server"></asp:Label><br />
                        <img src="<%#_webContext.RootUrl %>files/photos/<%#((Folder)Container.DataItem).FullPathToCoverImage %>" /><br />
                        <asp:Label CssClass="albumsLocation" Text="ở - " runat="server"></asp:Label>
                        <asp:Label CssClass="albumsLocation" ID="lblLocation" Text='<%#((Folder)Container.DataItem).Location %>'
                            runat="server"></asp:Label><br />
                        <asp:Label CssClass="albumsDescription" ID="lblDescription" Text='<%#((Folder)Container.DataItem).Description %>'
                            runat="server"></asp:Label>
                        <asp:Literal Visible="false" ID="litFolderID" Text='<%#((Folder)Container.DataItem).FolderID.ToString() %>'
                            runat="server"></asp:Literal>
                    </td>
                </ItemTemplate>
                <EmptyDataTemplate>
                    Bạn hiện không có hình ảnh nào!
                </EmptyDataTemplate>
            </asp:ListView>
        </div>
</asp:Content>
