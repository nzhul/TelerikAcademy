define(['jquery','handlebars'], function ($) {
    var ComboBox = function (characters) {
        if(Array.isArray(characters.characters)){
            this.characters = characters;
        } else {
            this.characters = ["Empty Data Array"];
        }
    };

    ComboBox.prototype = {
        renderTemplate: function (templateSelector) {
            var comboBoxTemplate = document.querySelector(templateSelector).innerHTML;
            var hbTemplate = Handlebars.compile(comboBoxTemplate);
            document.getElementById('combobox-root').innerHTML = hbTemplate(this.characters);
        },
        createCombo: function (selector) {
            var parent = $(selector);
            var allElements = parent.children().hide();
            var selectedElement;

            var selectBtn = $('#selectBtn');
            selectBtn.on('click', function () {
                allElements.show();
            });

            allElements.on('click', function () {
                selectedElement = $(this);
                allElements.hide();
                selectedElement.show();
                selectBtn.hide();
                selectedElement.on('click', function () {
                    allElements.show();
                    selectedElement = null;
                })

            });
        }
    };

    function getNewComboBox(data) {
        return new ComboBox(data)
    }



    return {
        getComboBoxController: getNewComboBox
    }
});