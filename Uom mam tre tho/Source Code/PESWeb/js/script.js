function fixURL() {
    parts = window.location.href.split("#/");
    if (parts.length > 1) {
        window.location.href = parts[parts.length - 1];
    }
}

function changeURL(href) {
    href = (href == "") ? "/" : href;
    uri = window.location.href.split("#/");
    window.location.href = uri[0] + "#/" + href;
}

if (typeof jQuery == "function") {
    jQuery(document).ready(function($) {
        fixURL();
        //  $("#post-container").css("display", "block");
        init();
    });

    function init() {

        function mentionform() {
            $(this).parent().css("display", "none");
            if ($(this).hasClass("single")) {
                $("a.respondlink").click();
            } else {
                $(this).parent().prev().prev().children("a.respondlink").click();
            }
        };

        function createJsonData(id) {
            var data = {};
            $("#" + id).find('[attrName]').each(function() {
                data[$(this).attr('attrName')] = this.value;
            });
            return JSON.stringify({ 'data': data });
        };

        function initDelComment(selector) {
            selector.hover(
                  function() {
                      $(this).children(".ic-edit").css("display", "block");
                  },
                  function() {
                      $(this).children(".ic-edit").css("display", "none");
                  }
            );
            selector.find(".ic-edit a.confirm").click(function() {
                $this = $(this);
                jConfirm('Bạn có chắc chắn muốn xóa hay không?', 'Xác nhận', function(r) {
                    if (r == true) {
                        $.ajax({
                            type: "POST",
                            url: "/Services/Services.asmx/DeleteComment",
                            data: "{CommentID:\"" + $this.attr('data') + "\"}",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function(msg) {
                                if (msg.d == 'True')
                                    $this.parent().parent().fadeOut(function() {
                                        $(this).remove();
                                    });
                                else
                                    jAlert('error', msg.d, 'Thông báo lỗi');
                            },
                            error: function(XMLHttpRequest, textStatus, errorThrown) {
                                jAlert('error', textStatus, 'Thông báo');
                            }
                        });
                    }
                });
                return false;
            });
        };

        function initAddComment(selector) {
            // khoi tao link Cam nhan
            selector.find(".meta .respondlink").click(function() {
                // lay id cua bai post tu sau dau gach ==> post-id
                post_id = $(this).attr('id').split("-")[1];

                if (typeof (post_id) != "undefined") {
                    // an textarea Write comment...
                    $(this).parent().next().next().css("display", "none");
                    // hien thi comment form tuong ung
                    $("#commentform-" + post_id).css("display", "block");
                    // dat con tro vao textbox
                    $("#commentform-" + post_id + " .focus:first").focus();
                } else {
                    $(".respondtext").parent().css("display", "none");
                    $("div#comment_form").css("display", "block");
                    $("#commentform .focus:first").focus();
                }
                return false;
            });
           
            
            // Xem tat ca
            selector.find(".morecomments .viewmore").click(function() {
                $this = $(this);
                // disable comment input
                $textarea = $this.parent().prev().children(".focus");
                if ($textarea.attr("disabled") == "disabled")
                    return;
                if ($this.parent().children("img").length == 0) {
                    $this.after("<img src='/images/indicator_small.gif' alt='Loading' />");
                    $this.css("display", "none");
                }

                $textarea.attr("disabled", "disabled");
                var array = $this.attr('data').split("-");
                var data = "{SystemObjectID:\"" + array[0] + "\",SystemObjectRecordID:\"" + array[1] + "\",More:\"" + array[2] + "\"}";

                $.ajax({
                    type: "POST",
                    url: "/Services/Services.asmx/MoreComments",
                    data: data,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function(msg) {
                        if (msg.d.length > 0) {
                            $container = $this.parent().parent();
                            $temp = $("<div></div>");
                            $temp.setTemplateURL('/Template/TemplateComment.htm',
                            null, { filter_data: false });
                            $temp.processTemplate(msg.d);
                            $container.children(":first").after($temp.html());

                            $this.parent().remove();

                            initDelComment($container.children(".notinit").removeClass("notinit"));
                        }
                        else {
                            jAlert('error', msg.d, 'Thông báo lỗi');
                            $this.css("display", "block").after().css("display", "none");
                        }
                        $textarea.attr("disabled", "");
                    },
                    error: function(XMLHttpRequest, textStatus, errorThrown) {
                        jAlert('error', textStatus, 'Thông báo');
                        $textarea.attr("disabled", "");
                        $this.css("display", "block").after().css("display", "none");
                    }
                });
                return false;
            });

            // Comment
            initDelComment(selector.find(".commentcontainer .index-comment"));

            // Text Viet cam nhan + form input
            selector.find(".index-comment .respondtext").click(mentionform).focus(mentionform)

            // Nut Dang bai
            selector.find(".comment-form .addcomment").click(function() {
                $this = $(this);
                // disable comment input
                $textarea = $this.parent().prev().children(".focus");
                if ($textarea.attr("disabled") == "disabled")
                    return;
                $textarea.attr("disabled", "disabled");
                $.ajax({
                    type: "POST",
                    url: "/Services/Services.asmx/AddComment",
                    data: createJsonData($this.attr('container')),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function(msg) {
                        if (msg.d.length > 0) {
                            $container = $this.parent().parent().prev().prev();
                            $temp = $("<div></div>");
                            $temp.setTemplateURL('/Template/TemplateComment.htm',
                            null, { filter_data: false });
                            $temp.processTemplate(msg.d);
                            $container.append($temp.children());
                            $textarea.val("");
                            $textarea.blur();
                            initDelComment($container.children(".notinit").removeClass("notinit"));
                        }
                        else {
                            jAlert('error', msg.d, 'Thông báo lỗi');
                        }
                        $textarea.attr("disabled", "");
                        return false;
                    },
                    error: function(XMLHttpRequest, textStatus, errorThrown) {
                        jAlert('error', textStatus, 'Thông báo');
                        $textarea.attr("disabled", "");
                    }
                });
                return false;
            });

            // Textbox form input
            selector.find('.form_comment textarea').blur(function() {
                $this = $(this);
                if ($this.val().length == 0) {
                    $this.parent().parent().css("display", "none");
                    $this.parent().parent().prev().css("display", "block");
                }
            }).elastic();
        }

        initAddComment($(".post-text"));

        // init status update form input show hide
        $('#c-mention textarea').click(function() {
            $('#c-mention').css("display", "none");
            $('#c-form').css("display", "block");
            $("#c-form .focus:first").focus();
        });


        $('#c-input textarea').blur(function() {
            if ($(this).val().length == 0) {
                $('#c-mention').css("display", "block");
                $('#c-form').css("display", "none");
            }
        }).elastic();

        // init button addstatus
        $("#addstatus").click(function() {
            $this = $(this);
            // disable comment input
            $textarea = $this.parent().prev().children(".focus");
            if ($textarea.attr("disabled") == "disabled")
                return;
            $textarea.attr("disabled", "disabled");

            $.ajax({
                type: "POST",
                url: "/Services/Services.asmx/AddStatusUpdate",
                data: "{Text:" + JSON.stringify($textarea.val()) + ",AccountID:\"" + $this.attr('data') + "\"}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg) {
                    if (msg.d.length > 0) {
                        $container = $("#posts .post-list");
                        $temp = $("<div></div>");
                        $temp.setTemplateURL('/Template/TemplateStatus.htm',
                            null, { filter_data: false });
                        $temp.processTemplate(msg.d);
                        $container.prepend($temp.children());
                        $textarea.val("");
                        $textarea.blur();
                        initAddComment($container.find(".post .post-text:first"));
                    }
                    else {
                        jAlert('error', msg.d, 'Thông báo lỗi');
                    }
                    $textarea.attr("disabled", "");
                    return false;
                },
                error: function(XMLHttpRequest, textStatus, errorThrown) {
                    jAlert('error', textStatus, 'Thông báo');
                    $textarea.attr("disabled", "");
                }
            });
            return false;
        });

        $("#nextStatus").click(function() {
            $this = $(this);
            $img = $this.next();
            $this.hide();
            $img.show();
            var array = $(this).attr('data').split("-");
            $.ajax({
                type: "POST",
                url: "/Services/Services.asmx/MoreAlerts",
                data: "{AccountID:\"" + array[0] + "\", Skip:\"" + array[1] + "\"}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg) {
                    if (msg.d.length > 0) {
                        $container = $("#posts .post-list");
                        $last = $container.children(".post:last");
                        $temp = $("<div></div>");
                        $temp.setTemplateURL('/Template/TemplateStatus.htm',
                            null, { filter_data: false });
                        $temp.processTemplate(msg.d);
                        $container.append($temp.children());
                        var skip = (parseInt(array[1]) + 20);
                        $this.attr('data', array[0] + '-' + skip);

                        var posttext = $last.nextAll().children(".post-text");
                        initAddComment(posttext);
                        initDelComment(posttext.find(".commentcontainer .notinit").removeClass("notinit"));

                        $this.show();
                        $img.hide();
                    }
                    else {
                        $this.parent().parent().remove();
                    }
                    return false;
                },
                error: function(XMLHttpRequest, textStatus, errorThrown) {
                    jAlert('error', textStatus, 'Thông báo');
                    $this.show();
                    $img.hide();
                }
            });
            return false;
        });
    }
}


