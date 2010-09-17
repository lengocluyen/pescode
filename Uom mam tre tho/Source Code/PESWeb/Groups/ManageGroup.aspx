<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/SiteMaster.Master"
    AutoEventWireup="true" CodeBehind="ManageGroup.aspx.cs" Inherits="PESWeb.Groups.ManageGroup" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Groups" runat="server">
<div style="padding-left:10px;">
    <ul class="menu1">
        <li><a href="/Groups/ManageGroup.aspx">
            <img src="/images/mnu01.gif" alt="" />Groups mới</a></li>
        <li><a href="/Groups/mygroups.aspx">
            <img src="/images/mnu01.gif" alt="" />Groups của tôi</a></li>
    </ul>
</div>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="Content">
    <div class="grid_10">
        <div class="page-heading hr">
            <h2>
                Quản Lý Groups</h2>
        </div>
        <div class="divContainerRow">
            <asp:Label ID="lblMessage" ForeColor="Red" runat="server"></asp:Label>
            <div class="divContainerCellHeader">
                Tên:
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtName" ErrorMessage="*"
                    ForeColor="Red"></asp:RequiredFieldValidator></div>
            <div class="divContainerCell">
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox></div>
            <div class="divContainerCellHeader">
                Công khai:</div>
            <div class="divContainerCell">
                <asp:CheckBox ID="chkIsPublic" runat="server" /></div>
            <div class="divContainerCellHeader">
                Tên Trang:<asp:RequiredFieldValidator runat="server" ControlToValidate="txtPageName"
                    ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator></div>
            <div class="divContainerCell">
                <asp:TextBox ID="txtPageName" runat="server"></asp:TextBox></div>
            <div class="divContainerCellHeader">
                Logo:</div>
            <div class="divContainerCell">
                <asp:FileUpload ID="fuLogo" runat="server" /></div>
            <div class="divContainerCell">
                <asp:Image ID="imgLogo" runat="server" /></div>
            <div class="divContainerCellHeader">
                Mô tả:<asp:RequiredFieldValidator runat="server" ControlToValidate="txtDescription"
                    ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator></div>
            <div class="divContainerCell">
                &nbsp;</div>
            <textarea id="txtDescription" name="txtDescription" cols="92" rows="20" runat="server" />
            <div class="divContainerCell"><div style="font-size:10px;color:#FF0000;"></div>Được công khai.</div>
            <div class="divContainerCellHeader">
                Nội Dung:<asp:RequiredFieldValidator runat="server" ControlToValidate="txtBody" ErrorMessage="*"
                    ForeColor="Red"></asp:RequiredFieldValidator></div>
            <div class="divContainerCell">
                &nbsp;</div>
            <div class="divContainerCell">
                <textarea id="txtBody" name="txtBody" cols="92" rows="20" runat="server" />
                <div class="divContainerCell"><div style="font-size:10px;color:#FF0000;">Chỉ thành viên mới thấy nội dung này.</div></div>
                <div class="divContainerCellHeader">
                    Loại Groups:</div>
                <div class="divContainerCell">
                    <asp:ListBox ID="lbGroupTypes" runat="server" SelectionMode="Multiple"></asp:ListBox>
                </div>
                <asp:Literal Visible="false" ID="litGroupID" runat="server" Text="0"></asp:Literal>
                <asp:Literal Visible="false" ID="litAccountID" runat="server"></asp:Literal>
                <asp:Literal Visible="false" ID="litCreateDate" runat="server"></asp:Literal>
                <asp:Literal Visible="false" ID="litUpdateDate" runat="server"></asp:Literal>
                <asp:Literal Visible="false" ID="litMemberCount" runat="server"></asp:Literal>
                <asp:Literal Visible="false" ID="litTimestamp" runat="server"></asp:Literal>
                <asp:Literal Visible="false" ID="litFileID" Text="0" runat="server"></asp:Literal>
            </div>
            <div class="divContainerFooter">
                <asp:Button ID="btnSubmit" Text="Submit" CssClass="button" OnClick="btnSubmit_Click"
                    runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../ckeditor/ckeditor.js" type="text/javascript"></script>

</asp:Content>
