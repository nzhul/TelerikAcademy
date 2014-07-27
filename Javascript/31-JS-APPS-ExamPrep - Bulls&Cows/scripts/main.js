(function () {
    require.config({
        paths: {
            'requestModule' : 'requestModule',
            'jquery': '../bower_components/jquery/dist/jquery',
            'cryptojs': 'libs/cryptojs',
            'mainPersister' : 'mainPersister',
            'userPersister' : 'userPersister',
            'gamePersister' : 'gamePersister',
            'guessPersister' : 'guessPersister',
            'messagePersister' : 'messagePersister',
            'mainController' : 'controllers/mainController'

        }
    });

    require(['requestModule', 'mainPersister', 'MainController'], function (requestModule, MainPersister, MainController) {

        var rootUrl = 'http://localhost:40643/api/';

        var controller = new MainController(rootUrl);


//        var bcPersister = new MainPersister(rootUrl);
//        console.log(bcPersister);
//
//        var userData = {
//            username: 'DobromirIvanov',
//            nickname: 'nzhul',
//            password: 'superp@ssword'
//        };
//
//        bcPersister.user.register(userData, function (data) {
//            alert(JSON.stringify(data));
//        }, function (err) {
//            alert(JSON.stringify(err));
//        });

    })
}());