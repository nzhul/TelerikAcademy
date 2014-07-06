define(['constants'], function () {
    var GameObject = (function () {
        function GameObject(options) {
            this.x = options.x;
            this.y = options.y;
            this.color = options.color;
        }

        GameObject.prototype = {

        };

        return GameObject;
    }());

    var Hero = (function () {
        function Hero(options) {
            GameObject.call(this, options);
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