$(document).ready(function () {
    var button = $(".group-create");
    var createmodal = $("#group-create-modal");
    var createform = $("#group-create-form");
    var errormessage = $("#group-name-error");
    var groupname = $("#group-name");
    var joinwidgets = $(".join-widget");
    var groupacceptwidgets = $(".memberlisting-widget.accept-widget");
    var groupdeclinewidgets = $(".memberlisting-widget.decline-widget");
    var friendaddbutton = $(".member-add-button");
    var groupId = $("#group-id").val();
    var searchmodal = $("#friend-search-modal");
    var userId = $("#user-id").val();
    var searchresultsection = $(".result-section");

    button.on("click", function () {
        createmodal.modal("show");
    });

    joinwidgets.click(function () {
        var widget = $(this);
        var groupid = $(widget).parents(".group-widgets").children("input.group-id").val();

        $.post("/Group/SendRequestToGroup", { groupId: groupid }, function (event) {
            $(widget).hide();
            $(widget).parents(".group-widgets").children(".member-status").removeClass("hidden");
        })
    })

    createform.submit(function (event) {

        if (groupname.val() == "" || groupname.val() == null) {
            errormessage.html("You must specify a name of the group");
            event.preventDefault();
        }
        else {
            errormessage.html("");
        }
    })

    groupacceptwidgets.click(function (event) {
        var widget = $(this);
        event.preventDefault();
        var userId = $(this).parents(".request-widgets").children("input").val();

        $.post("/Group/AcceptMemberRequestFromUser", { groupId: groupId, userId: userId }, function (data) {
            var item = $(widget).parents(".memberlisting-item");
            item.appendTo("#members-section");
            $(item).children(".request-widgets").remove();
        });
    })

    groupdeclinewidgets.click(function (event) {
        var widget = $(this);
        event.preventDefault();
        var userId = $(this).parents(".request-widgets").children("input").val();

        $.post("/Group/DeclineMemberRequestFromUser", { groupId: groupId, userId: userId }, function (data) {
            $(widget).parents(".memberlisting-item").remove();
        });
    });

    friendaddbutton.click(function () {
        var items = $(searchresultsection).children(".result-item");

        if (items.length > 0) {
            searchmodal.modal("show");
            return;
        }

        $.get("/Home/GetFriendListForUser", { userId: userId, groupId: groupId }, function (data) {

            var length = Object.keys(data.Friends).length

            for (var i = 0; i < length; i++) {
                var resultitem = $("<div></div>").addClass("result-item well");
                $("<input type = 'hidden'></input>").addClass("friend-id").val(data.Friends[i].Id).appendTo(resultitem);
                var userinfo = $("<div><div>").addClass("user-info").appendTo(resultitem);
                var imagecontainer = $("<div></div>").addClass("user-picture-slot").appendTo(userinfo);
                $("<img/>").attr({ src: data.Friends[i].ProfileImageName, alt: "Profile Image" }).appendTo(imagecontainer);

                var namecontainer = $("<div></div>").addClass("user-name-section").appendTo(userinfo);
                $("<h6></h6>").html("<a href='/Profile/UserWall/" + data.Friends[i].Id + "'>" + data.Friends[i].FullName + "</a>").appendTo(namecontainer);
                var widgetcontainer = $("<div><div>").addClass("widget-container").appendTo(resultitem);
                var invitebutton = $("<button>Invite</button>").addClass("invite-button btn btn-primary").appendTo(widgetcontainer);

                if (data.Friends[i].isGroupMember == true) {
                    $(invitebutton).removeClass("invite-button").addClass("added-button").attr("disabled", true).html("Member");
                }

                $(resultitem).appendTo(searchresultsection);
            }
            searchmodal.modal("show");
        });
    });

    $(document).on("click", ".invite-button", function () {
        var button = $(this);
        button.html("Added");
        button.attr("disabled", true);
        button.removeClass("invite-button").addClass("added-button")
        var item = $(button).parents(".result-item");
        var friendid = item.children(".friend-id").val();

        $.post("/Group/AddMemberToGroup", { groupId: groupId, userId: friendid }, function (data) {
            var item = $(button).parents(".result-item").clone();
            item.removeClass("result-item").addClass("memberlisting-item");
            item.children(".widget-container").remove();
            item.appendTo("#members-section");
        });
    });
})