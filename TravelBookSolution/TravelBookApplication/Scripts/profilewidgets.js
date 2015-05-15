$(document).ready(function () {

    var profileid = $("#profileid");

    $("#profile-add-button").on("click", function () {
        var button = $(this);

        $.post("/Profile/SendFriendRequestToUser", { toUserId: $("#profileid").val() }, function () {
            button.html("Request sent");
            button.attr("disabled", true);
        })
    })

    $(".friendlisting-item .accept-widget").on("click", function () {
        var requestItem = $(this).parents(".friendlisting-item");
        var userId = $(this).parents(".request-widgets").children("input").val();

        $.post("/Profile/AcceptFriendRequestFromUser", { fromUserId: userId }, function (data) {
            var friendsWrapper = $(".friends-wrapper");

            if($(friendsWrapper).children(".friendlisting-item").length == 0) {
                $(".friends-wrapper p").html("");
            }
            $(requestItem).appendTo(friendsWrapper);
            $(requestItem).children(".request-widgets").remove();
        });
    });

    $(".friendlisting-item .decline-widget").on("click", function () {
        var requestItem = $(this).parents(".friendlisting-item");
        var userId = $(this).parents(".request-widgets").children("input").val();

        $.post("/Profile/DeclineFriendRequestFromUser", { fromUserId: userId }, function (data) {
            $(requestItem).fadeOut(500, function () { $(this).remove(); });
        });
    });

    $(".friendrequests-wrapper").change(function () {
        var requestItems = $(this).children(".friendlisting-item");
        alert("Change!");
        if(requestItems.length <= 0) {
            $("<p>You have no friend requests</p>").appendTo(this);
        }
    })
})