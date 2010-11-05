<%@ Page Title="" Language="C#" MasterPageFile="~/AuthMaster.Master" AutoEventWireup="true"
    CodeBehind="RecoverPassword.aspx.cs" Inherits="PESWeb.Accounts.RecoverPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="BoxTitle">
        Quên thông tin tài khoản
    </div>
    <asp:PlaceHolder ID="pnlRecoverPassword" runat="server">
        <p>
            <label>
                <asp:RequiredFieldValidator ID="reqEmail" runat="server" Display="Static" ControlToValidate="txtEmail"
                    SetFocusOnError="true">*</asp:RequiredFieldValidator>
                Email:</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="text" />
        </p>
        <div style="margin-left:50px">
            <asp:Button ID="btnRecoverPassword" runat="server" Text="Khôi phục mật khẩu" CssClass="button" />
        </div>
        <br />
    </asp:PlaceHolder>
    <asp:Label ID="lblMessage" runat="server" CssClass="message" ForeColor="Red" />
</asp:Content>
