$(document).ready(function (e) {
    alert("ready");
    e.preventDefault();
    var comment = document.getElementsByName("comment-text-area")[0].value;
    alert(comment);
    /*$.ajax({
        type: "POST",
        url: $(this).attr("action"),
        data: $(this).serialize(),
        success: function(data) {
            $(".comment-display").append("<br/>" + comment);
        }
    });*/
});