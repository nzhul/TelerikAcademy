define([], function () {
    var Student = (function () {
        function Student(options) {
            this.firstName = options.firstName;
            this.lastName = options.lastName;
            this.age = options.age;
            this.marks = options.marks;
        }
        return Student
    }());
    return Student
});