(function () {
    require.config({
        paths: {
            'requestModule' : 'requestModule',
            'jquery': 'libs/jquery-2.1.1.min',
            'underscore': 'libs/underscore',
            'cryptojs': 'libs/cryptojs',
            'mainPersister' : 'persisters/mainPersister',
            'userPersister' : 'persisters/userPersister',
            'postsPersister' : 'persisters/postsPersister',
            'mainController' : 'controllers/mainController'


        }
    });

    require(['requestModule', 'mainController'], function (requestModule, MainController) {

        var rootUrl = 'http://localhost:3000/';

        var controller = new MainController(rootUrl);
        controller.loadUI('#wrapper');

    })
}());