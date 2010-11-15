<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/SiteMaster.Master"
    AutoEventWireup="true" CodeBehind="ViewAlbum.aspx.cs" Inherits="PESWeb.Photos.ViewAlbum" %>

<%@ Register Src="~/UserControls/Ratings.ascx" TagName="Ratings" TagPrefix="PES" %>
<%@ Register Src="~/UserControls/Tags.ascx" TagName="Tags" TagPrefix="PES" %>
<%@ Register Src="~/UserControls/Comments.ascx" TagName="Comments" TagPrefix="PES" %>

<script runat="server">

    protected void btnAddPhotos_Click(object sender, EventArgs e)
    {

    }
</script>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <div class="grid_18">
        <div id="title">
            <div class="widthline">
                <h1>
                    Album Ảnh:
                    <asp:Label ID="lblAlbumName" runat="server" /></h1>
                <br />
                <br />
                <h2>
                    Địa điểm:
                    <asp:Label ID="lblLocation" runat="server"></asp:Label><br />
                    <asp:Label ID="lblDescription" runat="server"></asp:Label>
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
                    <%--<a href="#">< Trước</a> | <a href="#">Sau ></a>--%>
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
        <div id="photos">
            <asp:ListView GroupItemCount="4" ID="lvGallery" runat="server" OnItemDataBound="lvAlbum_ItemDataBound">
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
                        <asp:Label Style="font-weight: bold;" ID="lblFileName" Text='<%#((File)Container.DataItem).FileName %>'
                            runat="server"></asp:Label>
                         <asp:HyperLink ID="lnkImage"  NavigateUrl='<%#((File)Container.DataItem).CreateDate.Year.ToString() + ((File)Container.DataItem).CreateDate.Month.ToString() %>' runat="server">
                                <div class="pg-album">
                                    <asp:Image ID="Image" runat="server" />
                                </div>
                            </asp:HyperLink>
                        <asp:Literal Visible="false" ID="litImageName" runat="server" Text='<%#((File)Container.DataItem).FileSystemName.ToString() %>'></asp:Literal>
                        <asp:Literal Visible="false" ID="litFileExtension" runat="server" Text='<%# ((File)Container.DataItem).Extension.ToString() %>'></asp:Literal><br />
                        <asp:Label ID="lblDescription" runat="server" Text='<%#((File)Container.DataItem).Description %>'></asp:Label>
                        <asp:Literal Visible="false" ID="litFileID" Text='<%#((File)Container.DataItem).FileID %>'
                            runat="server"></asp:Literal>
                    </td>
                </ItemTemplate>
                <EmptyItemTemplate>
                    <%-- Không có hình ảnh nào trong album.
                    <asp:HyperLink ID="linkAddPhotos" runat="server" Text="Click here to add photos"></asp:HyperLink>.--%>
                </EmptyItemTemplate>
            </asp:ListView>
            <PES:Tags ID="Tags1" runat="server" SystemObjectID="8" SystemObjectRecordID='<%#this._webContext.AlbumID %>'
                Display="ShowCloudAndTagBox" />
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
</asp:Content>
