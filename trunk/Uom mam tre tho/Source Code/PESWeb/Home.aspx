<%@ Page Title="" Language="C#" MasterPageFile="~/AuthMaster.Master" AutoEventWireup="true"
    CodeBehind="Home.aspx.cs" Inherits="PESWeb.Accounts.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <asp:Panel ID="pnlCreateAccount" runat="server">
        <asp:Label ID="lblTermID" runat="server" Visible="false" />
        <div class="BoxTitle">
            Đăng Ký
        </div>
        <table class="formRegister">
            <tr>
                <td class="label">
                    Tài khoản:
                </td>
                <td>
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="text" ValidationGroup="gr" />
                    <asp:RequiredFieldValidator ID="reqUsername" runat="server" ErrorMessage="*" ControlToValidate="txtUsername"
                        ValidationGroup="gr" />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="label">
                    Mật khẩu:
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="text"
                        ValidationGroup="gr" />
                    <asp:RequiredFieldValidator ID="reqPassword" runat="server" ErrorMessage="*" ControlToValidate="txtPassword"
                        ValidationGroup="gr" />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="label">
                    Nhập lại mật khẩu:
                </td>
                <td>
                    <asp:TextBox ID="txtVerifyPassword" TextMode="Password" runat="server" CssClass="text"
                        ValidationGroup="gr" />
                   <%-- <asp:RequiredFieldValidator ID="reqVerifyPassword" runat="server" ErrorMessage="*"
                        ControlToValidate="txtPassword" ValidationGroup="gr" />
                    <asp:CompareValidator ID="cmp" runat="server" ControlToValidate="txtVerifyPassword"
                        ControlToCompare="txtPassword" ValidationGroup="gr" />--%>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="label">
                    Họ:
                </td>
                <td>
                    <asp:TextBox ID="txtLastName" runat="server" CssClass="text" ValidationGroup="gr" />
                    <asp:RequiredFieldValidator ID="reqLastName" runat="server" ErrorMessage="*" ControlToValidate="txtLastName"
                        ValidationGroup="gr" />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="label">
                    Tên đệm & tên:
                </td>
                <td>
                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="text" />
                    <asp:RequiredFieldValidator ID="reqFirstName" runat="server" ErrorMessage="*" ControlToValidate="txtFirstName" />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="label">
                    Email:
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="text" ValidationGroup="gr" />
                    <asp:RegularExpressionValidator ID="reqEmail" runat="server" ErrorMessage="*" ControlToValidate="txtEmail"
                        ValidationGroup="gr" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="label">
                    Bạn là:
                </td>
                <td>
                    <asp:DropDownList ID="ddlSex" runat="server" ValidationGroup="gr">
                        <asp:ListItem Value="-1">-- Chọn giới tính --</asp:ListItem>
                        <asp:ListItem Value="1">Nam</asp:ListItem>
                        <asp:ListItem Value="0">Nữ</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="reqSex" runat="server" InitialValue="-1" ValidationGroup="gr"
                        ErrorMessage="*" ControlToValidate="ddlSex" SetFocusOnError="True" />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="label">
                    Ngày sinh:
                </td>
                <td>
                    <asp:DropDownList ID="ddlDay" runat="server" ValidationGroup="gr">
                        <asp:ListItem Value="0">Ngày</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlMonth" runat="server" ValidationGroup="gr">
                        <asp:ListItem Value="0">Tháng</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlYear" runat="server" ValidationGroup="gr">
                        <asp:ListItem Value="0">Năm</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/CaptchaImage/JpegImage.aspx" />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="label" valign="top">
                    Mã xác nhận:
                </td>
                <td>
                    <asp:TextBox ID="txtCaptcha" runat="server" CssClass="text" ValidationGroup="gr" />
                    <asp:RequiredFieldValidator ID="reqCaptcha" runat="server" ErrorMessage="*" ControlToValidate="txtCaptcha"
                        ValidationGroup="gr" />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:CheckBox ID="chkAgreeWithTerms" runat="server" ValidationGroup="gr" Text="Đồng ý thỏa thuận <a href='Terms.aspx'>điều kiện</a>" />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Button runat="server" ID="btnSignUp" Text="Đăng ký" CssClass="button" ValidationGroup="gr" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" CssClass="message" />
                </td>
            </tr>
        </table>
        <div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlAccountCreated" runat="server" Visible="false">
        <div class="BoxTitle">
            Đăng ký
        </div>
        <div style="text-align: center">
            <p>
                <b>Tài khoản đã được tạo thành công.</b>
            </p>
            <p>
                <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="Vui lòng vào email để kích hoạt tài khoản."></asp:Label>
                <br />
                <asp:HyperLink ID="lnkVerifyEmail" runat="server">Verify Email Test</asp:HyperLink>
            </p>
        </div>
        <%--  <a href="Login.aspx">Bấm vào đây để đăng nhập!</a>--%>
    </asp:Panel>
</asp:Content>
