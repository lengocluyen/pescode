﻿<%@ Page Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="MyPhotos.aspx.cs" Inherits="PESWeb.Photos.MyPhotos" %>


<asp:Content ContentPlaceHolderID="Content" runat="server">
     <div class="grid_10">
        <div class="page-heading hr">
            <h2>
                Ảnh của tôi</h2>
        </div>
            <div class="divContainerRow">
                <table width="100%"><tr><td>
                <asp:ListView id="lvAlbums" runat="server" OnItemDataBound="lbAlbums_ItemDataBound">
                    <LayoutTemplate>
                        <ul class="albumsList">
                            <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                        </ul>
                    </LayoutTemplate>
                    
                    <ItemTemplate>
                        <li>
                            <asp:HyperLink CssClass="albumsActionLink" ID="linkEditAlbum" NavigateUrl="~/Photos/EditAlbum.aspx" Text="Chỉnh sửa" runat="server"></asp:HyperLink> -
                            <asp:HyperLink CssClass="albumsActionLink" ID="linkViewAlbum" NavigateUrl="~/Photos/ViewAlbum.aspx" Text="Xem" runat="server"></asp:HyperLink> -
                            <asp:LinkButton CssClass="albumsActionLink" ID="linkDeleteAlbum" Text="Xóa" OnClick="linkDeleteAlbum_Click" runat="server"></asp:LinkButton><br />
                            <asp:Label CssClass="albumsTitle" ID="lblName" Text='<%#((Folder)Container.DataItem).Name %>' runat="server"></asp:Label><br />
                            <img src="<%#_webContext.RootUrl %>files/photos/<%#((Folder)Container.DataItem).FullPathToCoverImage %>" /><br />
                            <asp:Label CssClass="albumsLocation" Text="ở - " runat="server"></asp:Label>
                            <asp:Label CssClass="albumsLocation" ID="lblLocation" Text='<%#((Folder)Container.DataItem).Location %>' runat="server"></asp:Label><br />
                            <asp:Label CssClass="albumsDescription" ID="lblDescription" Text='<%#((Folder)Container.DataItem).Description %>' runat="server"></asp:Label>
                            <asp:Literal Visible="false" ID="litFolderID" Text='<%#((Folder)Container.DataItem).FolderID.ToString() %>' runat="server"></asp:Literal>
                        </li>
                    </ItemTemplate>
                    
                    <EmptyDataTemplate>
                        Bạn hiện không có hình ảnh nào!
                    </EmptyDataTemplate>
                </asp:ListView>
                </td></tr></table>
            </div>
    </div>
</asp:Content>