define(['constants'], function () {
    var GameObject = (function () {
        function GameObject(options) {
            this.x = options;
            this.y = options;
            this.color = options;
        }

        GameObject.prototype = {

        };

        return GameObject;
    }());

    var Hero = (function () {
        function Hero(options) {
            GameObject.call(this, options);
        }

        Hero.prototype = new GameObject();
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