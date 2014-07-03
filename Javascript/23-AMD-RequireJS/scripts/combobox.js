define(['handlebars'], function (hb) {
    var ComboBox = function (data) {
        if(Array.isArray(data)){
            this.data = data;
        } else {
            this.data = ["Empty Data Array"];
        }
    };

    ComboBox.prototype.renderTemplate = function (templateSelector) {
        var comboBoxTemplate = document.querySelector(templateSelector);
        var hbTemplate = hb.compile(comboBoxTemplate);
        document.getElementById('combobox-root').innerHTML = hbTemplate(this.data);
    };

    function getNewComboBox(data) {
        return new ComboBox(data)
    }



    return {
        get: getNewComboBox
    }
});