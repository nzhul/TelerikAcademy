(function () {
    require.config({
        paths: {
            'engine' : 'engine',
            'async': 'libs/async',
            'jquery': 'libs/jquery-2.1.1.min'
        }
    });

    require(['engine'], function (Engine) {
        var theEngine = new Engine().init();
        theEngine.addCity('Sofia');
        theEngine.addCity('Варна');
    })
}());
