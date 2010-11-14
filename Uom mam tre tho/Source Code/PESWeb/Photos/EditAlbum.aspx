<%@ Page Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true"
    CodeBehind="EditAlbum.aspx.cs" Inherits="PESWeb.Photos.EditAlbum" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <div class="grid_18">
        <div id="title">
            <h1>
                Sửa Album Ảnh</h1>
        </div>
        <div class="clear">
        </div>
        <div id="photos">
            Tên Album:
            <asp:TextBox ID="txtFolderName" runat="server" Width="318px"></asp:TextBox><br />
            <br />
            Địa điểm:&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtLocation" runat="server" Width="318px"></asp:TextBox><br />
            <br />
            Mô tả:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
            <asp:TextBox Columns="30" Rows="8" ID="txtDescription" Width="375px" MaxLength="500"
                TextMode="MultiLine" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="txtConclusionValidator1" ControlToValidate="txtDescription"
                Text="500 character limit!" ValidationExpression="^[\s\S]{0,500}$" runat="server" /><br />
            <br />
            <asp:Button ID="btnSave" CssClass="button gray" runat="server" Text="Lưu" OnClick="btnSave_Click" />
            <asp:Literal ID="litFolderID" runat="server" Visible="false"></asp:Literal>
        </div>
    </div>
</asp:Content>
