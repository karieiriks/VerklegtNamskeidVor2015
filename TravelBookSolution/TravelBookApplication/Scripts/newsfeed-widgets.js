$(document).ready(function () {

    var clearFileInput = function () {
        $("#post-image-input").val("");
        $("#file-clear").addClass("hidden");
        $(".file-name-section").html("");
    }

    var addFileInputError = function (error) {
        $("#file-input-error").html(error);
    }

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
        addFileInputError("");
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

        if (filename.length > 150) {
            clearFileInput();
            addFileInputError("This file name is too long");
        }
        else if (this.files[0].size > 4000000) {
            clearFileInput();
            addFileInputError("This image is too large");
        }
    })

    $("#file-clear").click(function () {
        clearFileInput();
    });
})