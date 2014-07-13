(function () {
    require.config({
        paths: {
            'gameObject': 'gameobject',
            'main': 'main',
            'constants': 'constants',
            'layer': 'layer',
            'renderer': 'renderer',
            'engine': 'engine'
        }
    });

    require(['main'], function (main) {
        main.run();
    })
}());
