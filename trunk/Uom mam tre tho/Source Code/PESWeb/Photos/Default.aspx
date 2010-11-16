<%@ Page Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="PESWeb.Photos.Default" %>

<%@ Register Src="~/UserControls/Friends.ascx" TagPrefix="PES" TagName="Friends" %>
<asp:Content ContentPlaceHolderID="Content" runat="server">
    <div class="grid_14">
        <div id="title">
            <h1>
                Xem Album</h1>
            <div class="alignright">
                <a href="../photos/EditAlbum.aspx" class="button gray">Tạo Album mới</a>
            </div>
            <%--<div id="desc">
                <div class="alignleft">
                    By <a href="#">Cuong Do</a>
                </div>
            </div>--%>
        </div>
        <div class="clear">
        </div>
        <div class="post">
            <div id="photos">
                <asp:ListView ID="lvAlbums" GroupItemCount="3" runat="server" OnItemDataBound="lbAlbums_ItemDataBound">
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
                            <asp:HyperLink ID="lnkImage" runat="server">
                                <div class="pg-album">
                                    <asp:Image ID="Image" runat="server" />
                                </div>
                            </asp:HyperLink>
                            <asp:Label CssClass="albumsTitle" ID="lblName" Text='<%#((Folder)Container.DataItem).Name %>'
                                runat="server"></asp:Label>&nbsp;(<asp:Label CssClass="albumsTitle" ID="alCountphoto"
                                    Text='' runat="server"></asp:Label>)<br />
                            <asp:HyperLink CssClass="albumsAuthor" ID="linkAuthor" Text='<%#((Folder)Container.DataItem).Username %>'
                                runat="server"></asp:HyperLink><br />
                            <asp:Literal Visible="false" ID="litFolderID" Text='<%#((Folder)Container.DataItem).FolderID.ToString() %>'
                                runat="server"></asp:Literal>
                            <asp:Literal Visible="false" ID="litFullPath" Text='<%#((Folder)Container.DataItem).FullPathToCoverImage %>'
                                runat="server"></asp:Literal>
                        </td>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <%=Resources.PESResources.notImageUpload%>
                    </EmptyDataTemplate>
                </asp:ListView>
            </div>
        </div>
    </div>
    <PES:Friends runat="server" ID="friens" />
</asp:Content>
