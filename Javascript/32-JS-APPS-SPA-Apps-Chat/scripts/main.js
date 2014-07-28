(function () {
    require.config({
        paths: {
            'jquery' : 'libs/jquery-2.1.1.min',
            'sammy' : 'libs/sammy',
            'requestModule' : 'libs/requestModule',
            'user' : 'user',
            'mainController' : 'controllers/mainController'
        }
    });

    require(['mainController'], function (mainController) {

        var rootUrl = 'http://crowd-chat.herokuapp.com/posts';
        var theController = new mainController(rootUrl);

        theController.loadUI('#wrapper');
    })
}());