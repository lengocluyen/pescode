<%@ Page Title="" Language="C#" MasterPageFile="~/Games/Views/Shared/SiteGames.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Tin tức
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        function ShortenText(text) {
            var shortenLen = 250;
            var result = text;
            if (text.length > shortenLen) {
                result = "<div class=\"divVisible\">" + text.substring(0, shortenLen) + " ... ";
                result += "<a class=\"aViewMore\" href=\"#\" onclick=\"return false;\">Xem tiếp</a>";
                result += "</div>";
                result += "<div class=\"divHide\">" + text + "</div>";
            }
            document.write(result);
        }

        $(document).ready(function() {
            $(".aclass").click(function() {
                $(this).parent().next(".divNewsTextText").children(".divVisible").slideToggle(0);
                $(this).parent().next(".divNewsTextText").children(".divHide").slideToggle(300);
                $(this).parent().next(".divNewsTextText").children(".aViewMore").slideToggle(0);
            });

            $(".aViewMore").click(function() {
                $(this).parent().children(".divVisible").slideToggle(0);
                $(this).parent().children(".divHide").slideToggle(300);
                $(this).slideToggle(0);
            });
        });
    </script>

    <div id="divNews">
        <div id="divNewsTitle">
            <a href="News.aspx">
                <img src="../Content/Images/NewsTitles.png" /></a>
        </div>
        <% foreach (GameAnnoucement ann in (List<GameAnnoucement>)ViewData["Items"])
           {          
        %>
        <div class="divNewsContent">
            <div class="divNewsIMG">
                <a href="#">
                    <img src="../Content/GameAnnoucementImages/<%= ann.GameImg %>" alt="Xem tin này" /></a>
            </div>
            <div class="divNewsText">
                <div class="divNewsTextTitle">
                    <%--<a href="#" onclick="return false;" class="aclass">
                        <%= Html.Encode(ann.GameTitle) %>
                    </a>--%>
                    <%=Html.ActionLink(ann.GameTitle,"Details", new {id=ann.GameAnnoucementID}) %>
                </div>
                <div class="divNewsTextText">
                    <% int shortenLen = 250;
                       if (ann.AnnoucementContent.Length > shortenLen)
                       { %>
                    <div class="divVisible">
                        <%= ann.AnnoucementContent.Substring(0, 250) + " ... "%>
                    </div>
                    <a class="aViewMore" href="#" onclick="return false;">Xem tiếp</a>
                    <div class="divHide">
                        <%= ann.AnnoucementContent%></div>
                    <%}
                       else
                       {%>
                    <%= ann.AnnoucementContent %>
                    <%} %>
                </div>
            </div>
            <div class="divNewsAdded">
                Đăng lúc
                <%= Html.Encode( ((DateTime)ann.DateAdded).ToString("hh:mm dd/mm/yyyy")) %>
            </div>
        </div>
        <div class="divNewsTextBottom">
        </div>
        <%} %>
        <br />
        <br />
        <%= Html.PagerLinks("Annoucement", "Index", (int)ViewData["TotalItems"], (int)ViewData["PageSize"], (int)ViewData["CurrPage"], "", "") %>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>
