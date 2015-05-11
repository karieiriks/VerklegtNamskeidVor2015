$(document).ready(function () {

    var profileid = $("#profileid");

    $("#profile-change-button").on("click", function () {
        alert("Clicked Button");
    })

    $("#profile-add-button").on("click", function () {
        var button = $(this);

        $.post("/Profile/SendFriendRequestToUser", { toUserId: $("#profileid").val() }, function () {
            button.html("Request sent");
            button.attr("disabled", true);
        })
    })

    $(".accept-widget").on("click", function () {
        var requestItem = $(this).parents(".friendlisting-item");
        var userId = $(this).parents(".request-widgets").children("input").val();

        $.post("/Profile/AcceptFriendRequestFromUser", { fromUserId: userId }, function (data) {
            $(requestItem).appendTo(".friends-wrapper");
            $(requestItem).children(".request-widgets").remove();
        });
    });

    $(".decline-widget").on("click", function () {
        var requestItem = $(this).parents(".friendlisting-item");
        var userId = $(this).parents(".request-widgets").children("input").val();

        $.post("/Profile/DeclineFriendRequestFromUser", { fromUserId: userId }, function (data) {
            $(requestItem).fadeOut(500, function () { $(this).remove(); });
        });
    });

    $(".friendrequests-wrapper").change(function () {
        var requestitems = $(this).children(".friendlisting-item");
        alert("Change!");
        if(requestitems.length <= 0)
        {
            $("<p>You have no friend requests</p>").appendTo(this);
        }
    })
})