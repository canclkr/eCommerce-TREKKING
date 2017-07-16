function toastMessage(message, tip) {
    toastr.options = {
        "closeButton": true,
        "debug": false,
        "positionClass": "toast-bottom-right",
        "onclick": null,
        "showDuration": "1000",
        "hideDuration": "1000",
        "timeOut": 5000,
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }
    switch (tip) {
        case "1":
            toastr.success(message);
            break;
        case "2":
            toastr.error(message);
            break;
        case "3":
            toastr.warning(message);
            break;
        default:
            break;
    }
}
