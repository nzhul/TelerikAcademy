var mongoose = require('mongoose');


mongoose.connect('localhost:27017');
var db = mongoose.connection;


db.once('open', function (err) {
    if(err){
        console.log(err);
    }
    console.log('MongoDb DataBase up and running ...')
});

db.on('error', function (err) {
    console.log(err);
});

var studentSchema = new mongoose.Schema({
   firstName: {type: String, required: true },
   lastName: String,
   age: {type: Number, min: 0, max: 120, required: true }
});

var Student = mongoose.model('Student', studentSchema);

var courseSchema = new mongoose.Schema({
    name: String,
    students: [studentSchema]
});

var Course = mongoose.model('Course', courseSchema);

courseSchema.methods.printStudents = function () {
    console.log(this.students.length);
};

var newStudent = new Student();
newStudent.firstName = 'Ivan';
newStudent.age = 15;
newStudent.save(function (err, student) {
    var newCourse = new Course();
    newCourse.name = 'C#';
    newCourse.students.push(student);
    newCourse.save(function (err, course) {
        course.printStudents();
    })
});