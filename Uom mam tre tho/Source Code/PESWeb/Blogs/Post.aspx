<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/SiteMaster.Master"
    AutoEventWireup="true" CodeBehind="Post.aspx.cs" Inherits="PESWeb.Blogs.Post" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <div class="grid_18">
        <div id="title">
            <h1>
                Viết Blogs</h1>
        </div>
        <div class="clear">
        </div>
        <div class="divContainerRow">
            &nbsp;<asp:Label ForeColor="Red" ID="lblErrorMessage" runat="server"></asp:Label></div>
        <div class="divContainerRow">
            <div class="divContainerCellHeader">
                Tên blogs:</div>
            <div class="divContainerCell">
                <asp:TextBox Width="70%" ID="txtTitle" runat="server"></asp:TextBox></div>
        </div>
        <div class="divContainerRow">
            <div class="divContainerCellHeader">
                Chủ đề:</div>
            <div class="divContainerCell">
                <asp:TextBox Width="70%" ID="txtSubject" runat="server"></asp:TextBox></div>
        </div>
        <div class="divContainerRow">
            <div class="divContainerCellHeader">
                Tên trang:</div>
            <div class="divContainerCell">
                <asp:TextBox Width="70%" ID="txtPageName" runat="server"></asp:TextBox></div>
        </div>
        <div class="divContainerRow">
            <div class="divContainerCellHeader">
                Công khai:</div>
            <div class="divContainerCell">
                <asp:CheckBox ID="chkIsPublished" runat="server"></asp:CheckBox></div>
        </div>
        <div class="divContainerRow">
            <div class="divContainerCell" style="padding-left: 20px;">
                <textarea id="txtMessage" name="txtMessage" cols="92" rows="20" runat="server" />
                <asp:Literal ID="litBlogID" runat="server" Visible="false"></asp:Literal>
            </div>
        </div>
        <div class="divContainerFooter">
            <asp:Button ID="btnSave" CssClass="button green" runat="server" Text="Save" OnClick="btnSave_Click" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../ckeditor/ckeditor.js" type="text/javascript"></script>

</asp:Content>
