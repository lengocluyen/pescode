<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true"
    CodeBehind="ManagePrivacy.aspx.cs" Inherits="PESWeb.Profiles.ManagePrivacy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div class="grid_15">
        <div id="title">
            <h1>
                Cài đặt quyền riêng tư</h1>
        </div>
        <div class="clear">
        </div>
        <div class="mb blue">
            Bạn hãy sử dụng các cài đặt bên dưới để kiểm quyền truy cập hoặc xem thông tin trên
            trang cá nhân của bạn.
        </div>
        <div class="clear">
        </div>
        <div class="profile">
            <div class="title">
                <h2>
                    Thông tin cá nhân</h2>
            </div>
            <div class="post">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" CssClass="message" />
                <div class="divContainerRow">
                    <asp:PlaceHolder ID="phPrivacyFlagTypes" runat="server"></asp:PlaceHolder>
                </div>
                <div class="divContainerRow">
                    <div class="divContainerCellHeader">
                        &nbsp;
                    </div>
                    <div class="divContainerCell">
                        <asp:Button ID="btnSave" runat="server" Text="Lưu" CssClass="button green" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
