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

        var simpleStudent = {
            name: chance.first(),
            grade: chance.integer({min: 2, max: 6})
        };

        console.log(simpleStudent);


        //var postResult = requestModule.postJSON(url, simpleStudent, headerOptions);
        //console.log(postResult);

        requestModule.getJSON(url, headerOptions)
            .then(function (data) {
                console.log(data);
            });
    })
}());