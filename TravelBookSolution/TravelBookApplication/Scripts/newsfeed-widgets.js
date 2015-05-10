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

    $("#post-image-input").change(function () {
        var filename = $(this).val();

        if (filename == "")
        {
            $("#file-clear").addClass("hidden");
        }
        else if ($("#file-clear").hasClass("hidden"))
        {
            $("#file-clear").removeClass("hidden");
        }

        $(".file-name-section").html(filename);
    })

    $("#file-clear").click(function () {
        $("#post-image-input").val("");
        $(this).addClass("hidden");
        $(".file-name-section").html("");

    })

    $("#post-button").click(function () {

    })
})