(function () {
    require.config({
        paths: {
            'requestModule': 'requestmodule',
            'q' : 'q.min',
            'chance': '../bower_components/chance/chance'
        }
    });

    require(['requestModule', 'q', 'chance'], function (requestModule) {

        var url = 'http://localhost:3000/students';
        var headerOptions = {
            contentType: 'application/json',
            accept: 'application/json'
        };
        var notificationArea = document.getElementById('notificationArea');

        function removeChildNodes(parentNode) {
            while (parentNode.firstChild) {
                parentNode.removeChild(parentNode.firstChild);
            }
        }

        function initAddStudent() {
            var addStudentBtn = document.getElementById('addStudentBtn');
            addStudentBtn.addEventListener('click', function () {
                var simpleStudent = {
                    name: chance.first(),
                    grade: chance.integer({min: 2, max: 6})
                };

                notificationArea.innerHTML = '... processing request ...';
                requestModule.postJSON(url, simpleStudent, headerOptions)
                    .then(function () {
                        notificationArea.innerHTML = '<span style="color: green">Random Student Successfully added to the server database!</span>';
                    });
            })
        }

        function initGetAllStudents() {
            var getAllStudentsBtn = document.getElementById('getAllStudentsBtn');
            var studentsList = document.getElementById('studentsList');
            var fragment = document.createDocumentFragment();
            var studentLiElementTemplate = document.createElement('li');

            getAllStudentsBtn.addEventListener('click', function () {
                notificationArea.innerHTML = '... processing request ...';
                removeChildNodes(studentsList);
                requestModule.getJSON(url, headerOptions)
                    .then(function (data) {
                        var parsedData = JSON.parse(data);
                        var len = parsedData.count;
                        for (var i = 0; i < len; i++) {
                            var currentStudentElement = studentLiElementTemplate.cloneNode(true);
                            currentStudentElement.innerHTML =
                                parsedData.students[i].id + ': ' +
                                parsedData.students[i].name+' - grade: '+
                                parsedData.students[i].grade;
                            fragment.appendChild(currentStudentElement);
                        }
                        studentsList.appendChild(fragment);
                    })
                    .then(function () {
                        notificationArea.innerHTML = '';
                    })
            });
        }

        initAddStudent();
        initGetAllStudents();

        // Student Deletion does not work properly and i don't know why
        // but i couldn't fix it.
        //requestModule.deleteStudent('http://localhost:3000/students/1');
    })
}());