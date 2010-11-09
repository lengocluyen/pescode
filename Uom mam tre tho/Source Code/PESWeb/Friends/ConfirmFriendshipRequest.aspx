<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ConfirmFriendshipRequest.aspx.cs" Inherits="PESWeb.Friends.ConfirmFriendshipRequest" %>

<asp:Content ID="Content6" ContentPlaceHolderID="Content" runat="server">

<div class="grid_13">
    <div class="page-heading">
	    <h2 id="page-heading">Mời kết bạn</h2>
    </div>
</div>

<div class="grid_9">
<div class="box">
        <asp:Panel ID="pnlConfirm" runat="server">
            <div class="divContainerRow" style="height:105px;">
                <div class="divContainerCellHeader">
                    <asp:Image Width="100" Height="100" ID="imgProfileAvatar" runat="server" />
                </div>
                <div class="divContainerCell">
                    đã là  <asp:Label ID="lblFullName" runat="server"></asp:Label>bạn của bạn trên
                    <asp:Label ID="lblSiteName1" runat="server"></asp:Label>
                    <hr />
                    Gia nhập <asp:Label ID="lblSiteName2" runat="server"></asp:Label> để kết nối 
                    tới bạn của bạn để có thể chia sẽ những tâm sự, hình ảnh... Nếu bạn chưa có tài khoản  
                    <asp:LinkButton ID="lbLogin" runat="server" OnClick="lbLogin_Click" Text="click here"></asp:LinkButton> 
                    hoặc
                    <asp:LinkButton ID="lbCreateAccount" runat="server" OnClick="lbCreateAccount_Click" Text="click here"></asp:LinkButton> 
                    để tạo tài khoản.
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="pnlError" runat="server">
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        </asp:Panel>
    </div>
 </div>
</asp:Content>
