
$(document).ready(function () {

    var tab = $('.input-validation-error,.field-validation-error').first().closest('.tab-pane').attr('id');
    if (tab !== undefined) {
        $('.nav-tabs a[href="#' + tab + '"]').tab('show'); //Exibe a primeira aba
    }

});