$(document).ready(function () {
    $("#search-link").click(function (e) {
        e.preventDefault();
        var theValue = $("#search-bar").val();
        if (theValue == "") {
            return;
        }

        $.get("/Home/Search", { value: theValue }, function (data) {
            $("#search-result-area").html("");
            var length = Object.keys(data.searchResults).length;
            var searchResultContainer = $("<div></div>").addClass("search-result-container");
            if (length == 0) {
                searchResultContainer.html("<p>Nothing found</p>");
            }

            for(var i = 0; i < length; i++) {
                var searchItem = $("<div></div>").addClass("search-item");
                var imageContainer = $("<div></div>").addClass("user-picture-slot").appendTo(searchItem);
                $("<img/>").attr({ src: data.imageDirectory + data.searchResults[i].ProfileImageName, alt: "Profile Image" }).appendTo(imageContainer);
                var nameContainer = $("<div></div>").addClass("user-name-section").appendTo(searchItem);
                $("<h6></h6>").html("<a href='/Profile/UserWall/" + data.searchResults[i].Id + "'>" + data.searchResults[i].FullName + "</a>").appendTo(nameContainer);
                $(searchItem).appendTo(searchResultContainer);
            }
            $(searchResultContainer).appendTo("#search-result-area");

            $("#my-search-modal").modal("show");
        }).fail(function (xhr, errorthrown) {
            console.log("xhr.status: " + xhr.status);
            console.log("xhr.statusText: " + xhr.statusText);
            console.log("xhr.readyState: " + xhr.readyState);
            console.log("xhr.responseText: " + xhr.responseText);
            console.log("xhr.responseXML: " + xhr.responseXML);
            console.log("textStatus: " + textStatus);
            console.log("errorThrown: " + errorThrown);
            console.log("xhr.redirect: " + xhr.redirect);
        });
    });
});