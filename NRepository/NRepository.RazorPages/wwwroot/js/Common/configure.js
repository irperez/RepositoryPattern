function configure() {
    var base64String = $("#__pageModelConfig").val();

    var jsonString = atob(base64String);

    return JSON.parse(jsonString);
}