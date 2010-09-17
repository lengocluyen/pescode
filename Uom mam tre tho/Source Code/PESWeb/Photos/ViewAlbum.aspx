<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ViewAlbum.aspx.cs" Inherits="PESWeb.Photos.ViewAlbum"%>
<%@ Register Src="~/UserControls/Ratings.ascx" TagName="Ratings" TagPrefix="PES" %>
<%@ Register Src="~/UserControls/Tags.ascx" TagName="Tags" TagPrefix="PES" %>
<%@ Register Src="~/UserControls/Comments.ascx" TagName="Comments" TagPrefix="PES" %>

<script runat="server">

    protected void btnAddPhotos_Click(object sender, EventArgs e)
    {

    }
</script>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <div class="grid_10">
        <div class="page-heading hr">
            <h2>
                Album Ảnh: <asp:Label ID="lblAlbumName" runat="server" /></h2>
        </div>
            <div class="divContainerRow">
                Created: <asp:Label ID="lblCreateDate" runat="server"></asp:Label><br />
                Location: <asp:Label ID="lblLocation" runat="server"></asp:Label><br />
                <asp:Label ID="lblDescription" runat="server"></asp:Label>
            </div>
            <div class="divContainerRow">
                <table width="100%"><tr><td>
                    <asp:ListView ID="lvGallery" runat="server" OnItemDataBound="lvAlbum_ItemDataBound">
                        <LayoutTemplate>
                            <ul class="albumsList">
                                <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                            </ul>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <li>
                                
                                <asp:Label style="font-weight:bold;" ID="lblFileName" Text='<%#((File)Container.DataItem).FileName %>' runat="server"></asp:Label>
                                <asp:HyperLink ID="linkImage" NavigateUrl='<%#((File)Container.DataItem).CreateDate.Year.ToString() + ((File)Container.DataItem).CreateDate.Month.ToString() %>' runat="server"></asp:HyperLink>
                                <asp:Literal Visible="false" ID="litImageName" runat="server" Text='<%#((File)Container.DataItem).FileSystemName.ToString() %>'></asp:Literal>
                                <asp:Literal Visible="false" ID="litFileExtension" runat="server" Text='<%# ((File)Container.DataItem).Extension.ToString() %>'></asp:Literal><br />
                                <asp:Label ID="lblDescription" runat="server" Text='<%#((File)Container.DataItem).Description %>'></asp:Label>
                                <asp:Literal Visible="false" ID="litFileID" Text='<%#((File)Container.DataItem).FileID %>' runat="server"></asp:Literal>
                                <PES:Ratings ID="Ratings1" runat="server" SystemObjectID="5" SystemObjectRecordID='<%#((File)Container.DataItem).FileID %>'/>
                                <PES:Tags ID="Tags1" runat="server" SystemObjectID="5" SystemObjectRecordID='<%#((File)Container.DataItem).FileID %>' Display="ShowCloudAndTagBox" />
                                <PES:Comments ID="Comments1" runat="server" SystemObjectID="5" _IDRecord='<%#((File)Container.DataItem).FileID %>' />
                            </li>
                        </ItemTemplate>
                        <EmptyItemTemplate>
                            There are no photos in this gallery!  
                            <asp:HyperLink ID="linkAddPhotos" runat="server" Text="Click here to add photos"></asp:HyperLink>.
                        </EmptyItemTemplate>
                    </asp:ListView>
                </td></tr></table>
            </div>
            <div class="divContainerFooter">
                <asp:Button ID="btnAddPhotos" CssClass="button" runat="server" Text="Add Photos" OnClick="btnAddPhotos_Click" /> 
                <asp:Button ID="btnEditPhotos" CssClass="button" runat="server" Text="Edit Photos" OnClick="lbEditPhotos_Click"></asp:Button> 
                <asp:Button ID="btnEditAlbum" runat="server" CssClass="button" Text="Edit Album" OnClick="lbEditAlbum_Click"></asp:Button>
            </div>
        </div>

</asp:Content>