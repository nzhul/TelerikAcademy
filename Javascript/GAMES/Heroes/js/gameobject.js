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
                    row: Math.floor(this.y / CONST.TILE_SIZE),
                    col: Math.floor(this.x / CONST.TILE_SIZE)
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

    var Rock = (function () {
        function Rock(options) {
            GameObject.call(this, options);
            this.imageUrl = options.imageUrl || 'img/error.jpg';
        }

        //Hero.prototype = new GameObject({}); // This works too
        Rock.prototype = Object.create(GameObject.prototype);
        Rock.prototype.constructor = Rock;
        Rock.prototype = {

        };

        return Rock;
    }());

    var WalkableCell = (function () {
        function WalkableCell(options) {
            GameObject.call(this, options);
            this.imageUrl = options.imageUrl || 'img/error.jpg';
        }

        //Hero.prototype = new GameObject({}); // This works too
        WalkableCell.prototype = Object.create(GameObject.prototype);
        WalkableCell.prototype.constructor = WalkableCell;
        WalkableCell.prototype = {

        };

        return WalkableCell;
    }());



    return {
        getHero: function (options) {
            return new Hero(options);
        },
        getRock: function (options) {
            return new Rock(options);
        },
        getWalkableCell: function (options) {
            return new WalkableCell(options);
        },
        WalkableCell: WalkableCell
    }
});