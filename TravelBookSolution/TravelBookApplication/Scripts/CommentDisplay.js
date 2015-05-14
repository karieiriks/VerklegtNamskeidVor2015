$(document).ready(function () {
    alert("ready");

    $("comment-text-area").onkeypress(function addComment(e) {
        e.preventDefault();
        var theComment = document.getElementsByName("comment-text-area")[0].value;
        alert(comment);
        $.ajax({
            type: "POST",
            url: "/Content/SubmitComment",
            data: { comment: theComment },
            dataType: "json",
            success: function(data) {
                $(".comment-body").html(data);
            }
        });
    });
});