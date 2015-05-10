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
            //$(requestItem).fadeOut(500, function () { $(this).remove(); });
            $(requestItem).children(".request-widgets").remove();
            var requestwrapper = $(this).parents(".friendrequests-wrapper");
            var itemsLeft = $(requestwrapper).children(".friendlisting-item");

            if(itemsLeft.length == 0)
            {
                $("<p>You do not have any friend requests</p>").appendTo(requestwrapper);
            }
        });
    })
})