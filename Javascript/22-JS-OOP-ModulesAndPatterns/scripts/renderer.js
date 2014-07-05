var renderers = (function () {

    var drawSnake = function (ctx, snake) {
        for (var i = 0; i < snake.parts.length; i++) {
            drawSnakePart(ctx, snake.parts[i]);
        }
    };

    var drawSnakePart = function (ctx, part) {
        ctx.fillStyle = 'orange';
        var position = part.getPosition();
        ctx.fillRect(position.x, position.y, part.size, part.size);
    };

    var drawFood = function (ctx, food) {
        ctx.fillStyle = 'yellowgreen';
        var position = food.getPosition();
        ctx.fillRect(position.x, position.y, food.size, food.size);
    };

    var drawWall = function (ctx, wall) {
        ctx.fillStyle = 'black';
        var position = wall.getPosition();
        ctx.fillRect(position.x, position.y, wall.size, wall.size);
    };

    function CanvasRenderer(selector) {
        if(selector instanceof HTMLCanvasElement){
            this.canvas = selector;
            this.context = this.canvas.getContext('2d');
        } else if(typeof selector === 'String' || typeof selector === 'string'){
            this.canvas = document.querySelector(selector);
            this.context = this.canvas.getContext('2d');
        }
    }

    CanvasRenderer.prototype = {
        draw: function (obj) {
            if(obj instanceof snakes.SnakeType){
                drawSnake(this.context, obj);
            }
            else if(obj instanceof snakes.SnakePartType) {
                drawSnakePart(this.context, obj);
            }
            else if(obj instanceof snakes.FoodType) {
                drawFood(this.context, obj);
            }
            else if(obj instanceof snakes.WallType) {
                drawWall(this.context, obj);
            }
        },
        clear: function () {
            var ctx = this.canvas.getContext('2d');
            var w = this.canvas.width;
            var h = this.canvas.height;
            ctx.clearRect(0, 0, w, h);
        }
    };

    return {
        getCanvas: function (selector) {
            return new CanvasRenderer(selector);
        }
    }
}());