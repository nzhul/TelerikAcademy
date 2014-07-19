(function () {
    require.config({
        paths: {
            'game' : 'game',
            'chance': 'libs/chance.min'
        }
    });

    require(['game'], function (Game) {
        var theGame = new Game();
        theGame.startGame();

        console.log('-- Computer Number --');
        console.log(theGame.guessNumber);
    })
}());
