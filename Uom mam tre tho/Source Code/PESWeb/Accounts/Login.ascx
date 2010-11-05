<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="PESWeb.Accounts.Login1" %>
<table class="login">
    <tr class="label">
        <td>
            Tài khoản
        </td>
        <td>
            Mật khẩu
        </td>
    </tr>
    <tr>
        <td>
            <asp:TextBox runat="server" ID="txtUsername" ValidationGroup="login" CssClass="text"/>
        </td>
        <td>
            <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" ValidationGroup="login" CssClass="text" />
        </td>
    </tr>
    <tr class="label">
        <td>
            <asp:CheckBox ID="Remember" runat="server" Text="Ghi nhớ" />
        </td>
        <td>
            <asp:HyperLink NavigateUrl="~/Accounts/RecoverPassword.aspx" ID="lnkForgotPwd" runat="server">Quên mật khẩu?</asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblMessage" runat="server" CssClass="message" ForeColor="Red" />
        </td>
        <td align="right">
            <asp:Button ID="btnLogin" CssClass="button" runat="server" Text="Đăng nhập" ValidationGroup="login" />
        </td>
    </tr>
</table>
