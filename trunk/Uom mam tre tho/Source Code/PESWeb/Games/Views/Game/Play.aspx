<%@ Page Title="" Language="C#" MasterPageFile="~/Games/Views/Shared/SiteGames.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= Html.Encode(ViewData["G_Name"])%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptContent" runat="server">

    <script type="text/javascript" language="javascript" src="<%= Html.ResolveUrl("~/js/jsAJAX.js") %>"></script>

    <script type="text/javascript" src="<%= Html.ResolveUrl("~/js/Silverlight.js") %>"></script>

    <script type="text/javascript">
        function onSilverlightError(sender, args) {
            var appSource = "";
            if (sender != null && sender != 0) {
                appSource = sender.getHost().Source;
            }

            var errorType = args.ErrorType;
            var iErrorCode = args.ErrorCode;

            if (errorType == "ImageError" || errorType == "MediaError") {
                return;
            }

            var errMsg = "Unhandled Error in Silverlight Application " + appSource + "\n";

            errMsg += "Code: " + iErrorCode + "    \n";
            errMsg += "Category: " + errorType + "       \n";
            errMsg += "Message: " + args.ErrorMessage + "     \n";

            if (errorType == "ParserError") {
                errMsg += "File: " + args.xamlFile + "     \n";
                errMsg += "Line: " + args.lineNumber + "     \n";
                errMsg += "Position: " + args.charPosition + "     \n";
            }
            else if (errorType == "RuntimeError") {
                if (args.lineNumber != 0) {
                    errMsg += "Line: " + args.lineNumber + "     \n";
                    errMsg += "Position: " + args.charPosition + "     \n";
                }
                errMsg += "MethodName: " + args.methodName + "     \n";
            }

            throw new Error(errMsg);
        }
    </script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div id="silverlightLoading" style="display: none; padding-left: 400px; padding-top: 230px;
        z-index: 3">
        <img src="../../Content/images/bigloading.gif" /></div>
    <div style="width: 100%; padding-top: 20px; padding-bottom: 20px; height:600px">
        <div id="silverlightControlHost" style="width: 856px; text-align: center;  z-index: 1; position:absolute">
            <% if (ViewData["UserLogin"] == "")
               {%>
            <div class="textHead1" style="padding-top: 80px; padding-bottom: 80px; text-align: center">
                <a href="#">Bạn phải đăng nhập!</a></div>
            <%}
               else
               { %>
            <object data="data:application/x-silverlight-2," type="application/x-silverlight-2"
                width="856" height="570">
                <param name="source" value="<%= Html.ResolveUrl("~/Content/GameFiles/") %><%= Html.Encode(ViewData["G_File"]) %>" />
                <param name="enableHtmlAccess" value="true" />
                <param name="onError" value="onSilverlightError" />
                <param name="background" value="transparent" />
                <param name="minRuntimeVersion" value="3.0.40624.0" />
                <param name="autoUpgrade" value="true" />
                <param name="windowless" value="true" />
                <param name="initParams" value="id=<%= Html.Encode( ViewData["G_ID"] ) %>" />
                <a href="http://go.microsoft.com/fwlink/?LinkID=149156&v=3.0.40624.0" style="text-decoration: none">
                    <img src="http://go.microsoft.com/fwlink/?LinkId=108181" alt="Get Microsoft Silverlight"
                        style="border-style: none" />
                </a>
            </object>
            <iframe id="_sl_historyFrame" style="visibility: hidden; height: 0px; width: 0px;
                border: 0px"></iframe>
            <%} %>
        </div>
        <div id="silverlightMask" style="display:none; background-color:White; width: 856px; height: 570px;
            z-index: 2; position:absolute">
        </div>
    </div>
</asp:Content>
