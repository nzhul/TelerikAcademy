define([], function () {
    var Student = (function () {
        function Student(options) {
            this.firstName = options.firstName;
            this.lastName = options.lastName;
            this.age = options.age;
            this.marks = options.marks;
        }

        Student.prototype = {
          getAverageScore: function () {
              var sum = 0;
              for (var i = 0; i < this.marks.length; i++) {
                  sum += this.marks[i];
              }
              return sum / this.marks.length;
          }  
        };

        return Student
    }());
    return Student
});