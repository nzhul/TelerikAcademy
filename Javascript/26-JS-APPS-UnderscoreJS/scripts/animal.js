define([], function () {
    var Animal = (function () {
        function Animal(options) {
            this.firstName = options.firstName;
        }

        Animal.prototype = {

        };

        return Animal
    }());
    return Animal
});