$(document).ready(function () {

    var tplm = 1;
    $('#AddtoBasket').click(function (e) {

        var productdtID = $(this).attr("contextmenu");
        var size = $('#Sizes').find(":selected").text();
        var quantity = $('#Quantity').find(":selected").text();

        //Sepet sayısını bulmak için//
        var str = $('#SepetUrunSayisi').text().trim();
        if (str == "Sepet Boş") {
            $('#SepetUrunSayisi').empty();
            $('#SepetUrunSayisi').append("<span id=\"SepetUrunSayisi\">Sepetinizdeki Ürünler (0) </span>");

        } else {
            str = str.substring(23);
            var s = 0;
            for (var i = 0; i < str.length; i++) {
                s++;
            }
            var a = s - 1;
            var sayi = 0;
            sayi = str.substring(0, a);
            tplm = parseInt(sayi) + parseInt(1);
        }

        //--Sepet sayısını bulmak için--//

        $.ajax({
            type: "POST",
            url: "/ProductDetail/AddtoBasket",
            content: "application/json; charset=utf-8",
            dataType: "json",
            data: { productdtID: productdtID, size: size, quantity, quantity },
            success: function (data) {

                $('#SepetUrunSayisi').empty();
                $('#lnkSepetGoruntule').empty();
                $('#SepetUrunSayisi').append("<span id=\"SepetUrunSayisi\">Sepetinizdeki Ürünler (" + tplm + ") </span>");

                var html = "<div class=\"cart_box\">" +
                           "<div class=\"message\">" +
                           "<div class=\"list_img\"><img src=\"../Content/Theme/images/15.jpg\" class=\"img-responsive\">" +
                           "</div>" +
                           "<div class=\"list_desc\">" +
                           "<h4><a href=\"#\">" + data.prcName + "</a></h4>" +
                           "<p>" + data.prcDesription + " </p>" +
                           "<a href=\"#\" id=\"basketQuantity\" class=\"offer\">" + data.prcQuantity + " Teklif Uygulandı</a>" +
                           "</div>" +
                           "<div class=\"clearfix\"></div>" +
                           "</div>" +
                           "</div>";
                $("#Basket").append(html);

                var lnkhtml = '<a href="/Checkout"><span>Sepeti Görüntüle</span></a>';
                $("#lnkSepetGoruntule").append(lnkhtml);


                toastMessage("Ürün Sepete Eklendi", "1");

            },
            error: function () {

                toastMessage("İşlem başarısız", "2");

            }
        });





    });


    $(document).on("change", "#txtAdetGuncelle", function () {

        var productdtID = $(this).attr('name');
        var quantity = $(this).val();
        var size = $(this).attr('contextmenu');

        if (quantity == '0' || !quantity.trim()) {
            quantity = 1;
        }
        $.ajax({
            type: "POST",
            url: "/Checkout/checkoutUpdate",
            content: "application/json; charset=utf-8",
            dataType: "json",
            data: { productdtID: productdtID, size: size, quantity, quantity },
                    success: function (data) {


                        if (parseInt(data) > 0) {
                            toastMessage("Sepet Güncellendi", "1");
                        }
                        else
                        {
                            toastMessage("Yeterli Stok Bulunmuyor", "3");
                        }



                    },
            error: function () {

                toastMessage("İşlem başarısız", "2");

            }
        });




    });






    $(document).on("click", "#sepettenCikar", function () {


        var productdtID = $(this).val();
        var quantity = $(this).attr('title');
        var size = $(this).attr('contextmenu');


        $.ajax({
            type: "POST",
            url: "/Checkout/checkoutDelete",
            content: "application/json; charset=utf-8",
            dataType: "json",
            data: { productdtID: productdtID, size: size, quantity, quantity },
                    success: function (data) {
                        if (parseInt(data) > 0) {

                            toastMessage("Sepetten Çıkarıldı", "1");
                            window.location.href = "/Checkout/Index";

                        } else {
                            toastMessage("Sepet Güncellenemedi", "2");
                        }



                    },
            error: function () {

                toastMessage("İşlem başarısız", "2");

            }
        });
    });




    $(document).on("click", "#SiparisOzet", function () {


        var adSoyad = $('#txtAdSoyad').val();
        var ulke = $('#slcUlke').find(":selected").text();
        var sehir = $('#txtSehir').val();
        var postaKodu = $('#txtPostaKodu').val();
        var adres = $('#txtAdres').val();

        if (!adSoyad.trim() || ulke.trim() == 'Ülke Seçiniz' || !sehir.trim() || !postaKodu.trim() || !adres.trim()) {

            toastMessage("Bütün alanları doldurunuz", "3");

        } else {
            $.ajax({
                type: "POST",
                url: "/Checkout/AddAddress",
                content: "application/json; charset=utf-8",
                dataType: "json",
                data: { adSoyad: adSoyad, ulke: ulke, sehir, sehir, postaKodu: postaKodu, adres: adres},
                success: function (data) {
                    if (parseInt(data) > 0) {

                        window.location.href = "/OrderSummary/Index";


                    } else {
                        toastMessage("Sepet Güncellenemedi", "2");
                    }



                },
                error: function () {

                    toastMessage("İşlem başarısız", "2");

                }
            });
        }

    });



});