var games = (function () {

    function Game(renderer) {
        this.renderer = renderer;
        this.snake = new snakes.get(250, 250, 15);
    }
    
    Game.prototype = {
        start: function () {
            requestAnimationFrame(this.engine);
        },
        stop: function () {

        },
        engine: function () {
            this.snake.move();
            this.renderer.clear();
            this.renderer.draw(theSnake);
            this.renderer.draw(food);
            requestAnimationFrame(engine);
        }
    };



    return {
        get: function (renderer) {
            return new Game(renderer);
        }
    };
}());