(function () {
    require.config({
        paths: {
            'jquery' : 'libs/jquery-2.1.1.min',
            'game': 'game',
            'levels': 'levels'
        }
    });

    require(['game', 'levels'], function (game, levels) {

        var TheGame = game.getInstance().init();

        // Initialize objects
        var Levels = new levels();
        Levels.addLevel({
            foreground: 'desert-foreground',
            background: 'clouds-background',
            entities: []
        }).addLevel({
            foreground: 'desert-foreground',
            background: 'clouds-background',
            entities: []
        }).addLevel({
            foreground: 'desert-foreground',
            background: 'clouds-background',
            entities: []
        }).init();


    })
}());
