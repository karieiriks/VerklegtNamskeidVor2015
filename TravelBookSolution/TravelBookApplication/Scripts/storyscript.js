

function readURL(input, imgid) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#' + imgid).attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
    }
}

$(document).ready(function () {

    createbutton = $("#story-create");
    createmodal = $("#story-create-modal");
    descriptionmodal = $("#description-modal");
    descriptiontitle = $("#description-modal .modal-title");
    descsave = $(".description-save-button");

    $(createbutton).click(function(){
        createmodal.modal("show");
    })

    $(".img-input").change(function () {
        imgid = $(this).parents(".scene-wrapper").children(".scene-container").children("img").attr("id");
        readURL(this, imgid);
    })

    $(".description-button").on("click", function (event) {
        event.preventDefault();
        var scene = $(this).parents(".scene-wrapper");
        var scenenumber = $(scene).children(".scene-number").val();
        var text = $(scene).children("#description-" + scenenumber).val();
        var title = "Scene " + scenenumber;
        $(".description-section").children(".scene-id").val(scenenumber);
        $(descriptiontitle).html(title);
        $(".description-section").children("#description-text").val(text);
        descriptionmodal.modal("show");
    })

    $(descsave).on("click", function () {
        var text = $("#description-text").val();
        var sceneid = $(".scene-id").val();
        var sceneitem = $("#description-" + sceneid).parents(".scene-wrapper");
        $(sceneitem).children("#description-" + sceneid).val(text);
        $(descriptionmodal).modal("hide");
    });

    $("#story-submit").on("click", function () {

        var scenes = $(".scene-section").children(".scene-main-wrapper");

        $("#scene-count").val(scenes.length);
    })
})