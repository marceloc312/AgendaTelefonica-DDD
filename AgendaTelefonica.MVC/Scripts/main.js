function addNestedForm(container, counter, ticks, content, elemento) {
    debugger;
    var nextIndex = $(counter).length;
    var pattern = new RegExp(ticks, "gi");
    content = content.replace(pattern, nextIndex);

    if (container.substr(0, 1) == '.') {
        elemento.parent().parent().siblings(container).append(content);
    } else {
        $(container).append(content);
    }
}

function removeNestedForm(element, container, deleteElement) {
    $container = $(element).parents(container);
    $container.find(deleteElement).val('True').change();
    $container.find('input,select').addClass('noValidade');
    $container.hide();
}
