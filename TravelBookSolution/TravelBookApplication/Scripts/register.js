$(document).ready(function () {
    $("#first-name").focusout(function () {
        var theValue = $("#first-name").val();
        var result = "";
        return theValue.replace(/\w\S*/g, function (txt) {
            var newValue = txt.charAt(0).toUpperCase() + txt.substr(1).toLowerCase();
            result = result.concat(newValue + " ");
            $("#first-name").val(result);
        });
    });
});

$(document).ready(function () {
    $("#last-name").focusout(function () {
        var theValue = $("#last-name").val();
        var result = "";
        return theValue.replace(/\w\S*/g, function (txt) {
            var newValue = txt.charAt(0).toUpperCase() + txt.substr(1).toLowerCase();
            result = result.concat(newValue + " ");
            $("#last-name").val(result);
        });
    });
});