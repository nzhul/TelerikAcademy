define(['gameObject', 'layer', 'constants', 'renderer', 'engine'], function (gameObject, Layer, CONST, renderer, engine) {
    var run = function () {
        var gameWidth = CONST.TILE_SIZE * CONST.LEVEL[0].length; // TileSize * Cols
        var gameHeight = CONST.TILE_SIZE * CONST.LEVEL.length; // TileSIze * ROws
        var staticGameLayers = [];

        var mainMenuLayer = document.getElementById('mainMenu');
        var inventoryLayer = document.getElementById('inventoryLayer');
        var otherLayer = document.getElementById('otherLayer');

        staticGameLayers.push(mainMenuLayer);
        staticGameLayers.push(inventoryLayer);
        staticGameLayers.push(otherLayer);

        for (var i = 0; i < staticGameLayers.length; i++) {
            staticGameLayers[i].style.width = gameWidth + 'px';
            staticGameLayers[i].style.height= gameHeight + 'px';
        }

        var mapLayer = new Layer('#root', {
            width: gameWidth,
            height: gameHeight,
            class: 'gameLayer',
            id: 'map'
        }).init();
        var mapContext = mapLayer.getCtx();

        var heroLayer = new Layer('#root', {
            width: gameWidth,
            height: gameHeight,
            class: 'gameLayer',
            id: 'heroLayer'
        }).init();
        var heroContext = heroLayer.getCtx();

        var activeHero = gameObject.getHero({
            heroName: 'Gosheto',
            x: CONST.PLAYER_STARTING_COL * CONST.TILE_SIZE + CONST.TILE_SIZE / 2,
            y: CONST.PLAYER_STARTING_ROW * CONST.TILE_SIZE + CONST.TILE_SIZE / 2,
            width: CONST.player_SIZE.w,
            height: CONST.player_SIZE.h,
            layer: 'heroContext',
            color: CONST.player_COLOR
        });

        var Renderer = new renderer();
        Renderer.addContext('mapContext', mapContext);
        Renderer.addContext('heroContext', heroContext);


        Renderer.renderMap('mapContext', CONST.LEVEL);
        Renderer.renderEntity(activeHero);

        var Engine = new engine(heroLayer, {hero: activeHero});
        Engine.start();


        console.log(Renderer)


        mapLayer.canvas.style.display = 'block';
        heroLayer.canvas.style.display = 'block';
        //mainMenuLayer.style.display = 'block';

    };

    return {
        run: run
    }
});