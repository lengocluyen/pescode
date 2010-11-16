<%@ Page Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true"
    CodeBehind="EditAlbum.aspx.cs" Inherits="PESWeb.Photos.EditAlbum" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <div class="grid_12">
        <div id="title">
            <h1>
                Sửa Album Ảnh</h1>
        </div>
        <div class="clear">
        </div>
        <div style="margin-top: 20px">
            <div class="comment-form">
                <div class="form-input">
                    <label class="label">
                        Tên Album</label>
                    <asp:TextBox ID="txtFolderName" runat="server" Width="318px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqFolderName" ControlToValidate="txtFolderName"
                        SetFocusOnError="true" ErrorMessage="*" runat="server" />
                </div>
                <div class="form-input">
                    <label class="label">
                        Địa điểm</label>
                    <asp:TextBox ID="txtLocation" runat="server" Width="318px"></asp:TextBox>
                </div>
                <div class="form-input">
                    <label class="label">
                        Mô tả</label>
                    <asp:TextBox Columns="30" Rows="8" ID="txtDescription" Width="375px" MaxLength="500"
                        TextMode="MultiLine" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="txtConclusionValidator1" ControlToValidate="txtDescription"
                        Text="500 kí tự!" ValidationExpression="^[\s\S]{0,500}$" runat="server" />
                </div>
                <div class="form_submit ">
                    <label class="label">
                        &nbsp;</label>
                    <asp:Button ID="btnSave" CssClass="button green" runat="server" Text="Lưu" OnClick="btnSave_Click" />
                </div>
                <asp:Literal ID="litFolderID" runat="server" Visible="false"></asp:Literal>
            </div>
        </div>
    </div>
</asp:Content>
