


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
        init(jQuery, "body");
    });

    function init($, id) {
        id = (typeof (id) == 'undefined') ? "body" : id;

        //        $(".morecomments a").click(function() {
        //            href = $(this).attr('href');
        //            uri = href.split("#")[0];

        //            stylesheet_uri = $("link[rel='stylesheet']:eq(0)").attr("href").split("/");
        //            stylesheet_uri.length--;
        //            img = "<img src='" + stylesheet_uri.join("/") + "/images/indicator_small.gif" + "' alt='Loading' />";
        //            $(this).parent().css("text-align", "center").html(img).parent().load(uri + " div#comments #commentlist");
        //            return false;
        //        });

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


        $(".commentcontainer .index-comment").hover(
              function() {
                  $(this).children(".ic-edit").css("display", "block");
              },
              function() {
                  $(this).children(".ic-edit").css("display", "none");
              }
        );

        function mentionform() {
            $(this).parent().css("display", "none");
            if ($(this).hasClass("single")) {
                $("a.respondlink").click();
            } else {
                $(this).parent().prev().prev().children("a.respondlink").click();
            }
        }

        $(".respondtext").click(mentionform).focus(mentionform);

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

        $('.form_comment textarea').autogrow({
            minHeight: 30
        }).blur(function() {
            $this = $(this);
            if ($this.val().length == 0) {
                $this.parent().parent().css("display", "none");
                $this.parent().parent().prev().css("display", "block");
            }
        });

        $('#c-mention textarea').click(function() {
            $('#c-mention').css("display", "none");
            $('#c-form').css("display", "block");
            $("#c-form .focus:first").focus();
        });

        $('#c-input textarea').autogrow({
            minHeight: 36, maxHeight: 230
        }).blur(function() {
            if ($(this).val().length == 0) {
                $('#c-mention').css("display", "block");
                $('#c-form').css("display", "none");
            }
        });

        function ajaxDelete() {
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
        };

        $(".confirm").click(ajaxDelete);

        function createJsonData(id) {
            var data = {};
            $("#" + id).find('[attrName]').each(function() {
                data[$(this).attr('attrName')] = this.value;
            });
            return JSON.stringify({ 'data': data });
        }
        
        $(".viewmore").click(function() {
            $this = $(this);
            // disable comment input
            $textarea = $this.parent().prev().children(".focus");
            if ($textarea.attr("disabled") == "disabled")
                return;
            $textarea.attr("disabled", "disabled");

            $.ajax({
                type: "POST",
                url: "Services/Services.asmx/MoreComments",
                data: createJsonData($this.attr('container')),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg) {
                    if (msg.d.length > 0) {
                        $container = $this.parent().parent();
                        $temp = $("<div></div>");
                        $temp.setTemplateURL('Template/TemplateComment.htm',
                            null, { filter_data: false });
                        $temp.processTemplate(msg.d);
                        $container.prepend($temp.html());
                    }
                    else {
                        jAlert('error', msg.d, 'Thông báo lỗi');
                    }
                    $textarea.attr("disabled", "");
                },
                error: function(XMLHttpRequest, textStatus, errorThrown) {
                    jAlert('error', textStatus, 'Thông báo');
                    $textarea.attr("disabled", "");
                }
            });
            return false;
        });
        
        $(".addcomment").click(function() {
            $this = $(this);
            // disable comment input
            $textarea = $this.parent().prev().children(".focus");
            if ($textarea.attr("disabled") == "disabled")
                return;
            $textarea.attr("disabled", "disabled");

            $.ajax({
                type: "POST",
                url: "Services/Services.asmx/Test",
                data: createJsonData($this.attr('container')),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg) {
                    if (msg.d.length > 0) {
                        $container = $this.parent().parent().prev().prev();
                        $temp = $("<div></div>");
                        $temp.setTemplateURL('Template/TemplateComment.htm',
                            null, { filter_data: false });
                        $temp.processTemplate(msg.d);
                        $container.append($temp.html());
                        $textarea.val("");
                        $textarea.blur();
                    }
                    else {
                        jAlert('error', msg.d, 'Thông báo lỗi');
                    }
                    $textarea.attr("disabled", "");
                },
                error: function(XMLHttpRequest, textStatus, errorThrown) {
                    jAlert('error', textStatus, 'Thông báo');
                    $textarea.attr("disabled", "");
                }
            });
            return false;
        });

    }
}
