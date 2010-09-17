<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<script type="text/javascript">
    function beginLoadAnnoucement() {
        $('#divAnnoucementContent')[0].innerHTML = "";
    }

    function successLoadAnnoucement() {
        $('#divAnnoucementContent').css("display", "none");
        $('#divAnnoucementContent').fadeIn('normal');
    }

    function failureLoadAnnoucement() {
        $('#divAnnoucementContent')[0].innerHTML = "Không tải được tin tức!";
    }


</script>

<div class="divNewsFrame_ImgTextTinGame">
    <img src="<%= Html.ResolveUrl("~/") %>Content/Images/text_TinGame.gif" alt="" />
</div>
<div id="divLoading" style="position: absolute; padding-left: 170px; padding-top: 60px;
    visibility: hidden">
    <img src="<%= Html.ResolveUrl("~/") %>Content/Images/loading.gif" />
</div>
<div class="divNewsFrame_Content" id="divAnnoucementContent">
<% GameAnnoucement ann = (ViewData[WebConstants.ViewDataKey_GameAnnoucement] as GameAnnoucement); %>
    <%= (ann.AnnoucementContent) %>
    <% if (ViewData[WebConstants.ViewDataKey_GameAnnoucementHasMore] == "true")
       {%>
       <%= Html.ActionLink("Xem tiếp", "Details", "Annoucement", new { id = ann.GameAnnoucementID }, new { })%>
    <%} %>
</div>
<div class="divNewsFrame_NextForward">
    <div>
        <%= Ajax.ActionLink("[Previous]", "LoadAnnoucement", new { start = ViewData[WebConstants.ViewDataKey_GameAnnoucementIndex], isNext = false },
                            new AjaxOptions
                            {
                                UpdateTargetId = "divHomeNews",
                                LoadingElementId = "divLoading",
                                OnBegin = "beginLoadAnnoucement",
                                OnSuccess = "successLoadAnnoucement",
                                OnFailure = "failureLoadAnnoucement"
                            }).ToString().Replace("[Previous]", "<img src=\"" + Html.ResolveUrl("~/") + "Content/Images/button_News_Forward.gif\" />")%>
    </div>
    <div>
        <%= Ajax.ActionLink("[Next]", "LoadAnnoucement", new { start = ViewData[WebConstants.ViewDataKey_GameAnnoucementIndex], isNext = true },
                            new AjaxOptions {
                                UpdateTargetId = "divHomeNews",
                                LoadingElementId = "divLoading",
                                OnBegin = "beginLoadAnnoucement",
                                OnSuccess = "successLoadAnnoucement",
                                OnFailure = "failureLoadAnnoucement"
                            }).ToString().Replace("[Next]", "<img src=\"" + Html.ResolveUrl("~/") + "Content/Images/button_News_Next.gif\" />")%>
    </div>
</div>
