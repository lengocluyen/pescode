<%@ Page Language="C#" MasterPageFile="~/Games/Views/Shared/SiteGames.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Vừa học vừa chơi!
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ScriptContent" runat="server">

</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <!--Hot Game-->
    <% Html.RenderPartial("~/Games/Views/HomeGames/RandomGames.ascx"); %>
    <!--News + Top Games-->
    <div id="divNewsTopGame">
        <!-- News Game -->
        <div class="divHomeNews_NewsFrame" id="divHomeNews">
            <% Html.RenderPartial("~/Games/Views/HomeGames/GameAnnoucement.ascx"); %>
        </div>
        <!-- Top Ten-->
        <div class="divTopTen_Frame">
            <div class="divTopTenFrame_ImgTextTopTen">
                <img src="<%= Html.ResolveUrl("~/") %>Content/Images/text_TopTen.gif" alt="" />
            </div>
            <div class="divTopTen_Content" id="divTopTen">
                <% Html.RenderPartial("~/Games/Views/HomeGames/TopTen.ascx"); %>
            </div>
        </div>
    </div>
    <!--Game Category-->
    <div id="divCategory" style="padding-top:20px">
        <% Html.RenderPartial("~/Games/Views/HomeGames/GameCategory.ascx"); %>
    </div>
</asp:Content>
