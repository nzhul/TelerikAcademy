define(['gameObject', 'layer', 'constants', 'renderer'], function (gameObject, Layer, CONST, renderer) {
    var run = function () {
        var mapLayer = new Layer('#root', {
            width: CONST.TILE_SIZE * CONST.LEVEL_COLS,
            height: CONST.TILE_SIZE * CONST.LEVEL_ROWS,
            id: 'map'
        }).init();
        var mapContext = mapLayer.getCtx();

        var Renderer = new renderer(mapContext);
        Renderer.renderMap();

        var activeHero = gameObject.getHero({
            x: CONST.PLAYER_STARTING_COL * CONST.TILE_SIZE,
            y: CONST.PLAYER_STARTING_ROW * CONST.TILE_SIZE,
            width: CONST.player_SIZE.w,
            height: CONST.player_SIZE.h,
            layer: mapContext,
            color: CONST.player_COLOR
        });



        console.log(activeHero)

    };

    return {
        run: run
    }
});