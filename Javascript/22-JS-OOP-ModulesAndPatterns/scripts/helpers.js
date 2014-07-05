var helpers = (function () {
    function getRandomInt(min, max){
        var randomInt = Math.floor(Math.random() * (max - min + 1)) + min;
        return randomInt;
    }

    function Position(x, y) {
        this.x = x;
        this.y = y;
    }

    return {
        getRandomInt: getRandomInt,
        getRandomPosition: function () {
            return new Position((getRandomInt(0, 475/15)) * 15, (getRandomInt(0, 475/15)) * 15);
        }
    }
}());