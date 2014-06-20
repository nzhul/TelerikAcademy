/**
 * Created by kakadu5 on 20.6.2014 г..
 */
window.onload = function(){

    function Layer(parent, options){
        this.width = options.width;
        this.height = options.height;
        this.id = options.id || 'unknown';
        this.parent = parent;
        var self = this;
        this.init = function () {
            var canvas = document.createElement('canvas');
            canvas.width = self.width;
            canvas.height = self.height;
            canvas.id = self.id;
            var parent = document.querySelector(self.parent);
            parent.appendChild(canvas);
            return canvas.getContext('2d');
        }
    }

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

    function Player(layer ,x, y) {
        this.layer = layer;
        this.x = x;
        this.y = y;
        this.w = player_SIZE.w;
        this.h = player_SIZE.h;
        this.color = player_COLOR;
        var self = this;
        this.drawPlayer = function () {
            drawRect(self.layer ,self.x, self.y, this.w, this.h, this.color);
            return self;
        };

    }

    var currentTarget = {

    }

    // ------------------------------------------------- FUNCTIONS ----------------


    var mapLayer = new Layer('#root',
    {
        width: mapLayer_WIDTH,
        height: mapLayer_HEIGHT,
        id: 'map'
    }).init();

    var Knight = new Player(mapLayer, 50, 50).drawPlayer();
    var gosheto = 1;



}

