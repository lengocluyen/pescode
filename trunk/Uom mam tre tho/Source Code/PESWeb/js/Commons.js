function ChangeClassByID(idObject, className) {
    document.getElementById(idObject).className = className;
    alert(idObject);
}

var a = true;
$(document).ready(function() {
    $("div.hiddenCmt").hide();
    $("div.txtCmt").click(function() {
    $(this).next().slideToggle()
    });

    $("div.hiddenTag").hide();
    $("div.txtTag").click(function() {
    $(this).next().slideToggle();
    });
});

$(document).ready(function() {
    $("div.exComments").hide();
    $("div.exComments_title").click(function() {
        $(this).prev().slideToggle();
      
    });

    //$("#div1 a").click(function(event) {
    //event.preventDefault();
    //$("#div1").slideUp();
    //});
});
