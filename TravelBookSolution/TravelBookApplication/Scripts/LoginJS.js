
$(document).ready(function () {
    $("#loginLink").click(function (e) {
        e.preventDefault();
        $("#myLoginModal").modal("show");
    });
});

$(document).ready(function () {
    $("#registerLink").click(function (e) {
        e.preventDefault();
        $("#myRegisterModal").modal("show");
    });
});