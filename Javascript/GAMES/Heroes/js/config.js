(function () {
    require.config({
        paths: {
            'gameObject': 'gameobject',
            'main': 'main',
            'constants': 'constants',
            'layer': 'layer',
            'renderer': 'renderer',
            'engine': 'engine',
            'mouse': 'mouse'
        }
    });

    require(['main'], function (main) {
        main.run();
    })
}());
