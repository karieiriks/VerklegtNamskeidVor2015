$(document).ready(function () {

    $(".left-widgets, .right-widgets").click(function (e) {
        e.preventDefault();
    })

    $(".comment-link").click(function () {
        var newsitem = $(this).parents(".news-item-wrapper");

        var commentSection = $(newsitem).find(".comment-section");

        if(commentSection.hasClass("hidden"))
        {
            commentSection.removeClass("hidden");
        }
        else
        {
            commentSection.addClass("hidden");
        }
    })
})