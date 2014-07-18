(function () {
    require.config({
        paths: {
            'student' : 'student',
            'animal' : 'animal',
            'book' : 'book',
            'chance' : 'libs/chance.min',
            'underscore': 'libs/underscore-min'
        }
    });

    require(['student', 'animal', 'book', 'chance', 'underscore'], function (Student, Animal, Book, Chance, _) {

        // STUDENTS  ------------------

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
        console.log('--------- Initial array of STUDENTS -----------');
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
        console.log('The best student is: ' + bestStudent.firstName + ' ' + bestStudent.lastName +' with average grade: ' + bestStudent.getAverageScore());
        console.log(bestStudent);


        // ANIMALS ------------------

        // Generate random Animals
        var allAnimals = [];
        var allowedLegCount = [2, 4, 8, 100];
        var allowedSpecies = ['Mammals', 'Reptiles', 'Birds', 'Insects', 'Aquatic Animals'];
        for (var i = 0; i < 20; i++) {
            allAnimals.push(new Animal({
                name: Chance.first(),
                legsCount: allowedLegCount[Chance.integer({min: 0, max: allowedLegCount.length - 1})],
                species: allowedSpecies[Chance.integer({min: 0, max: allowedSpecies.length - 1})]
            }));
        }

        function groupByAndSort(animals) {
            var grouped = _.groupBy(_.sortBy(animals, 'legsCount'), 'species');
            return grouped;
        }

        function totalLegsCount(animals) {
            var totalLegsCount = 0;
            for (var i = 0; i < animals.length; i++) {
                totalLegsCount += animals[i].legsCount;
            }
            return totalLegsCount;
        }


        console.log(' ');
        console.log('--------- Initial array of ANIMALS -----------');
        console.log(' ');
        console.log(allAnimals);

        console.log(' ');
        console.log('--------- Task 4: by a given array of animals, groups them by species and sorts them by number of legs -----------');
        console.log(' ');
        console.log(groupByAndSort(allAnimals));

        console.log(' ');
        console.log('--------- Task 5: By a given array of animals, find the total number of legs -----------');
        console.log(' ');
        console.log('The total legs count of all animals is: ' + totalLegsCount(allAnimals));


        // BOOKS ------------------

        // Generate random BOOKS
        var allBooks = [];
        var booksTitleList = ['The Shining', 'Pet Sematary', 'The Stand', 'Dr. Sleep', 'Hamlet', 'Macbeth', 'Romeo and Juliet', 'Othello', 'And Then There Were None', 'Murder on the Orient Express'];
        var authorsList = ['Steven King', 'William Shakespeare', 'Agatha Christie'];
        for (var i = 0; i < booksTitleList.length; i++) {
            allBooks.push(new Book({
                title: booksTitleList[i],
                author: authorsList[Chance.integer({min: 0, max: authorsList.length - 1})]
            }));
        }

        function findMostPopularAuthor(books) {
            // TODO: CODE HERE NOT RDY
        }

        console.log(allBooks);



    })
}());