//id = (typeof (id) == 'undefined') ? "body" : id + " ";

//        $(".commentcontainer .index-comment").hover(
//              function() {
//                  $(this).children(".ic-edit").css("display", "block");
//              },
//              function() {
//                  $(this).children(".ic-edit").css("display", "none");
//              }
//        );

//        $(".confirm").click(ajaxDelete);

//        $(".morecomments a").click(function() {
//            href = $(this).attr('href');
//            uri = href.split("#")[0];

//            stylesheet_uri = $("link[rel='stylesheet']:eq(0)").attr("href").split("/");
//            stylesheet_uri.length--;
//            img = "<img src='" + stylesheet_uri.join("/") + "/images/indicator_small.gif" + "' alt='Loading' />";
//            $(this).parent().css("text-align", "center").html(img).parent().load(uri + " div#comments #commentlist");
//            return false;
//        });


//        function nextpost() {
//            $(this).unbind('click', nextpost);
//            stylesheet_uri = $("link[rel='stylesheet']:eq(0)").attr("href").split("/");
//            stylesheet_uri.length--;
//            img = "&nbsp;<img src='" + stylesheet_uri.join("/") + "/images/indicator_small.gif" + "' alt='Loading' />";
//            $(this).after(img);
//            href = $(this).attr("href");
//            link = $(this);
//            $(".post-list").removeClass("post-list");
//            $(this).parent().parent().before("<div class='older'></div>");
//            $(this).parent().parent().prev().load(href + " .post-list", {}, function() {
//                init(jQuery, ".post-list");
//                link.next().remove();
//                nextpostslink = (typeof ($("#nextpage").attr("value")) == "undefined") ? "mbuh" : $("#nextpage").attr("value");
//                $("#nextpage").remove();
//                if (nextpostslink == "mbuh") {
//                    link.remove();
//                } else {
//                    link.attr("href", nextpostslink);
//                }
//            });
//            return false;
//        }
////        $("a.nextpost").click(nextpost);

