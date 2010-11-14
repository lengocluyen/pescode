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
                    Ngày tạo:
                    <asp:Label ID="lblCreateDate" runat="server"></asp:Label><br />
                    Địa điểm:
                    <asp:Label ID="lblLocation" runat="server"></asp:Label><br />
                    <asp:Label ID="lblDescription" runat="server"></asp:Label>
                </h2>
            </div>
        </div>
        <div class="clear">
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
                        <asp:HyperLink ID="linkImage" NavigateUrl='<%#((File)Container.DataItem).CreateDate.Year.ToString() + ((File)Container.DataItem).CreateDate.Month.ToString() %>'
                            runat="server"></asp:HyperLink>
                        <asp:Literal Visible="false" ID="litImageName" runat="server" Text='<%#((File)Container.DataItem).FileSystemName.ToString() %>'></asp:Literal>
                        <asp:Literal Visible="false" ID="litFileExtension" runat="server" Text='<%# ((File)Container.DataItem).Extension.ToString() %>'></asp:Literal><br />
                        <asp:Label ID="lblDescription" runat="server" Text='<%#((File)Container.DataItem).Description %>'></asp:Label>
                        <asp:Literal Visible="false" ID="litFileID" Text='<%#((File)Container.DataItem).FileID %>'
                            runat="server"></asp:Literal>
                        <%--<PES:Ratings ID="Ratings1" runat="server" SystemObjectID="5" SystemObjectRecordID='<%#((File)Container.DataItem).FileID %>'/>--%>
                        <%--  <PES:Tags ID="Tags1" runat="server" SystemObjectID="5" SystemObjectRecordID='<%#((File)Container.DataItem).FileID %>' Display="ShowCloudAndTagBox" />
                                <PES:Comments ID="Comments1" runat="server" SystemObjectID="5" SystemObjectRecordID='<%#((File)Container.DataItem).FileID %>' />--%>
                    </td>
                </ItemTemplate>
                <EmptyItemTemplate>
                   <%-- Không có hình ảnh nào trong album.
                    <asp:HyperLink ID="linkAddPhotos" runat="server" Text="Click here to add photos"></asp:HyperLink>.--%>
                </EmptyItemTemplate>
            </asp:ListView>
        </div>
        <asp:Button ID="btnAddPhotos" CssClass="button gray" runat="server" Text="Thêm hình ảnh"
            OnClick="btnAddPhotos_Click" />
        <asp:Button ID="btnEditPhotos" CssClass="button gray" runat="server" Text="Chỉnh sửa hình ảnh"
            OnClick="lbEditPhotos_Click"></asp:Button>
        <asp:Button ID="btnEditAlbum" runat="server" CssClass="button gray" Text="Chỉnh sửa album"
            OnClick="lbEditAlbum_Click"></asp:Button>
    </div>
</asp:Content>
