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
        ctx.closePath();
        ctx.fill();

    };
    // Helpers end


    var Renderer = (function () {
        function Renderer(context) {
            this.ctx = context;
        }

        Renderer.prototype = {
            renderMap: function () {
            this.ctx.clearRect(0, 0, this.ctx.canvas.width, this.ctx.canvas.height);
                for (var i = 0; i < CONST.LEVEL_ROWS; i++) {
                    for (var j = 0; j < CONST.LEVEL_COLS; j++) {
                        if (CONST.LEVEL[i][j] === 1) {
                            drawRect(this.ctx, j * CONST.TILE_SIZE, i * CONST.TILE_SIZE, CONST.TILE_SIZE, CONST.TILE_SIZE, 'black');
                        }
                    }
                }
            }
        };

        return Renderer;
    }());
    return Renderer;
});