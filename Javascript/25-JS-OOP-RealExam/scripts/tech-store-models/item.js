define([], function () {

    // Constructor Validation helpers
    var validTypes = ['accessory', 'smart-phone', 'notebook', 'pc', 'tablet'],
        nameMinLength = 6,
        nameMaxLength = 40;

    function nameIsValid(name) {
        if(name.length >= nameMinLength && name.length <= nameMaxLength){
            return true
        }
    }

    function typeIsValid(type) {
        return validTypes.indexOf(type) > -1;
    }

    function getAllValidTypesAsString(validTypes) {
        var output = '';
        for (var i = 0; i < validTypes.length; i++) {
            output += validTypes[i] + ' ';
        }
        return output;
    }
    // helpers end

    var Item = (function () {
        function Item(type, name, price) {
            if(typeIsValid(type)){
                this.type = type;
            } else {
                throw new Error('Invalid type: the type must be one of the following: ' + getAllValidTypesAsString(validTypes));
            }
            if(nameIsValid(name)){
                this.name = name;
            } else {
                throw new Error('Invalid name: the name must be between '+ nameMinLength +' and '+nameMaxLength+' characters long');
            }
            this.price = price;
        }
        return Item;
    }());
    return Item;
});