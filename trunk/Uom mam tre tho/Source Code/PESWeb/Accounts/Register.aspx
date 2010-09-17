<%@ Page Title="" Language="C#" MasterPageFile="~/AuthMaster.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="PESWeb.Accounts.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
<div class="grid_8 prefix_2 suffix_2">
    <asp:Panel ID="pnlCreateAccount" runat="server">
    <asp:Label ID="lblTermID" runat="server" Visible="false" />
	<fieldset class="register color">
		<h1>Đăng ký</h1>
		<asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" CssClass="message"/>
		<p><label>Tài khoản: </label>
		<asp:TextBox ID="txtUsername" runat="server" CssClass="text"/> </p>
		 </p>
		<p><label>Mật khẩu: </label>
		<asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="text"/> </p>
		<p><label>Nhập lại mật khẩu: </label>
		<asp:TextBox ID="txtVerifyPassword" TextMode="Password" runat="server" CssClass="text"/> </p>
		<p><label>Họ: </label>
		<asp:TextBox ID="txtLastName" runat="server" CssClass="text"/> </p>
		<p><label>Tên đệm & tên: </label>
		<asp:TextBox ID="txtFirstName" runat="server" CssClass="text"/> </p>
		<p><label>Email: </label>
        <asp:TextBox ID="txtEmail" runat="server" CssClass="text"/>
		</p>
		<p><label>Bạn là: </label>
		<asp:DropDownList ID="ddlSex" runat="server">
		    <asp:ListItem Value="-1">Giới tính</asp:ListItem>
		    <asp:ListItem Value="1">Nam</asp:ListItem>
		    <asp:ListItem Value="0">Nữ</asp:ListItem>
		</asp:DropDownList>
		</p>
		<p>
		<label>Ngày sinh:</label>
			<asp:DropDownList ID="ddlDay" runat="server">
		        <asp:ListItem Value="0">Ngày</asp:ListItem>
		    </asp:DropDownList>
			<asp:DropDownList ID="ddlMonth" runat="server">
		        <asp:ListItem Value="0">Tháng</asp:ListItem>
		    </asp:DropDownList>
			<asp:DropDownList ID="ddlYear" runat="server">
		        <asp:ListItem Value="0">Năm</asp:ListItem>
		    </asp:DropDownList>
		</p>
		<p>
		    <label>&nbsp;</label>
		    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/CaptchaImage/JpegImage.aspx" />
		</p>
		<p><label>Mã xác nhận: </label>
        <asp:TextBox ID="txtCaptcha" runat="server" CssClass="text" />
		</p>
		<%--<p>
		    <label>&nbsp;</label>
		    <label class="captcha">
		    Nhập chính xác "mã xác nhận" vào ô trên. <br />
		    <a href="#" id="ChangeCaptcha" runat="server">Click vào đây</a> nếu không nhìn thấy mã xác nhận. 
		    </label>
		</p>--%>
		<p>
		    <label>&nbsp;</label>
		    <span class="right">
                <asp:CheckBox ID="chkAgreeWithTerms" runat="server" Text="Đồng ý thỏa thuận <a href='Terms.aspx'>điều kiện</a>" /> 
		    </span>
		</p>
		<asp:Button runat="server" ID="btnSignUp" Text="Đăng ký" CssClass="button" />
	</fieldset>
	</asp:Panel>
	
	<asp:Panel ID="pnlAccountCreated" runat="server" Visible="false">
    <fieldset class="register">
		<h1>Đăng ký</h1>
		<p>
		Tài khoản đã được tạo thành công.
		</p>
		<p>
        <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="Vui lòng vào email để kích hoạt tài khoản."></asp:Label>
        <br />
        <asp:HyperLink ID="lnkVerifyEmail" runat="server">Verify Email Test</asp:HyperLink>
        </p>
        <a href="Login.aspx">Bấm vào đây để đăng nhập!</a>
    </fieldset>
</asp:Panel>
</div>
</asp:Content>
