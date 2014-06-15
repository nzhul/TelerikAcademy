$.fn.listView = function (collection) {
    var $selector = this,
		templateId = $selector.attr('data-template'),
		templateSource = $('#' + templateId).html(),
		template = Handlebars.compile(templateSource);

    collection.forEach(function (item) {
        var generatedHTML = template(item);
        $selector.append(generatedHTML);
    });

    return $selector;
};