//        $(id + " a").not(".nextpost").not(".notajax").each(function() {
//            site = $("meta[name='home']").attr("content");
//            dashboard = $("meta[name='url']").attr("content") + "/wp-admin";
//            wplogin = $("meta[name='url']").attr("content") + "/wp-login.php";
//            if (
//				$(this).attr('href') != '#' && //it's not a '#' only link
//				$(this).attr('href').indexOf(site) == 0 && //it's an internal link
//				$(this).attr('href').indexOf(dashboard) == -1 && //it's not a link to dashboard
//				$(this).attr('href').indexOf(wplogin) == -1 && //it's not a link to wp-login.php
//				$(this).attr('target') != '_blank' //it's not a new window link
//			) {
//                $(this).click(function() {
//                    hidebox();
//                    hrefs = $(this).attr("href").split("#");
//                    href = hrefs[0];
//                    if ($(this).parent().hasClass("cat-item")) {
//                        $(".cat-item").removeClass("current-cat");
//                        $(this).parent().addClass("current-cat");
//                    }

//                    stylesheet_uri = $("link[rel='stylesheet']:eq(0)").attr("href").split("/");
//                    stylesheet_uri.length--;
//                    img = "<img src='" + stylesheet_uri.join("/") + "/images/indicator_large.gif" + "' alt='Loading' />";
//                    $("#post-container").html(img).load(href + " #posts", {}, function() {
//                        if ($("#post-container").html() == "") {
//                            window.location.href = href;
//                            return false;
//                        }

