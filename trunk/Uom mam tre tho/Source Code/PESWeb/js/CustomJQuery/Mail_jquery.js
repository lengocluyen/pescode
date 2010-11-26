$(function() {
    mailBox.init();
});

var mailBox = {
    //Phân trang
    nextClick: function() {
        $(".next").click(function() {

        });
    },

    //Delete mail
    deleteMail: function() {
    $(".button gray delete").click(ajaxDelete);
        function ajaxDelete() {
            $this = $(this);
            jConfirm('Bạn có chắc chắn muốn xóa hay không?', 'Xác nhận', function(r) {
                if (r == true) {
                    $.ajax({
                        type: "POST",
                        url: "/Services/Services.asmx/DeleteMailMessage",
                        data: "{MessageID:\"" + $this.attr('data') + "\"}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function(msg) {
                            if (msg.d == 'True')
                                $("INPUT[type='checkbox' attr='True']").fadeOut(function() {
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
    },


    init: function() {
        mailBox.nextClick();
        mailBox.deleteMail();
    } 
}

