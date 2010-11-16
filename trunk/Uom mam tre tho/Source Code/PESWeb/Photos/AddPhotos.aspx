<%@ Page Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true"
    CodeBehind="AddPhotos.aspx.cs" Inherits="PESWeb.Photos.AddPhotos" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <div class="grid_20">
        <div id="title">
            <h1>
                Album mới - Đăng ảnh</h1>
        </div>
        <div id="photos">
            <table class="photo-grid">
                <tr>
                    <td>
                        <div class="mb info">
                            <%=Resources.PESResources.uploadImagedetail%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div>
                            <object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0"
                                width="550" height="400" id="FileUpload" align="middle">
                                <param name="allowScriptAccess" value="sameDomain" />
                                <param name="movie" value="../Files/FileUpload.swf?SiteRoot=<%Response.Write(_webContext.RootUrl);%>&AlbumID=<%Response.Write(_webContext.AlbumID.ToString()); %>&FileType=<%Response.Write(((int)Folder.Types.Picture).ToString()); %>&AccountID=<%Response.Write(_webContext.CurrentUser.AccountID.ToString()); %>" />
                                <param name="quality" value="high" />
                                <param name="bgcolor" value="#ffffff" />
                                <embed src="../Files/FileUpload.swf?SiteRoot=<%Response.Write(_webContext.RootUrl);%>&AlbumID=<%Response.Write(_webContext.AlbumID.ToString()); %>&FileType=<%Response.Write(((int)Folder.Types.Picture).ToString()); %>&AccountID=<%Response.Write(_webContext.CurrentUser.AccountID.ToString()); %>"
                                    quality="high" bgcolor="#ffffff" width="550" height="220" name="FileUpload" align="middle"
                                    allowscriptaccess="sameDomain" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" />
                            </object>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="form_submit_right">
                            <asp:LinkButton ID="lbViewAlbum" CssClass="button green" OnClick="lbViewAlbum_Click"
                                runat="server">Xem album</asp:LinkButton>
                            <asp:LinkButton ID="lbEditPhotos" CssClass="button green" OnClick="lbEditPhotos_Click"
                                runat="server">Chỉnh sửa album</asp:LinkButton>
                        </div>
                        .
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
