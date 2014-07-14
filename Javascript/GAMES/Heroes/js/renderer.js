define(['constants', 'gameObject'], function (CONST, gameObject) {
    // Helpers
    function drawCircle(ctx, x, y, r, color) {
        ctx.beginPath();
        ctx.arc(x, y, r, 0, Math.PI * 2, true);
        ctx.fillStyle = color;
        ctx.closePath();
        ctx.fill();
    };
    function drawRect(ctx, x, y, w, h, color) {
        ctx.beginPath();
        ctx.rect(x, y, w, h);
        ctx.fillStyle = color;
        ctx.stroke();
        ctx.closePath();
        ctx.fill();

    };
    // Helpers end


    var Renderer = (function () {
        function Renderer(context) {
            this.contexts = [];
        }

        Renderer.prototype = {
            addContext: function (name, context) {
              this.contexts[name] = context;
            },
            renderMap: function (contextName, mapMatrix) {
                var rows = mapMatrix.length;
                var cols = mapMatrix[0].length;
                this.contexts[contextName].clearRect(0, 0, this.contexts[contextName].canvas.width, this.contexts[contextName].canvas.height);
                for (var i = 0; i < rows; i++) {
                    for (var j = 0; j < cols; j++) {
                        if (mapMatrix[i][j] === 1) {
                            mapMatrix[i][j] = gameObject.getRock({
                                x: j * CONST.TILE_SIZE,
                                y: i * CONST.TILE_SIZE,
                                width: CONST.TILE_SIZE,
                                height: CONST.TILE_SIZE,
                                layer: 'mapContext',
                                color: 'black'
                            });
                            drawRect(this.contexts[contextName], j * CONST.TILE_SIZE, i * CONST.TILE_SIZE, CONST.TILE_SIZE, CONST.TILE_SIZE, 'black');
                        } else if(mapMatrix[i][j] === 0) {
                            mapMatrix[i][j] = gameObject.getWalkableCell({
                                x: j * CONST.TILE_SIZE,
                                y: i * CONST.TILE_SIZE,
                                width: CONST.TILE_SIZE,
                                height: CONST.TILE_SIZE,
                                layer: 'mapContext',
                                color: 'white'
                            });
                            drawRect(this.contexts[contextName], j * CONST.TILE_SIZE, i * CONST.TILE_SIZE, CONST.TILE_SIZE, CONST.TILE_SIZE, 'white');
                        }
                    }
                }
                var populatedMap = mapMatrix;
                return populatedMap;
            },
            renderEntity: function (entity) {
                drawCircle(this.contexts[entity.layer], entity.x, entity.y, 5, entity.color);
            },
            clearLayer: function (layer) {
                layer.clearRect(0, 0, layer.canvas.width, layer.canvas.height);
            },
            renderMapCell: function (cell) {
                drawRect(this.contexts[cell.layer], cell.x, cell.y, CONST.TILE_SIZE, CONST.TILE_SIZE, 'red');
                //drawCircle(this.contexts[entity.layer], entity.x, entity.y, 5, entity.color);
            }
        };

        return Renderer;
    }());
    return Renderer;
});