$(document).ready(function () {

    $("#login-submit").click(function (e) {


        var user = $("#email").val().trim();
        var pass = $("#password").val();

        if (!user.trim() || !pass.trim()) {
            toastMessage("Kulanıcı Adı veya Şifre Boş", "3");
        }
        else {
            $.ajax({
                type: "POST",
                url: "/Login/LoginControl",
                content: "application/json; charset=utf-8",
                dataType: "json",
                data: { user: user, pass: pass },
                success: function (data) {
                    if (Boolean(data) == true) {
                        toastMessage("İşlem Başarılı", "1");
                        window.location.href = "/Home/Index";

                    } else {
                        toastMessage("Kullanıcı Adı veya Şifre Hatalı", "2");
                    }
                },
                error: function () {
                    toastMessage("Kullanıcı Adı veya Şifre Hatalı", "2");
                }
            });
        }
    });



    $("#register-submit").click(function (e) {


        var reNameSurname = $("#reName_Surname").val().trim();
        var reEmail = $("#reEmail").val().trim();
        var rePass = $("#rePassword").val().trim();
        var reRePass = $("#reConfirm-password").val().trim();

        if (!reNameSurname.trim() || !reEmail.trim() || !rePass.trim()) {

            toastMessage("Lütfen Alanaları Doldurunuz", "3");

        }
        else {

            if (rePass != reRePass) {

                toastMessage("Girdiğiniz şifreler uyumsuz", "3");
            }
            else {

                $.ajax({
                    type: "POST",
                    url: "/Login/Register",
                    content: "application/json; charset=utf-8",
                    dataType: "json",
                    data: { reNameSurname: reNameSurname, reEmail: reEmail, rePass: rePass },
                    success: function (data) {
                        if (Boolean(data) == true) {
                            toastMessage("İşlem Başarılı", "1");
                            window.location.href = "/Home/Index";
                        } else {
                            toastMessage("Kullanıcı Adı Sistemde Kayıtlı Olabilir", "3");
                        }
                    },
                    error: function () {
                        toastMessage("Kayıt Oluşurken Hata Oluştu", "2");
                    }
                });
            }
        }
    });








});
