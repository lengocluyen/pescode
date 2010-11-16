

<%@ Page Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true"
    CodeBehind="MyPhotos.aspx.cs" Inherits="PESWeb.Photos.MyPhotos" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <div class="grid_20">
        <div id="title">
            <h1>
                Ảnh của tôi</h1>
            <div class="alignright">
                <a href="../photos/myphotos.aspx" class="button gray">Tạo album mới</a>
            </div>
        </div>
        <div class="clear">
        </div>
        <div id="photos">
            <asp:ListView ID="lvAlbums" GroupItemCount="4" runat="server" OnItemDataBound="lbAlbums_ItemDataBound">
                <LayoutTemplate>
                    <table class="photo-grid">
                        <asp:PlaceHolder ID="groupPlaceholder" runat="server"></asp:PlaceHolder>
                    </table>
                </LayoutTemplate>
                <GroupTemplate>
                    <tr>
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                    </tr>
                </GroupTemplate>
                <ItemTemplate>
                    <td>
                        <div class="pg-action">
                            <asp:HyperLink CssClass="albumsActionLink" ID="lnkEdit" Text="Chỉnh sửa" runat="server"></asp:HyperLink>
                            <asp:LinkButton CssClass="albumsActionLink" ID="linkDeleteAlbum" Text="Xóa" OnClick="linkDeleteAlbum_Click"
                                runat="server"></asp:LinkButton>
                        </div>
                        <asp:HyperLink ID="lnkImage" runat="server">
                            <div class="pg-album">
                                <asp:Image ID="Image" runat="server" />
        <div class="post">
            <div id="photos">
                <asp:ListView ID="lvAlbums" GroupItemCount="4" runat="server" OnItemDataBound="lbAlbums_ItemDataBound">
                    <LayoutTemplate>
                        <asp:PlaceHolder ID="groupPlaceholder" runat="server"></asp:PlaceHolder>
                    </LayoutTemplate>
                    <GroupTemplate>
                        <table class="photo-grid">
                            <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                        </table>
                    </GroupTemplate>
                    <ItemTemplate>
                        <td>
                            <div class="pg-action">
                                <asp:HyperLink CssClass="albumsActionLink" ID="lnkEdit" Text="Chỉnh sửa" runat="server"></asp:HyperLink>
                                <asp:LinkButton CssClass="albuActionLink" ID="linkDeleteAlbum" Text="Xóa" OnClick="linkDeleteAlbum_Click"
                                    runat="server"></asp:LinkButton>
                            </div>
                            <asp:HyperLink ID="lnkImage" runat="server">
                                <div class="pg-album">
                                    <asp:Image ID="Image" runat="server" />
                                </div>
                            </asp:HyperLink>
                            <div class="pg-detail">
                                <div class="pg-name">
                                    <asp:HyperLink ID="lnkView" runat="server" />
                                </div>
                            </div>
                        </td>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <div class="mb info">
                            Bạn hiện không có hình ảnh nào!
                        </div>
                    </EmptyDataTemplate>
                </asp:ListView>
            </div>
        </div>
    </div>
</asp:Content>
