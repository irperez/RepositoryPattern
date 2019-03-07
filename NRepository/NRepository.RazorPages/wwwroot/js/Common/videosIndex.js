$(document).ready(function () {
    // <div class="video" onmouseenter="$(this).children('.detail').slideDown(750)" onmouseleave="$(this).children('.detail').slideUp(250)"

    $(".video").hover(function () {
        $(this).children('.detail').slideDown(750);
    },
        function () {
            $(this).children('.detail').slideUp(250)
        }
    );

    var pageData = configure();

    console.dir(pageData);

    listDebugData(pageData);
});

function listDebugData(model) {
    var debugObject = {
        FirstVideoTitle: model[0].Title,
        LastVideoTitle: model[model.length - 1].Title,
        VideoCount: model.length
    };

    console.dir(debugObject);

    var debugDiv = $("body").append("<div class='debug'></div>");
    $("div.debug").html(
        "<ul>\
                <li>First Video Title: " + debugObject.FirstVideoTitle + "</li >\
                <li>Last Video Title: " + debugObject.LastVideoTitle + "</li >\
                <li>Video Count: " + debugObject.VideoCount + "</li>\
            </ul>");
}

