$(function () {

    if ($("#flTipo").val() == "F") {
        $(".fisica").show();
        $(".juridica").hide();
    } else {
        $(".fisica").hide();
        $(".juridica").show();
    }

    $("#flTipo").change(function () {
        if ($("#flTipo").val() == "F") {
            $(".fisica").slideDown("slow");
            $(".juridica").slideUp("slow");
        } else {
            $(".fisica").slideUp("slow");
            $(".juridica").slideDown("slow");
        }

    });

});
