define([], function () {
    var Student = (function () {
        function Student(options) {
            this.name = options.name;
            this.age = options.age;
        }
        return Student
    }());
    return Student
});