var snake = (function () {
    function GameObject(x, y, size) {
        this.x = x;
        this.y = y;
        this.size = size;
    }

    GameObject.prototype = {
        getPosition: function () {
            return {
                x: this.x,
                y: this.y
            }
        },
        getSize: function () {
            return this.size;
        }
    }

    function SnakePart(x, y, size) {
        GameObject.call(this, x, y, size);
    }
    SnakePart.prototype = new GameObject();
    SnakePart.prototype.constructor = SnakePart;
    SnakePart.prototype.changePosition = function (x, y) {
        this.x = x;
        this.y = y;
    }

    function Snake(x, y, size) {

    }
    Snake.prototype = new GameObject();
    Snake.prototype.constructor = Snake;

    function Wall(x, y, size) {
        GameObject.call(this, x, y, size);
    }
    Wall.prototype = new GameObject();
    Wall.prototype.constructor = Wall;

    function Food(x, y, size) {
        GameObject.call(this, x, y, size);
    }
    Food.prototype = new GameObject();
    Food.prototype.constructor = Food;
}());