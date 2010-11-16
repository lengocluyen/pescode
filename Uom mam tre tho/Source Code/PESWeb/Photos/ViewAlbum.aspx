<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/SiteMaster.Master"
    AutoEventWireup="true" CodeBehind="ViewAlbum.aspx.cs" Inherits="PESWeb.Photos.ViewAlbum" %>

<%@ Register Src="~/UserControls/Ratings.ascx" TagName="Ratings" TagPrefix="PES" %>
<%@ Register Src="~/UserControls/Tags.ascx" TagName="Tags" TagPrefix="PES" %>
<%@ Register Src="~/UserControls/Comments.ascx" TagName="Comments" TagPrefix="PES" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div class="grid_20">
        <div id="title">
            <div class="widthline">
                <h1>
                    Album Ảnh:
                    <asp:Label ID="lblAlbumName" runat="server" /></h1>
                <h2>
                    <div id="desc">
                        Địa điểm:
                        <asp:Label ID="lblLocation" runat="server"></asp:Label><br />
                        <asp:Label ID="lblDescription" runat="server"></asp:Label>
                    </div>
                </h2>
            </div>
        </div>
        <div class="clear">
        </div>
        <div class="toolbar">
            <div class="buttons">
                <div class="alignleft">
                </div>
                <div class="alignright">
                    <asp:Button ID="btnAddPhotos" CssClass="button gray" runat="server" Text="Thêm hình ảnh"
                        OnClick="lbAddPhotos_Click"></asp:Button>
                    <asp:Button ID="btnEditPhotos" CssClass="button gray" runat="server" Text="Chỉnh sửa hình ảnh"
                        OnClick="lbEditPhotos_Click"></asp:Button>
                    <asp:Button ID="btnEditAlbum" runat="server" CssClass="button gray" Text="Chỉnh sửa album"
                        OnClick="lbEditAlbum_Click"></asp:Button>
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
        <div id="photos">
            <asp:ListView GroupItemCount="4" ID="lvGallery" runat="server" OnItemDataBound="lvAlbum_ItemDataBound">
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
                        <asp:HyperLink ID="lnkImage" NavigateUrl='<%#((File)Container.DataItem).CreateDate.Year.ToString() + ((File)Container.DataItem).CreateDate.Month.ToString() %>'
                            runat="server">
                            <div class="pg-album">
                                <asp:Image ID="Image" runat="server" />
                            </div>
                        </asp:HyperLink>
                        <div class="pg-detail">
                            <div class="pg-name">
                                <asp:HyperLink ID="lnkView" runat="server" />
                            </div>
                        </div>
                        <asp:Label ID="lblDescription" runat="server" Text='<%#((File)Container.DataItem).Description %>'></asp:Label>
                    </td>
                </ItemTemplate>
                <EmptyItemTemplate>
                </EmptyItemTemplate>
            </asp:ListView>
            <div style="margin:10px 0">
                <PES:Tags ID="Tags1" runat="server" SystemObjectID="8"
                    Display="ShowCloudAndTagBox" />
            </div>
            <div class="alignleft">
                <div class="post-text">
                    <div class="body">
                    </div>
                    <div class="meta">
                        Ngày tạo:
                        <asp:Label ID="lblCreateDate" runat="server"></asp:Label>
                        - <a href="#" id='respondlink-<%=albumID %>' class="respondlink">Cảm nhận</a>
                    </div>
                    <PES:Comments ID="comments" SystemObject="Album" runat="server" />
                </div>
            </div>
          
        </div>
    </div>
</asp:Content>
