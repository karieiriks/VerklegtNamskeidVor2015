
function readURL(input, imgid) {
    if(input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#' + imgid).attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
    }
}

$(document).ready(function () {

    var createButton = $("#story-create");
    var createModal = $("#story-create-modal");
    var descriptionModal = $("#description-modal");
    var descriptionTitle = $("#description-modal .modal-title");
    var descSave = $(".description-save-button");
    var storySection = $(".story-section");
    var displayModal = $("#story-display-modal");
    var addNewScenePanel = $("#add-new-scene-panel");
    var sceneTemplate = $(".scene-template");
    var addScenesSection = $(".scenes-added-section");
    var sceneCount = $("#scene-count");
    var storyTitle = $("#story-title");

    var clearCreationModal = function () {
        $(sceneCount).val(0);
        $(addscenessection).html("");
        $(storytitle).val("");
        $("#title-error").html("");
    }

    $(createButton).click(function () {
        clearCreationModal();

        createModal.modal("show");
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
        $(descriptionTitle).html(title);
        $(".description-section").children("#description-text").val(text);
        descriptionModal.modal("show");
    })

    $(descSave).on("click", function () {
        var text = $("#description-text").val();
        var sceneid = $(".scene-id").val();
        var sceneitem = $("#description-" + sceneid).parents(".scene-wrapper");
        $(sceneitem).children("#description-" + sceneid).val(text);
        $(descriptionModal).modal("hide");
    });

    $("#story-submit").on("click", function (event) {

        if($(storyTitle).val() == "" || $(storyTitle).val() == null) {
            event.preventDefault();
            $("#title-error").html("You must give the story a title");
        }

        var inputs = $(addScenesSection).find(".img-input");
        
        $(inputs).each(function () {
            if($(this).val() == "" || $(this).val() == null) {
                event.preventDefault();
                var errorstatus = $(this).parents(".scene-main-wrapper").find(".file-error-status");
                errorstatus.html("Please insert an image for the scene");
            }
        })

    });

    $(".story-link").on("click", function (event) {
        event.preventDefault();
        var title = $(this).html();
        var item = $(this).parents(".story-wrapper");
        var storyimg = $(item).find("img");
        var displayimg = $(storyimg).clone();
        displayimg.removeClass("hidden");
        storySection.html("");
        displayimg.appendTo(storySection);
        $(displayModal).find(".modal-title").html(title);
        displayModal.modal("show");
    });

    $(addNewScenePanel).on("click", function () {
        var newscene = $(sceneTemplate).clone(true, true);
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


        $(newscene).appendTo(addScenesSection);
        currNumbOfScenes = currNumbOfScenes + 1;
        $(sceneCount).val(currNumbOfScenes);
    });

    $(".scene-main-wrapper").hover(function () {
        $(this).css("background-color", "rgba(170, 71, 71, 0.45)");
    }, function () {
        $(this).css("background-color", "rgba(255, 255, 255, 0.98)")
    })
});