//                        document.title = $("input[type='hidden'][name='title']").attr("value");
//                        site = (site.charAt(site.length - 1) == "/") ? site : site + "/";
//                        href = href.replace(site, "");
//                        if (hrefs.length > 1)
//                            href += "#" + hrefs[hrefs.length - 1];
//                        changeURL(href);
//                        init($, "#posts"); //re-init the database
//                    });
//                    return false;
//                });
//            }
//        });

/*
initDelComment($(".commentcontainer .index-comment"));
        

$("a.respondlink").click(function() {
// lay id cua bai post tu sau dau gach ==> post-id
post_id = $(this).attr('id').split("-")[1];

if (typeof (post_id) != "undefined") {
// an textarea Write comment...
$(this).parent().next().next().css("display", "none");
// hien thi comment form tuong ung
$("#commentform-" + post_id).css("display", "block");
// dat con tro vao textbox
$("#commentform-" + post_id + " .focus:first").focus();
} else {
$(".respondtext").parent().css("display", "none");
$("div#comment_form").css("display", "block");
$("#commentform .focus:first").focus();
}
return false;
});
        
        
$(".respondtext").click(mentionform).focus(mentionform);
       

$('.form_comment textarea').autogrow({
minHeight: 30
}).blur(function() {
$this = $(this);
if ($this.val().length == 0) {
$this.parent().parent().css("display", "none");
$this.parent().parent().prev().css("display", "block");
}
});

$(".viewmore").click(function() {
$this = $(this);
// disable comment input
$textarea = $this.parent().prev().children(".focus");
if ($textarea.attr("disabled") == "disabled")
return;
if ($this.parent().children("img").length == 0) {
$this.after("<img src='/images/indicator_small.gif' alt='Loading' />");
$this.css("display", "none");
}

$textarea.attr("disabled", "disabled");
var array = $this.attr('data').split("-");
var data = "{SystemObjectID:\"" + array[0] + "\",SystemObjectRecordID:\"" + array[1] + "\",More:\"" + array[2] + "\"}";

$.ajax({
type: "POST",
url: "/Services/Services.asmx/MoreComments",
data: data,
contentType: "application/json; charset=utf-8",
dataType: "json",
success: function(msg) {
if (msg.d.length > 0) {
$container = $this.parent().parent();
$temp = $("<div></div>");
$temp.setTemplateURL('/Template/TemplateComment.htm',
null, { filter_data: false });
$temp.processTemplate(msg.d);
$container.children(":first").after($temp.html());

$this.parent().remove();

initDelComment($container.children(".notinit").removeClass("notinit"));
}
else {
jAlert('error', msg.d, 'Thông báo lỗi');
$this.css("display", "block").after().css("display", "none");
}
$textarea.attr("disabled", "");
},
error: function(XMLHttpRequest, textStatus, errorThrown) {
jAlert('error', textStatus, 'Thông báo');
$textarea.attr("disabled", "");
$this.css("display", "block").after().css("display", "none");
}
});
return false;
});
*/