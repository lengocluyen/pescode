<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<% Game game = PESSession.RandomGamesForTopTen[(int)(ViewData[WebConstants.ViewDataKey_TopPlayersIndex])]; %>
<div style="width: 100%; margin-bottom: 5px; text-align: right;" id="divTopTenContent">
    <span style="color: #0c92f3; font-weight: bold;">Trò Chơi: </span><span style="color: #0c92f3;
        font-weight: bold; font-style: italic;"><a href="<%= Html.ResolveUrl("~/") %>Game/Play/<%= Html.Encode(game.GameID) %>">
            <%= Html.Encode(game.Name)%>
        </a></span>
</div>
<%int count = 1;
  foreach (Account gamer in (List<Account>)ViewData[WebConstants.ViewDataKey_TopPlayers])
  {
      if (count == 1 || count == 5)
      {
%>
<div class="divTopTen_Content_Half">
    <%}%>
    <div class="divTopTen_Content_Half_Content">
        <div class="divTopTen_Content_Haft_Content01">
            <img src="<%= Html.ResolveUrl("~/") %>Content/Images/Icons/no<%= Html.Encode(count) %>.jpg" alt="" />
        </div>
        <div class="divTopTen_Content_Haft_Content02">
            <span>
                <%= Html.Encode(gamer.FirstName + " " + gamer.LastName)%></span>
        </div>
    </div>
    <% if (count == 4 || count == 8)
       { %>
</div>
<%} count++;
  } %>
  
<% if (count == 1)
   {%>
<div class="divTopTen_Content_Half">
    <div class="divTopTen_Content_Half_Content">
        <div class="divTopTen_Content_Haft_Content01">
        </div>
        <div class="divTopTen_Content_Haft_Content02">
            <span></span>
        </div>
    </div>
</div>
<%} %>
<% else if (count < 5 || count < 9)
    {%>
</div>
<%} %>

<script type="text/javascript">
    function beginLoadTopGamer() {
        $('.divTopTen_Content_Half')[0].innerHTML = "<div class=\"divTopTen_Content_Half_Content\">";
        $('.divTopTen_Content_Half')[0].innerHTML += "<div class=\"divTopTen_Content_Haft_Content01\"></div>";
        $('.divTopTen_Content_Half')[0].innerHTML += "<div class=\"divTopTen_Content_Haft_Content02\"><span></span></div>";
        $('.divTopTen_Content_Half')[0].innerHTML += "</div>"; 
    }

    function successLoadTopGamer() {
        $('#divTopTenContent').css("display", "none");
        $('#divTopTenContent').fadeIn('normal');
    }

    function failureLoadTopGamer() {
        $('#divTopTenContent')[0].innerHTML = "Không tải được!";
    }
</script>

<div id="divLoadingTopGamer" style="position: absolute; padding-left: 100px; padding-top: 40px;
    visibility: hidden">
    <img src="<%= Html.ResolveUrl("~/") %>Content/Images/loading.gif" />
</div>
<div class="divTopFrame_NextForward">
    <div>
        <%= Ajax.ActionLink("[Previous]", "LoadTopGamer", new { curr = ViewData[WebConstants.ViewDataKey_TopPlayersIndex], isNext = false },
                            new AjaxOptions {
                                UpdateTargetId = "divTopTen",
                                LoadingElementId = "divLoadingTopGamer",
                                OnBegin = "beginLoadTopGamer",
                                OnSuccess = "successLoadTopGamer",
                                OnFailure = "failureLoadTopGamer"
                            }).ToString().Replace("[Previous]", "<img src=\"" + Html.ResolveUrl("~/") + "Content/Images/button_News_Forward.gif\" />")%>
    </div>
    <div>
        <%= Ajax.ActionLink("[Next]", "LoadTopGamer", new { curr = ViewData[WebConstants.ViewDataKey_TopPlayersIndex], isNext = true },
                            new AjaxOptions {
                                UpdateTargetId = "divTopTen",
                                LoadingElementId = "divLoadingTopGamer",
                                OnBegin = "beginLoadTopGamer",
                                OnSuccess = "successLoadTopGamer",
                                OnFailure = "failureLoadTopGamer"
                            }).ToString().Replace("[Next]", "<img src=\"" + Html.ResolveUrl("~/") + "Content/Images/button_News_Next.gif\" />")%>
    </div>
</div>
