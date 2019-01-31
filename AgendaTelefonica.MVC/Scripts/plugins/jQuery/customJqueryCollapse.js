$(document).ready(function () {

    $('.input-validation-error,.field-validation-error').each(function () {

        if ($(this).closest('.panel-collapse') != undefined) {
            var collap = $(this).closest('.panel-collapse').attr('id');
            $('#' + collap).collapse('show');
            return;
        }

    });

});