(function () {
    require.config({
        paths: {
            'requestModule' : 'requestModule',
            'jquery': '../bower_components/jquery/dist/jquery',
            'cryptojs': 'libs/cryptojs',
            'mainPersister' : 'persisters/mainPersister',
            'userPersister' : 'persisters/userPersister',
            'gamePersister' : 'persisters/gamePersister',
            'guessPersister' : 'persisters/guessPersister',
            'messagePersister' : 'persisters/messagePersister',
            'mainController' : 'controllers/mainController'

        }
    });

    require(['requestModule', 'mainController'], function (requestModule, MainController) {

        var rootUrl = 'http://localhost:40643/api/';

        var controller = new MainController(rootUrl);
        controller.loadUI('#wrapper');

    })
}());