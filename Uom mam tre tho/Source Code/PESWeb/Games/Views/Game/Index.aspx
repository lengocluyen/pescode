<%@ Page Title="" Language="C#" MasterPageFile="~/Games/Views/Shared/SiteGames.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Pes.Core" %>
<%@ Import Namespace="PESWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Danh sách trò chơi
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% foreach (GameCategory gCat in (List<GameCategory>)ViewData[WebConstants.ViewDataKey_GameCategories])
       {%>
    <div class="divGameCategoryContent">
        <div class="divCategoryImage">
            <div class="textHead1">
                <%= Html.ActionLink(gCat.GameCategoryName, "GameCatDetails", "Game", new { id = gCat.GameCategoryID }, new object { })%>
            </div>
        </div>
        <% GameService _gameRepository = new GameService();
           List<Game> lstGames = _gameRepository.GetGamesByCategoryID(gCat.GameCategoryID, 0, 4); %>
        <div class="divGameInCategory">
            <% foreach (Game game in lstGames)
               { %>
            <div class="divShowAGame">
                <a href="../Game/Play/<%= Html.Encode(game.GameID) %>">
                    <img src="../Content/GameImages/<%= Html.Encode(game.GameImg) %>" alt="" /></a>
            </div>
            <% } %>
        </div>
    </div>
    <% } %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>
