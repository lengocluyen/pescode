<%@ Page Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="PESWeb.Photos.Default" %>

<%@ Register Src="~/UserControls/Friends.ascx" TagPrefix="PES" TagName="Friends" %>
<asp:Content ContentPlaceHolderID="Content" runat="server">
    <div class="grid_15">
        <div id="title">
            <h1>
                Xem Album</h1>
            <div class="alignright">
                <a href="#" class="button gray">Đăng ảnh</a>
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
            <asp:ListView ID="lvAlbums" GroupItemCount="3" runat="server" OnItemDataBound="lbAlbums_ItemDataBound">
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
                    <td style="width: 10px;">
                    </td>
                    <td>
                        <div class="pg-wrapper">
                            <asp:HyperLink ID="linkGallery" runat="server" /></div>
                        <br />
                        <asp:Label CssClass="albumsTitle" ID="lblName" Text='<%#((Folder)Container.DataItem).Name %>'
                            runat="server"></asp:Label>&nbsp;(<asp:Label CssClass="albumsTitle" ID="alCountphoto"
                                Text='' runat="server"></asp:Label>)<br />
                        <asp:HyperLink CssClass="albumsAuthor" ID="linkAuthor" Text='<%#((Folder)Container.DataItem).Username %>'
                            runat="server"></asp:HyperLink><br />
                        <%-- <asp:Label ID="Label1" CssClass="albumsLocation" Text="ở - " runat="server"></asp:Label>
                     <asp:Label CssClass="albumsLocation" ID="lblLocation" Text='<%#((Folder)Container.DataItem).Location %>'
                            runat="server"></asp:Label><br />
                        <asp:Label CssClass="albumsDescription" ID="lblDescription" Text='<%#((Folder)Container.DataItem).Description %>'
                            runat="server"></asp:Label>--%>
                        <asp:Literal Visible="false" ID="litFolderID" Text='<%#((Folder)Container.DataItem).FolderID.ToString() %>'
                            runat="server"></asp:Literal>
                        <asp:Literal Visible="false" ID="litFullPath" Text='<%#((Folder)Container.DataItem).FullPathToCoverImage %>'
                            runat="server"></asp:Literal>
                    </td>
                    <td style="width: 10px;">
                    </td>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <%=Resources.PESResources.notImageUpload%>
                </EmptyDataTemplate>
            </asp:ListView>
        </div>
    </div>
    <PES:Friends runat="server" ID="friens" />
</asp:Content>
