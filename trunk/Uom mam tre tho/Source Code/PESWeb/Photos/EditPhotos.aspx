<%@ Page Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true"
    CodeBehind="EditPhotos.aspx.cs" Inherits="PESWeb.Photos.EditPhotos" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <div class="grid_19">
        <div id="title">
            <h1>
                Sửa hình ảnh</h1>
        </div>
        <div class="clear">
        </div>
        <div id="photos">
            <div class="title">
                <h2>
                    Ablum ảnh của bạn</h2>
            </div>
            <asp:ListView ID="lvAlbums" GroupItemCount="2" runat="server" OnItemDataBound="lbPhotos_ItemDataBound">
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
                        <asp:Label Style="font-weight: bold;" ID="lblFileName" runat="server" Text='<%#((File)Container.DataItem).FileName %>'></asp:Label><br />
                        <table width="300" cellpadding="0" cellspacing="0">
                            <tr>
                                <td valign="top">
                                    Mô tả:<br />
                                    <asp:TextBox ID="txtDescription" TextMode="MultiLine" Columns="10" Rows="7" runat="server"
                                        Text='<%#((File)Container.DataItem).Description %>'></asp:TextBox>
                                </td>
                                <td valign="top">
                                    <asp:HyperLink ID="linkImage" runat="server" NavigateUrl='<%#((File)Container.DataItem).CreateDate.Year.ToString() + ((File)Container.DataItem).CreateDate.Month.ToString() %>'></asp:HyperLink>
                                    <asp:Literal Visible="false" ID="litFileSystemName" runat="server" Text='<%#((File)Container.DataItem).FileSystemName.ToString() %>'></asp:Literal>
                                    <asp:Literal Visible="false" ID="litFileID" runat="server" Text='<%#((File)Container.DataItem).FileID.ToString() %>'></asp:Literal>
                                    <asp:Literal Visible="false" ID="litFileExtension" runat="server" Text='<%#((File)Container.DataItem).Extension %>'></asp:Literal>
                                </td>
                            </tr>
                        </table>
                    </td>
                </ItemTemplate>
                <EmptyDataTemplate>
                    Bạn hiện không có hình ảnh nào!
                </EmptyDataTemplate>
            </asp:ListView>
            <asp:Button ID="btnSave" runat="server" CssClass="button gray" Text="Lưu" OnClick="btnSave_Click" />
            <asp:Button ID="btnBack" runat="server" CssClass="button gray" Text="Trở lại" OnClick="btnBack_Click" />
        </div>
</asp:Content>
