(function () {
    require.config({
        paths: {
            'student' : 'student',
            'chance' : 'libs/chance.min'
        }
    });

    require(['student', 'chance'], function (Student) {

        var allStudents = [];
        for (var i = 0; i < 20; i++) {
            allStudents.push(new Student({
                name: chance.first(),
                age: chance.integer({min: 16, max: 92})
            }));
        }
        console.log(allStudents);
    })
}());
