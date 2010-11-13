<%@ Page Title="" Language="C#" MasterPageFile="~/AuthMaster.Master" AutoEventWireup="true"
    CodeBehind="ConfirmFriendInSite.aspx.cs" Inherits="PESWeb.Friends.ConfirmFriendInSite" %>

<asp:Content ID="Content6" ContentPlaceHolderID="Content" runat="server">
    <div>
        <div class="page-heading">
            <h2 id="page-heading">
                Mời kết bạn</h2>
        </div>
    </div>
    <div>
        <asp:Panel ID="pnlConfirm" runat="server">
            Kết bạn thành công!
            <%--<div class="divContainerRow" style="height: 105px;">
                <div class="divContainerCellHeader">
                    <asp:Image Width="100" Height="100" ID="imgProfileAvatar" runat="server" />
                    
                </div>
                <div class="divContainerCell">
                    <asp:Label ID="lblFullName" runat="server"></asp:Label>&nbsp;bạn của bạn trên&nbsp;
                    <asp:Label ID="lblSiteName1" runat="server"></asp:Label> mời bạn: 
                    <hr />
                    Gia nhập
                    <asp:Label ID="lblSiteName2" runat="server"></asp:Label>
                    để kết nối tới bạn của bạn để có thể chia sẽ những tâm sự, hình ảnh... Nếu đã có
                    có tài khoản 
                    <asp:LinkButton ID="lbLogin" runat="server" OnClick="lbLogin_Click" Text="Đăng nhập "></asp:LinkButton>
                    hoặc
                    <asp:LinkButton ID="lbCreateAccount" runat="server" OnClick="lbCreateAccount_Click"
                        Text="Đăng ký "></asp:LinkButton>
                    để tạo tài khoản.
                </div>
            </div>--%>
        </asp:Panel>
        <asp:Panel ID="pnlError" runat="server">
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        </asp:Panel>
    </div>
</asp:Content>
