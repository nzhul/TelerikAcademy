define([], function () {
    var Book = (function () {
        function Book(options) {
            this.title = options.title;
            this.author = options.author;
        }

        return Book
    }());
    return Book
});