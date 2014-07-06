define([], function () {
   var Course = (function () {
       function sortingMethodExam(firstStudent, secondStudent) {
           return secondStudent.exam - firstStudent.exam;
       }
       function sortingMethodTotalScore(firstStudent, secondStudent) {
           return secondStudent.totalResult - firstStudent.totalResult;
       }

       function Course(title, formula) {
           this.title = title;
           this.formula = formula;
           this._students = [];
       }

       Course.prototype = {
           addStudent: function (student) {
               this._students.push(student);
           },
           calculateResults: function () {
               for (var i = 0; i < this._students.length; i++) {
                   this._students[i].totalResult = this.formula(this._students[i]);
               }
           },
           getTopStudentsByExam: function (count) {
               var sortedStudents = this._students.sort(sortingMethodExam);
               return sortedStudents.slice(0, count);
           },
           getTopStudentsByTotalScore: function (count) {
               var sortedStudents = this._students.sort(sortingMethodTotalScore);
               return sortedStudents.slice(0, count);
           }
       }

       // Prototype

       return Course;
   }());
    return Course;
});