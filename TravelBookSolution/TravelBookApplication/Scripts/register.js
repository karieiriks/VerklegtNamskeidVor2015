$(document).ready(function () {
    $("#birthday").datepicker({
        showOtherMonths: true,
        selectOtherMonths: true,
        changeYear: true,
        yearRange: "1900:+0",
        dateFormat: "dd-MM-yy",
        maxDate: new Date()
    });
});