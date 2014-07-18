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

        function filterSpecificAgeRange(students) {
            var filtered = _.map(_.filter(students, function (student) {
                    if(student.age >= 18 && student.age <= 24){
                        return true;
                    } else {
                        return false;
                    }
                }),
                function(student) {
                    return { firstName: student.firstName, lastName: student.lastName, age: student.age };
                }
            );
            return filtered;
        }

        function findBestStudent(students) {
            var bestStudent = _.max(students, function(student){ return student.getAverageScore(); });
            return bestStudent;
        }

        console.log(' ');
        console.log('--------- Initial array of students -----------');
        console.log(' ');
        console.log(allStudents);
        console.log(' ');
        console.log('--------- Task 1: Return all students whose first name is before its last name alphabetically. Descending order -----------');
        console.log(' ');
        console.log(filterAndSortFirstNameBeforeLastName(allStudents));
        console.log(' ');
        console.log('--------- Task 2: Finds the first name and last name of all students with age between 18 and 24 -----------');
        console.log(' ');
        console.log(filterSpecificAgeRange(allStudents));
        console.log(' ');
        console.log('--------- Task 3: Finds the student with highest marks -----------');
        console.log(' ');
        var bestStudent = findBestStudent(allStudents);
        console.log('The best student is: ' + bestStudent.firstName
                    + ' ' + bestStudent.lastName +' with average grade: '
                    + bestStudent.getAverageScore());
        console.log(bestStudent);
        console.log(' ');
        console.log('--------- Task 4: by a given array of animals, groups them by species and sorts them by number of legs -----------');
        console.log(' ');


    })
}());
