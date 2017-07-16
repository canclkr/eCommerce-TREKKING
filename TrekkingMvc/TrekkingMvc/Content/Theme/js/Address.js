$(document).ready(function() {


    $("#AddAddress").click(function (e) {

        $('#AdresEkleme').slideDown();
        $('#AddAddress').remove();

        var html = " <a href=\"#\" class=\"hvr-shutter-in-horizontal\" id=\"SiparisOzet\">Devam Et</a>";
        $("#bosluk").after(html);

    });


});