toastr.options = {
    "closeButton": true,
    "debug": false,
    "newestOnTop": true,
    "progressBar": true,
    "positionClass": "toast-top-right",
    "preventDuplicates": true,
    "onclick": null,
    "showDuration": "300",
    "hideDuration": "1000",
    "timeOut": "5000",
    "extendedTimeOut": "1000",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "fadeOut"
}

var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
    return new bootstrap.Tooltip(tooltipTriggerEl)
})

$('input').change(function () {
    //tüm alanlar doldurulduysa submit butonuna basılmasına izin ver
    if ($('#nameField').val() != '' && $('#surnameField').val() != '' && $('#ageField').val() != '' && $('#genderField').val() != '' && $('#emailField').val() != '' && $('#messageField').val() != '' && $('#emailField').val().match(/^[a-zA-Z0-9.!#$%&’+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)$/) && $('#gridCheck').is(':checked')) {
        $('#submitButton').prop('disabled', false);
        $('#errorMessage').attr('data-bs-original-title', '');
    } else {
        $('#submitButton').prop('disabled', true);
        $('#errorMessage').attr('data-bs-original-title', 'Lütfen tüm alanları doğru ve eksiksiz doldurunuz!');
    }
});