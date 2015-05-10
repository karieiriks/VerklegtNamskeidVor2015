$(document).ready(function () {
    $("#search-link").click(function (e) {
        e.preventDefault();
        var theValue = $("#search-bar").val();
        $.get("/Home/Search", { value: theValue }, function (data) {
            var length = Object.keys(data.searchResults).length;
            var searchresultcontainer = $("<div></div>").addClass("search-result-container");
            for (var i = 0; i < length; i++) {
                var searchitem = $("<div></div>").addClass("search-item");
                var imagecontainer = $("<div></div>").addClass("user-picture-slot").appendTo(searchitem);
                $("<img/>").attr({ src: data.imageDirectory + data.searchResults[i].ProfileImageName, alt: "Profile Image" }).appendTo(imagecontainer);
                var namecontainer = $("<div></div>").addClass("user-name-section").appendTo(searchitem);
                $("<h6></h6>").html("<a href='/Profile/UserWall/" + data.searchResults[i].Id + "'>" + data.searchResults[i].FullName + "</a>").appendTo(namecontainer);
                $(searchitem).appendTo(searchresultcontainer);
            }
            $(searchresultcontainer).appendTo("#search-result-area");
            $("#my-search-modal").modal("show");
        });
    });
});