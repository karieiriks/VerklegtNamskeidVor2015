$(document).ready(function() {
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
                for (var i = comments.length; i < data.length; i++) {
                    $("<hr />").appendTo(commentdisplay);
                    var newWrapper = $("<div></div>").addClass("comment-wrapper");
                    var commentHeader = $("<div></div>").addClass("comment-header").appendTo(newWrapper);
                    // the posting time
                    var newCommentTime = $("<small>" + data[i].TimePosted + "</small>");
                    $(newCommentTime).appendTo(commentHeader).addClass("pull-right");
                    $("<span></span>").attr({
                        style: "margin-left: 2px"
                    }).appendTo(newCommentTime).addClass("pull-right").addClass("glyphicon").addClass("glyphicon-time");
                    // the profile image
                    var newCommentImage = $("<div></div>").addClass("comment-user-picture-container");
                    $(newCommentImage).appendTo(commentHeader);
                    var imgSlot = $("<div></div>").appendTo(newCommentImage).addClass("comment-user-picture-slot");
                    $("<img/>").attr({
                        src: data[i].ProfileImageName,
                        alt: "ProfileImage"
                    }).appendTo(imgSlot);
                    // the username
                    var newCommentName = $("<div></div>").addClass("user-name-section").addClass("comment-name-section");
                    $(newCommentName).appendTo(newCommentImage);
                    var h6 = $("<h6></h6>").appendTo(newCommentName);
                    $("<a>"+data[i].FullName+"</a>").attr({
                        href: "/Profile/UserWall/"+data[i].Id
                    }).appendTo(h6);
                    // the comment
                    var newCommentBody = $("<span>" + data[i].Body + "</span>");
                    $(newCommentBody).appendTo(newWrapper).addClass("comment-body");

                    $(newWrapper).appendTo(commentdisplay);
                    $("<hr />").appendTo(commentdisplay);
                }
            });
        }
    });
});