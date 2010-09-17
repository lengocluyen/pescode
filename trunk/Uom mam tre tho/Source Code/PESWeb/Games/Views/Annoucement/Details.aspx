<%@ Page Title="" Language="C#" MasterPageFile="~/Games/Views/Shared/SiteGames.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= Html.Encode(ViewData["GA_Title"]) %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="divNews">
        <div id="divNewsTitle">
            <a href="News.aspx">
                <img src="../Content/Images/NewsTitles.png" /></a>
        </div>
        <div class="divNewsContent">
            <div class="divNewsIMG">
                <a href="#">
                    <img src="../../Content/GameAnnoucementImages/<%= ViewData["GA_Img"]%>" alt="Xem tin này" /></a>
            </div>
            <div class="divNewsText">
                <div class="divNewsTextTitle">
                    <a href="#" onclick="return false;" class="aclass">
                        <%=Html.Encode(ViewData["GA_Tilte"])%></a>
                </div>
                <div class="divNewsTextText">
                    <%= ViewData["GA_Content"] %>
                </div>
                <div class="divNewsAdded">
                    Đăng lúc
                    <%= Html.Encode(ViewData["GA_DateAdded"]) %>
                </div>
            </div>
            <div class="divNewsTextBottom">
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>
