(function () {
    require.config({
        paths: {
            'jquery' : 'libs/jquery-2.1.1.min',
            'game': 'game'
        }
    });

    require(['game', 'jquery'], function (game, $) {
        var TheGame = new game();
        TheGame.init();
        console.log(TheGame)
    })
}());
