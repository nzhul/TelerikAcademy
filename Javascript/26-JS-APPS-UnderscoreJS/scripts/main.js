(function () {
    require.config({
        paths: {
            'student' : 'student',
            'chance' : 'libs/chance.min',
            'underscore': 'libs/underscore-min'
        }
    });

    require(['student', 'chance', 'underscore'], function (Student, Chance, _) {

        // Helpers
        var Chance = new Chance();
        function generateRandomMarks() {
            var allMarks = [];
            for (var j = 0; j < 10; j++) {
                allMarks.push(Chance.integer({min: 2, max: 6}))
            };
            return allMarks;
        }

        //Generate Random Students
        var allStudents = [];
        for (var i = 0; i < 20; i++) {
            allStudents.push(new Student({
                firstName: Chance.first(),
                lastName: Chance.last(),
                age: Chance.age({type: 'adult'}),
                marks: generateRandomMarks()
            }));
        }

        function filterAndSortFirstNameBeforeLastName(students) {
            var filtered = _.filter(students, function(student){
                if(student.firstName < student.lastName){
                    return true;
                } else {
                    return false;
                }
            });
            var sorted = _.sortBy(filtered, 'firstName').reverse();
            return sorted;
        }

        console.log(allStudents);
        console.log('--------------------')
        console.log(filterAndSortFirstNameBeforeLastName(allStudents))
    })
}());
