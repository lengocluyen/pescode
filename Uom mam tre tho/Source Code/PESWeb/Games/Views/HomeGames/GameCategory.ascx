<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<% foreach (GameCategory gCat in (List<GameCategory>)ViewData[WebConstants.ViewDataKey_GameCategories])
   {%>
<div class="divGameCategoryContent">
    <div class="divCategoryImage">
        <div class="textHead1">
            <a href="#">
                <%= Html.ActionLink(gCat.GameCategoryName, "GameCatDetails", "Game", new { id = gCat.GameCategoryID }, new object { })%>
        </div>
    </div>
    <% GameService _gameRepository = new GameService();
       List<Game> lstGames = _gameRepository.GetGamesByCategoryID(gCat.GameCategoryID, 0, 4); %>
    <div class="divGameInCategory">
        <% foreach (Game game in lstGames)
           { %>
        <div class="divShowAGame">
            <a href="<%= Html.ResolveUrl("~/") %>Game/Play/<%= Html.Encode(game.GameID) %>">
                <img src="<%= Html.ResolveUrl("~/Content/GameImages/") %><%= Html.Encode(game.GameImg) %>" alt="" /></a>
        </div>
        <% } %>
    </div>
</div>
<% } %>
