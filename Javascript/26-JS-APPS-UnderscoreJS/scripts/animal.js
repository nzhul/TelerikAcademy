define([], function () {
    var Animal = (function () {
        function Animal(options) {
            this.name = options.name;
            this.species = options.species; // The word Species is used for both single and plural form. You can google it :)
            this.legsCount = options.legsCount;
        }

        return Animal
    }());
    return Animal
});