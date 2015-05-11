
$(document).ready(function () {
    var button = $(".group-create");
    var createmodal = $("#group-create-modal");

    button.on("click", function () {
        createmodal.modal("show");
    });
})