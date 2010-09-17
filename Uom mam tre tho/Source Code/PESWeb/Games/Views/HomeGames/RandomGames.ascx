<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<script type="text/javascript">
    var prefix = '<%= Html.ResolveUrl("~/") %>';
    function TopContent_OnClickGameImage(id, img, title, description) {
        $('#divCenterContentMainContent').css("display", "none");

        var content = "";
        content += "<div class=\"divShowAGame\">";
        content += "<a href=\"Game/Play/" + id + "\">";
        content += "<img src=\"" + prefix + "../Content/GameImages/" + img + "\" /></a></div>";
        content += "<div style=\"float: left\"><div class=\"textHead1\" style=\"padding-top: 10px; padding-bottom: 5px\">";
        content += "<a href=\"" + prefix + "Game/Play/" + id + "\">" + title + "</a>";
        content += "</div><div style=\"float: left; padding-top: 10px\">";
        content += description + "</div></div>";

        $('#divCenterContentMainContent')[0].innerHTML = content;
        // Animate
        $('#divCenterContentMainContent').fadeIn('normal');
    }
</script>

<!--Hot Games-->
<div id="divHotGame">
    <div class="divHotGameImg">
        <img src="<%= Html.ResolveUrl("~/") %>Content/Images/hotGameTwoChildrent.png" alt="" />
    </div>
    <div class="divHotGameContentFrame">
        <div class="divHotGameContent" id="divCenterContentMainContent">            
        </div>
        <script type="text/javascript">
        TopContent_OnClickGameImage(
                    "<%= Html.Encode(((List<Game>)ViewData[WebConstants.ViewDataKey_RandomGameList])[0].GameID) %>",
                    "<%= Html.Encode(((List<Game>)ViewData[WebConstants.ViewDataKey_RandomGameList])[0].GameImg) %>",
                    "<%= Html.Encode(((List<Game>)ViewData[WebConstants.ViewDataKey_RandomGameList])[0].Name) %>",
                    "<%= Html.Encode(((List<Game>)ViewData[WebConstants.ViewDataKey_RandomGameList])[0].Description) %>"
                );
        </script>
    </div>
    <div class="divHotGameGames">
        <div id="divPadding">
        </div>
        <!-- Fill Data Below -->
        <div class="divHotGameChildFrame">
            <a href="#" onclick="return false;">
                <img onmousemove="$(this).css('opacity', '0.8');" onmouseout="$(this).css('opacity', '1');"
                    onclick="TopContent_OnClickGameImage('<%= Html.Encode(((List<Game>)ViewData[WebConstants.ViewDataKey_RandomGameList])[0].GameID) %>', 
                '<%= Html.Encode(((List<Game>)ViewData[WebConstants.ViewDataKey_RandomGameList])[0].GameImg) %>', 
                '<%= Html.Encode(((List<Game>)ViewData[WebConstants.ViewDataKey_RandomGameList])[0].Name) %>', 
                '<%= Html.Encode(((List<Game>)ViewData[WebConstants.ViewDataKey_RandomGameList])[0].Description) %>');"
                    src="<%= Html.ResolveUrl("~/") %>Content/GameImages/<%= Html.Encode(((List<Game>)ViewData[WebConstants.ViewDataKey_RandomGameList])[0].GameImg) %>" />
            </a>
        </div>
        <div class="divHotGameChildFrame">
            <a href="#" onclick="return false;">
                <img onmousemove="$(this).css('opacity', '0.8');" onmouseout="$(this).css('opacity', '1');"
                    onclick="TopContent_OnClickGameImage('<%= Html.Encode(((List<Game>)ViewData[WebConstants.ViewDataKey_RandomGameList])[1].GameID) %>', 
                '<%= Html.Encode(((List<Game>)ViewData[WebConstants.ViewDataKey_RandomGameList])[1].GameImg) %>', 
                '<%= Html.Encode(((List<Game>)ViewData[WebConstants.ViewDataKey_RandomGameList])[1].Name) %>', 
                '<%= Html.Encode(((List<Game>)ViewData[WebConstants.ViewDataKey_RandomGameList])[1].Description) %>');"
                    src="<%= Html.ResolveUrl("~/") %>Content/GameImages/<%= Html.Encode(((List<Game>)ViewData[WebConstants.ViewDataKey_RandomGameList])[1].GameImg) %>" />
            </a>
        </div>
        <div class="divHotGameChildFrame">
            <a href="#" onclick="return false;">
                <img onmousemove="$(this).css('opacity', '0.8');" onmouseout="$(this).css('opacity', '1');"
                    onclick="TopContent_OnClickGameImage('<%= Html.Encode(((List<Game>)ViewData[WebConstants.ViewDataKey_RandomGameList])[2].GameID) %>', 
                '<%= Html.Encode(((List<Game>)ViewData[WebConstants.ViewDataKey_RandomGameList])[2].GameImg) %>', 
                '<%= Html.Encode(((List<Game>)ViewData[WebConstants.ViewDataKey_RandomGameList])[2].Name) %>', 
                '<%= Html.Encode(((List<Game>)ViewData[WebConstants.ViewDataKey_RandomGameList])[2].Description) %>');"
                    src="<%= Html.ResolveUrl("~/") %>Content/GameImages/<%= Html.Encode(((List<Game>)ViewData[WebConstants.ViewDataKey_RandomGameList])[2].GameImg) %>" />
            </a>
        </div>
    </div>
</div>
