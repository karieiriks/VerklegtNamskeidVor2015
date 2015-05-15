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
    });

    var addCommentToSection = function (data, commentSection) {
        $("<hr />").appendTo(commentSection);
        var commentWrapper = $("<div></div>").addClass("comment-wrapper");
        var commentHeader = $("<div></div>").addClass(".comment-header").appendTo(commentWrapper);

        var newCommentTime = $("<small>" + data.TimePosted + "</small>");
        $(newCommentTime).appendTo(commentHeader).addClass("pull-right");

        $("<span></span>").attr({
            style: "margin-left: 2px"
        }).appendTo(newCommentTime).addClass("pull-right").addClass("glyphicon").addClass("glyphicon-time");

        var newCommentImage = $("<div></div>").addClass("comment-user-picture-container");
        $(newCommentImage).appendTo(commentHeader);
        var imgSlot = $("<div></div>").appendTo(newCommentImage).addClass("comment-user-picture-slot");

        $("<img/>").attr({
            src: data.ProfileImageName,
            alt: "ProfileImage"
        }).appendTo(imgSlot);

        var newCommentName = $("<div></div>").addClass("user-name-section").addClass("comment-name-section");
        $(newCommentName).appendTo(newCommentImage);

        var h6 = $("<h6></h6>").appendTo(newCommentName);
        $("<a>" + data.FullName + "</a>").attr({
            href: "/Profile/UserWall/" + data.Id
        }).appendTo(h6);

        var newCommentBody = $("<span>" + data.Body + "</span>");
        $(newCommentBody).appendTo(commentWrapper).addClass("comment-body");

        $(commentWrapper).appendTo(commentSection);

        $("<hr />").appendTo(commentSection);
    }

    $(".comment-link").click(function () {
        var newsItem = $(this).parents(".news-item-wrapper");
        var commentSection = $(newsItem).find(".comment-section");
        var commentDisplay = $(newsItem).find(".comment-display");
        var comments = $(commentSection).find(".comment-wrapper");

        if (comments.length == 0) {
            var contentid = $(newsItem).find(".content-id").val();

            $.get("/Content/GetAllCommentsOfContent", { id: contentid }, function (data) {
                var numberOfComments = data.length;

                for (var i = 0; i < numberOfComments; i++) {
                    addCommentToSection(data[i], commentDisplay);
                }
            });
        }

        if (commentSection.hasClass("hidden")) {
            commentSection.removeClass("hidden");
        } else {
            commentSection.addClass("hidden");
        }
    });

    $("textarea[name$='comment-text-area']").keypress(function (event) {
        if (event.which === 13) {
            event.preventDefault();
            var contentitem = $(this).parents(".news-item-wrapper");
            var commentdisplay = $(contentitem).find(".comment-display");
            var theComment = {
                "Body": $(contentitem).find("textarea[name$='comment-text-area']").val(),
                "ContentId": $(contentitem).find("input[name$='content-id']").val(),
                "UserId": $(contentitem).find("input[name$='user-id']").val()
            }

            $.post("/Content/SubmitComment", theComment, function (data) {
                $(contentitem).find("textarea[name$='comment-text-area']").val("");
                var comments = $(contentitem).find(".comment-wrapper");
                commentdisplay.html("");
                for (var i = 0; i < data.length; i++) {
                    addCommentToSection(data[i], commentdisplay);
                }
            });
        }
    });

    $("#post-image-input").change(function () {
        addFileInputError("");
        var fileName = $(this).val();
        if(fileName == "") {
            $("#file-clear").addClass("hidden");
        } else if($("#file-clear").hasClass("hidden")) {
            $("#file-clear").removeClass("hidden");
        }

        $(".file-name-section").html(fileName);

        if(fileName.length > 150) {
            clearFileInput();
            addFileInputError("This file name is too long");
        } else if(this.files[0].size > 4000000) {
            clearFileInput();
            addFileInputError("This image is too large");
        }
    })

    $("#file-clear").click(function () {
        clearFileInput();
    });
})