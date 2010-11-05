<%@ Page Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="EditAlbum.aspx.cs" Inherits="PESWeb.Photos.EditAlbum" %>


<asp:Content ContentPlaceHolderID="Content" runat="server">
    <div class="grid_10">
        <div class="page-heading hr">
            <h2>
                Sửa Album Ảnh</h2>
        </div>
            <div class="divContainerRow">
                <div class="divContainerCellHeader">Tên Album:</div>
                <div class="divContainerCell"><asp:TextBox ID="txtFolderName" runat="server"></asp:TextBox></div>
            </div>
            <div class="divContainerRow">
                <div class="divContainerCellHeader">Địa điểm:</div>
                <div class="divContainerCell"><asp:TextBox ID="txtLocation" runat="server"></asp:TextBox></div>
            </div>
            <div class="divContainerRow">
                <div class="divContainerCellHeader">Mô tả:</div>
                <div class="divContainerCell">
                    <asp:TextBox Columns="30" Rows="4" ID="txtDescription" MaxLength="500" TextMode="MultiLine" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator 
                        ID="txtConclusionValidator1" 
                        ControlToValidate="txtDescription" 
                        Text="500 character limit!" 
                        ValidationExpression="^[\s\S]{0,500}$" 
                        runat="server" />
                </div>
            </div>
            <div class="divContainerFooter">
                <asp:Button ID="btnSave" CssClass="button" runat="server" Text="Lưu" OnClick="btnSave_Click" />
                <asp:Literal ID="litFolderID" runat="server" Visible="false"></asp:Literal>
            </div>
        </div>
</asp:Content>
