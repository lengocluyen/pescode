<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/SiteMaster.Master"
    AutoEventWireup="true" CodeBehind="Post.aspx.cs" Inherits="PESWeb.Blogs.Post" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../ckeditor/ckeditor.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ContentPlaceHolderID="Content" runat="server">
    <div class="grid_19">
        <div id="title">
            <h1>
                Viết Blogs</h1>
        </div>
        <div class="clear">
        </div>
        <div class="mb error" runat="server" id="pnlMessage" visible="false">
            <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
        </div>
        <div class="comment-form">
            <div class="form-input">
                <label class="label">
                    Tên blogs:</label>
                <asp:TextBox Width="70%" ID="txtTitle" runat="server"></asp:TextBox></div>
            <div class="form-input">
                <label class="label">
                    Tên trang:</label>
                <asp:TextBox Width="70%" ID="txtPageName" runat="server"></asp:TextBox>
            </div>
            <div class="form-input">
                <label class="label">
                    Chủ đề:</label>
                <asp:TextBox Width="70%" ID="txtSubject" runat="server" TextMode="MultiLine" Rows="3"></asp:TextBox>
            </div>
            <div class="form-input">
                <label class="label">
                    Công khai:</label>
                <asp:CheckBox ID="chkIsPublished" runat="server"></asp:CheckBox>
            </div>
            <div class="form-input">
                <textarea id="txtMessage" name="txtMessage" cols="92" rows="50" runat="server" />
                <asp:Literal ID="litBlogID" runat="server" Visible="false"></asp:Literal>
            </div>
            <div class="form-submit form_submit_right" style="margin-top: 10px;">
                <asp:Button ID="btnSave" CssClass="button green" runat="server" Text="Lưu" OnClick="btnSave_Click" />
            </div>
        </div>
</asp:Content>
