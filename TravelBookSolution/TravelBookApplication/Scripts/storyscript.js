
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

    var createbutton = $("#story-create");
    var createmodal = $("#story-create-modal");
    var descriptionmodal = $("#description-modal");
    var descriptiontitle = $("#description-modal .modal-title");
    var descsave = $(".description-save-button");
    var storysection = $(".story-section");
    var displaymodal = $("#story-display-modal");
    var addnewscenepanel = $("#add-new-scene-panel");
    var scenetemplate = $(".scene-template");
    var addscenessection = $(".scenes-added-section");
    var sceneCount = $("#scene-count");
    var storytitle = $("#story-title");

    var clearCreationModal = function () {
        $(sceneCount).val(0);
        $(addscenessection).html("");
        $("#title-error").html("");
    }

    $(createbutton).click(function () {
        clearCreationModal();

        createmodal.modal("show");
    })

    $(".img-input").on("change", function () {
        var wrapper = $(this).parents(".scene-wrapper");
        var imgid = $(wrapper).find("img").attr("id");
        $(wrapper).find(".description-button").removeAttr("disabled");
        var errorstatus = $(this).parents(".scene-main-wrapper").find(".file-error-status");
        errorstatus.html("");
        
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

    $("#story-submit").on("click", function (event) {

        if($(storytitle).val() == "" || $(storytitle).val() == null)
        {
            event.preventDefault();
            $("#title-error").html("You must give the story a title");
        }

        var inputs = $(addscenessection).find(".img-input");
        
        $(inputs).each(function () {
            if($(this).val() == "" || $(this).val() == null)
            {
                event.preventDefault();
                var errorstatus = $(this).parents(".scene-main-wrapper").find(".file-error-status");
                errorstatus.html("Please insert an image for the scene");
            }
        })

    });

    $(".story-link").on("click", function (event) {
        event.preventDefault();
        var item = $(this).parents(".story-wrapper");
        var storyimg = $(item).children(".story-info").children("img");
        var displayimg = $(storyimg).clone();
        displayimg.removeClass("hidden");
        storysection.html("");
        displayimg.appendTo(storysection);
        displaymodal.modal("show");
    });

    $(addnewscenepanel).on("click", function () {
        var newscene = $(scenetemplate).clone(true, true);
        newscene.removeClass("scene-template").removeClass("hidden");
        var currNumbOfScenes = Number($(sceneCount).val());
        $(newscene).find(".scene-header").html("Scene " + currNumbOfScenes);
        $(newscene).find("label").attr({
            for: "file-" + currNumbOfScenes
        });

        $(newscene).find("input[type=file]").attr({
            id: "file-" + currNumbOfScenes,
            name : "fileUpload[" + currNumbOfScenes + "]"
        });

        $(newscene).find(".description-input").attr({
            id: "description-" + currNumbOfScenes,
            name: "description-" + currNumbOfScenes
        });

        $(newscene).find("img").attr({
            id: "img-" + currNumbOfScenes
        });

        $(newscene).find(".scene-number").val(currNumbOfScenes);


        $(newscene).appendTo(addscenessection);
        currNumbOfScenes = currNumbOfScenes + 1;
        $(sceneCount).val(currNumbOfScenes);
    });

    $(".scene-main-wrapper").hover(function () {
        $(this).css("background-color", "rgba(170, 71, 71, 0.45)");
    }, function () {
        $(this).css("background-color", "rgba(255, 255, 255, 0.98)")
    })
});