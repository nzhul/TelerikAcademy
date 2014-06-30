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

    return {
        isFoodCollision: foodCollision
    }
}());