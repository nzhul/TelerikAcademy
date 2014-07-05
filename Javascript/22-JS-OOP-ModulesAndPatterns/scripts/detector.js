var detector = (function () {
    function foodCollision(snake, food, ui) {
        var snakeHeadX = snake.parts[0].getPosition().x;
        var snakeHeadY = snake.parts[0].getPosition().y;
        var foodX = food.getPosition().x;
        var foodY = food.getPosition().y;

        if(snakeHeadX === foodX && snakeHeadY === foodY){
            return true;
        }
    }

    function playFieldCollision(selector, snake, ui) {
        if(selector instanceof HTMLCanvasElement){
            this.canvas = selector;
        } else if(typeof selector === 'String' || typeof selector === 'string'){
            this.canvas = document.querySelector(selector);
        }
        var w = this.canvas.width;
        var h = this.canvas.height;
        if(snake.parts[0].x >= w){
            snake.parts[0].x = 0;
            ui.updateCollision('Playfield');
;        }
        if(snake.parts[0].y >= h){
            snake.parts[0].y = 0;
            ui.updateCollision('Playfield');
        }

        if(snake.parts[0].x < 0){
            snake.parts[0].x = w - 20;
            ui.updateCollision('Playfield');
        }
        if(snake.parts[0].y < 0){
            snake.parts[0].y = h - 20;
            ui.updateCollision('Playfield');
        }
    }

    function tailCollision (snake, ui) {
        for (var i = 1; i < snake.parts.length; i++) {
            if(snake.parts[0].x === snake.parts[i].x
                && snake.parts[0].y === snake.parts[i].y){
                snake.parts = snake.parts.slice(0,2);
                snake.parts[0].x = 0;
                snake.parts[0].y = 0;
                snake.direction = 1;
                ui.scoreValue = 0;
                ui.updateScore(0);
                ui.updateCollision('Tail');
                console.log('Self Tail Collision')
            }
        }
    }

    function wallCollision(wallArray, snake, ui) {
        for (var i = 1; i < wallArray.length; i++) {
            if(snake.parts[0].x === wallArray[i].x
                && snake.parts[0].y === wallArray[i].y){
                snake.parts = snake.parts.slice(0,2);
                snake.parts[0].x = 0;
                snake.parts[0].y = 0;
                snake.direction = 1;
                ui.updateCollision('Wall');
                ui.scoreValue = 0;
                ui.updateScore(0);
                console.log('Wall Collision')
            }
        }
    }

    return {
        isFoodCollision: foodCollision,
        playFieldCollision: playFieldCollision,
        tailCollision: tailCollision,
        wallCollision: wallCollision
    }
}());