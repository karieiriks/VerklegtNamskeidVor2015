
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
        
        if (groupname.val() == "" || groupname.val() == null)
        {
            errormessage.html("You must specify a name of the group");
            event.preventDefault();
        }
        else
        {
            errormessage.html("");
        }
    })

    groupacceptwidgets.click(function (event) {
        var widget = $(this);
        event.preventDefault();
        var userId = $(this).parents(".request-widgets").children("input").val();
        
        $.post("/Group/AcceptMemberRequestFromUser", { groupId : groupId, userId : userId  }, function (data) {
            var item = $(widget).parents(".memberlisting-item");
            item.appendTo("#members-section");
            $(item).children(".request-widgets").remove();
        });
    })
})