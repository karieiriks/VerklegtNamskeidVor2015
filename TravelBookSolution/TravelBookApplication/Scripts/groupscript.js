
$(document).ready(function () {
    var button = $(".group-create");
    var createmodal = $("#group-create-modal");
    var createform = $("#group-create-form");
    var errormessage = $("#group-name-error");
    var groupname = $("#group-name");
    var joinwidgets = $(".join-widget");

    button.on("click", function () {
        createmodal.modal("show");
    });

    joinwidgets.click(function () {
        var groupid = $(this).parents(".group-widgets").children("input.group-id").val();

        $.post("/Group/SendRequestToGroup", { groupId: groupid }, function (event) {
            alert("request sent");
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
})