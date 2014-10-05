var mongodb = require('mongodb');

var server = new mongodb.Server('localhost', 27017);
var client = new mongodb.MongoClient(server);

client.open(function (err, client) {
   var db = client.db('students');
    var courses = db.collection('courses');

    courses.insert({name: 'AngularJS', lectures: 10}, function (err, course) {
        courses.find({$or: [{name: 'AngularJS'}, {name: 'NodeJS'}]})
            .toArray(function (err, results) {
                console.log(results);
            });
    });
});