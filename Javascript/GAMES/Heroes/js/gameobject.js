define(['constants'], function (CONST) {
    var GameObject = (function () {
        function GameObject(options) {
            this.layer = options.layer;
            this.width = options.width || CONST.TILE_SIZE;
            this.height = options.height || CONST.TILE_SIZE;
            this.x = options.x;
            this.y = options.y;
            this.color = options.color;
        }

        GameObject.prototype = {
            getTilePosition: function () {
                return {
                    // TODO: probably not working
                    row: this.y / CONST.TILE_SIZE,
                    col: this.x / CONST.TILE_SIZE
                }
            }
        };

        return GameObject;
    }());

    var Hero = (function () {
        function Hero(options) {
            GameObject.call(this, options);
            this.heroName = options.heroName;
        }

        //Hero.prototype = new GameObject({}); // This works too
        Hero.prototype = Object.create(GameObject.prototype);
        Hero.prototype.constructor = Hero;
        Hero.prototype = {

        };

        return Hero;
    }());



    return {
        getHero: function (options) {
            return new Hero(options);
        }
    }
});