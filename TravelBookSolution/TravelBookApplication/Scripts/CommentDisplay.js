$(Document).ready(function () {
    alert("ready");
    var comment = $("comment-text-area").val();
    $.ajax({
        type: "POST",
        url: $(this).attr("action"),
        data: $(this).serialize(),
        success: function(data) {
            $(".comment-display").append("<br/>" + comment);
        }
    });
});