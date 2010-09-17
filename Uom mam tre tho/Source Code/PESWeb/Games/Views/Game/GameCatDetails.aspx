<%@ Page Title="" Language="C#" MasterPageFile="~/Games/Views/Shared/SiteGames.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Pes.Core" %>
<%@ Import Namespace="PESWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= Html.Encode(ViewData["GC_Name"])%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="divGameCategoryContent">
        <div class="divCategoryImage">
            <div class="textHead1">
                <a href="#">
                    <%= Html.Encode(ViewData["GC_Name"])%></a>
            </div>
        </div>
        <% GameService _gameRepository = new GameService();
           List<Game> lstGames = _gameRepository.GetGamesByCategoryID(CoreSupport.ConvertToInt(ViewData["GC_ID"],0), -1, -1); %>
        <div class="divGameInCategory">
            <% foreach (Game game in lstGames)
               { %>
            <div class="divShowAGame">
                <a href="../../Game/Play/<%= Html.Encode(game.GameID) %>">
                    <img src="../../Content/GameImages/<%= Html.Encode(game.GameImg) %>" alt="" /></a>
            </div>
            <% } %>
        </div>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>
