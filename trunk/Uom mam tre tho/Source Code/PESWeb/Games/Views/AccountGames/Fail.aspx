<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<string>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Đăng nhập không thành công</title>
</head>
<body>

    <div>
        <script type="text/javascript">
            alert('Bé nhập sai email hay mật khẩu rồi!');
            window.location = "<%= Model %>";
        </script>
    </div>
</body>
</html>
