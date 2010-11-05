<%@ Page Title="" Language="C#" MasterPageFile="~/AuthMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PESWeb.Accounts.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
<div class="grid_4 prefix_4 suffix_4">
    <fieldset class="login color">
        <h1>Đăng nhập</h1>
        <asp:Label ID="lblMessage" runat="server" CssClass="message" ForeColor="Red" />
        <p><label>Tài khoản:</label>
            <asp:TextBox runat="server" ID="txtUsername" CssClass="text" />
        </p>
        <p><label>Mật khẩu:</label> 
            <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="text" />
        </p>
        <p>
            <asp:CheckBox ID="Remember" runat="server" CssClass="remember" Text="Ghi nhớ" />
            <asp:HyperLink NavigateUrl="~/Accounts/RecoverPassword.aspx" ID="lnkForgotPwd" runat="server">Quên mật khẩu</asp:HyperLink> 
        </p>
        <div style="position:relative">
            <asp:Button ID="btnLogin" runat="server" Text="Đăng nhập" CssClass="button" />
            <a href="Register.aspx" class="button">Đăng ký</a>
        </div>
    </fieldset> 
</div>
</asp:Content>
