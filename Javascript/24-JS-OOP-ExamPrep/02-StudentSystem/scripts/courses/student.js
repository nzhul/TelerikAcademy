define([], function () {
   var Student = (function () {
       function Student(options) {
           this.name = options.name;
           this.exam = options.exam;
           this.homework = options.homework;
           this.attendance = options.attendance;
           this.teamwork = options.teamwork;
           this.bonus = options.bonus;
       }
       return Student;
   }());
    return Student;
});