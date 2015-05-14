$(document).ready(function() {
    $("textarea[name$='comment-text-area']").keypress(function (event) {
        if (event.which === 13) {
            event.preventDefault();
            var contentitem = $(this).parents(".news-item-wrapper");
            var theComment = {
                "Body": $("textarea[name$='comment-text-area']").val(),
                "ContentId": $("input[name$='content-id']").val(),
                "UserId": $("input[name$='user-id']").val()
            }
            $.post("/Content/SubmitComment", theComment, function (data) {
                $("textarea[name$='comment-text-area']").val("");
                var comments = $(contentitem).find(".comment-wrapper");
                for (var i = comments.length; i < data.length; i++) {
                    var newWrapper = $("<div></div>").addClass("comment-wrapper");
                    // the posting time
                    var newCommentTime = $("<small>" + data[i].TimePosted + "</small>");
                    $(newCommentTime).appendTo(newWrapper).addClass("pull-right");
                    $("<span></span>").attr({
                        style: "margin-left: 2px"
                    }).appendTo(newCommentTime).addClass("pull-right").addClass("glyphicon").addClass("glyphicon-time");
                    // the profile image
                    var newCommentImage = $("<div></div>").addClass("comment-user-picture-container");
                    $(newCommentImage).appendTo(newWrapper);
                    var imgSlot = $("<div></div>").appendTo(newCommentImage).addClass("comment-user-picture-slot");
                    $("<img/>").attr({
                        src: data[i].ProfileImageName,
                        alt: "ProfileImage"
                    }).appendTo(imgSlot);
                    // the username
                    var newCommentName = $("<div></div>").addClass("user-name-section").addClass("newsfeed-owner-name");
                    $(newCommentName).appendTo(newCommentImage);
                    var h6 = $("<h6></h6>").appendTo(newCommentName);
                    $("<a>"+data[i].FullName+"</a>").attr({
                        href: "/Profile/UserWall/"+data[i].Id
                    }).appendTo(h6);
                    // the comment
                    var newCommentBody = $("<span>" + data[i].Body + "</span>");
                    $(newCommentBody).appendTo(newWrapper).addClass("comment-body");

                    $(newWrapper).appendTo(".comment-display");
                }
            });
        }
    });
});