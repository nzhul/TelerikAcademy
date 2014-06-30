var detector = (function () {
    function foodCollision(snake, food) {
        var snakeHeadX = snake.parts[0].getPosition().x;
        var snakeHeadY = snake.parts[0].getPosition().y;
        var foodX = food.getPosition().x;
        var foodY = food.getPosition().y;

        if(snakeHeadX === foodX && snakeHeadY === foodY){
            return true;
        }
    }

    function wallCollision(selector, snake) {
        if(selector instanceof HTMLCanvasElement){
            this.canvas = selector;
        } else if(typeof selector === 'String' || typeof selector === 'string'){
            this.canvas = document.querySelector(selector);
        }
        var w = this.canvas.width;
        var h = this.canvas.height;
        if(snake.parts[0].x >= w){
            snake.parts[0].x = 0;
        }
        if(snake.parts[0].y >= h){
            snake.parts[0].y = 0;
        }

        if(snake.parts[0].x < 0){
            snake.parts[0].x = w - 20;
        }
        if(snake.parts[0].y < 0){
            snake.parts[0].y = h - 20;
        }
    }

    return {
        isFoodCollision: foodCollision,
        WallCollision: wallCollision
    }
}());