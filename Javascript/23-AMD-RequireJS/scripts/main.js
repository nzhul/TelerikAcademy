define(['data', 'combobox'], function (data, combobox) {
    var run = function () {
        var myCombobox = combobox.get(data.getCharacters());
        myCombobox.renderTemplate('#combobox-template');
    }

    return {
        run: run
    }
})