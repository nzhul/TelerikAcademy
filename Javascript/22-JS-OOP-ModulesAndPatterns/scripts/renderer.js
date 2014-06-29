var renderers = (function () {

    var drawSnake = function (canvas, snake) {
        for (var i = 0; i < snake.parts.length; i++) {
            drawSnakePart(canvas, snake.parts[i]);
        }
    };

    var drawSnakePart = function (canvas, part) {
        var ctx = canvas.getContext('2d');
        ctx.fillStyle = 'orange';
        var position = part.getPosition();
        ctx.strokeStyle = 'black';
        ctx.fillRect(position.x, position.y, part.size, part.size);
        ctx.strokeRect(position.x, position.y, part.size, part.size);
    };

    var drawFood = function (canvas, food) {
        var ctx = canvas.getContext('2d');
        ctx.fillStyle = 'green';
        var position = food.getPosition();
        ctx.fillRect(position.x, position.y, food.size, food.size);
    };

    var drawWall = function (canvas, wall) {
        var ctx = canvas.getContext('2d');
        ctx.fillStyle = 'black';
        var position = wall.getPosition();
        ctx.fillRect(position.x, position.y, wall.size, wall.size);
    };

    function CanvasRenderer(selector) {
        if(selector instanceof HTMLCanvasElement){
            this.canvas = selector;
        } else if(typeof selector === 'String' || typeof selector === 'string'){
            this.canvas = document.querySelector(selector);
        }
    }

    CanvasRenderer.prototype = {
        draw: function (obj) {
            if(obj instanceof snakes.SnakeType){
                drawSnake(this.canvas, obj);
            }
            else if(obj instanceof snakes.SnakePartType) {
                drawSnakePart(this.canvas, obj);
            }
            else if(obj instanceof snakes.FoodType) {
                drawFood(this.canvas, obj);
            }
            else if(obj instanceof snakes.WallType) {
                drawWall(this.canvas, obj);
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