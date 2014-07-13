define(['constants'], function (CONST) {
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
                            drawRect(this.contexts[contextName], j * CONST.TILE_SIZE, i * CONST.TILE_SIZE, CONST.TILE_SIZE, CONST.TILE_SIZE, 'black');
                        } else {
                            drawRect(this.contexts[contextName], j * CONST.TILE_SIZE, i * CONST.TILE_SIZE, CONST.TILE_SIZE, CONST.TILE_SIZE, 'white');
                        }
                    }
                }
            },
            renderEntity: function (entity) {
                drawCircle(this.contexts[entity.layer], entity.x, entity.y, 5, entity.color);
            }
        };

        return Renderer;
    }());
    return Renderer;
});