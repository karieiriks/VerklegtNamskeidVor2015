function expandImage() {
    $("img").click(function () {
        $(this).attr('width', '800');
        $(this).attr('height', '800');

    });
};