define(['gameObject', 'layer'], function (gameObject, Layer) {
    var run = function () {
        var mapLayer = new Layer('#root', {
            width: 450,
            height: 450,
            id: 'map'
        }).init();
        var mapContext = mapLayer.getCtx();
        var activeHero = gameObject.getHero({
            x: 50,
            y: 50,
            width: 15,
            height: 15,
            layer: mapContext,
            color: 'red'
        });

        console.log(activeHero)

    };

    return {
        run: run
    }
});