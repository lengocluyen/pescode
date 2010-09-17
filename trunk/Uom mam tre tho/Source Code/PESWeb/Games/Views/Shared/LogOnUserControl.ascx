<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<script type="text/javascript">
    function WatermarkFocus(txtElem, strWatermark) {
        if (txtElem.value == strWatermark) txtElem.value = '';
    }

    function WatermarkBlur(txtElem, strWatermark) {
        if (txtElem.value == '') txtElem.value = strWatermark;
    }
</script>

<%--<% if (PESSession.PupilLogin == null)
   {%>
<% using (Html.BeginForm("LogOn", "Account", FormMethod.Post, new { name = "logonform" }))
   {%>
<div id="divLogin_UserAccount">
    <div>
        <input type="text" id="txtUserName" name="email" value="Tên Đăng Nhập" onfocus="WatermarkFocus(this, 'Email');"
            onblur="WatermarkBlur(this, 'Email');" />
    </div>
    <div>
        <input id="txtPassword" name="password" type="password" value="Mật khẩu" onfocus="WatermarkFocus(this, 'Mật khẩu');"
            onblur="WatermarkBlur(this, 'Mật khẩu');" />
    </div>
    <div id="divLinkLogin">
        <a href="#" onclick="document.logonform.submit();" style="color: White;">Đăng nhập</a>
    </div>
    <div id="divLinkForgotPass" style="border-right: 1px dotted white; padding-right: 7px">
    <%=Html.ActionLink("Quên mật khẩu", "Forgotpw", "UserAccount", "http", "localhost:9999", "", null, null)%>
        
   </div>
   
</div>
<%} %>
<%}
   else
   { %>--%>
<div id="divUserAccount" style="padding-bottom: 20px">
    <div style="float: left; padding-right: 10px; border-right: dotted 1px white;">
        Xin chào <span style="font-weight: bold;">
            <%= Html.Encode(ViewData["UserLogin"])%></span>, chúc bạn có những
        giây phút vui vẻ.
    </div>
    <div style="float: left; margin-left: 10px; border-right: 1px dotted white; padding-right: 7px">
        <%= Html.ActionLink("Thoát", "LogOut", "AccountGames", new { }, new { style = "color: White; font-weight: bold;" })%>
    </div>
    <div>
        <%--<a href="../../../Home.aspx" style="color: White;">Về trang chủ</a>
    </div>--%>
    </div>
</div>
<%--<%} %>--%>
