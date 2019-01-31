$(function () {

    $('.btnFiltrar').click(function () {
        var tabela = $(this).attr('idTabela');
        $("input[idTabela='" + tabela + "'], select[idTabela='" + tabela + "']").each(function () {
            var valor = $(this).val();
            if (valor != null && valor != undefined) {
                $('#' + tabela).DataTable().columns($(this).attr('indiceTabela')).search(valor);
            }
        });
        $('#' + tabela).DataTable().draw();

    });

    $('.btnLimpar').click(function () {
        $("input[indiceTabela]").each(function () {
            $(this).val("");
        });

        $("select[indiceTabela]").each(function () {
            $(this).val($(this).children().first('option').val()).trigger("change");
        });
        
        $(this).parent().siblings().children('.btnFiltrar').click();

    });
});

