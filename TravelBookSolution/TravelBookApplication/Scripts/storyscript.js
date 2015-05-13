
$(document).ready(function () {

    createbutton = $("#story-create");
    createmodal = $("#story-create-modal");

    $(createbutton).click(function(){
        createmodal.modal("show");
    })
})