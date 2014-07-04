define(['data', 'combobox'], function (characters, combobox) {
    var run = function () {
        var myCombobox = combobox.getComboBoxController(characters);
        myCombobox.renderTemplate('#combobox-template');
        myCombobox.createCombo('#combobox-root');
    }

    return {
        run: run
    }
})