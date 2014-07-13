define([], function () {
    window.requestAnimationFrame = (function (callback) {
        return window.requestAnimationFrame || window.webkitRequestAnimationFrame || window.mozRequestAnimationFrame ||
            window.oRequestAnimationFrame || window.msRequestAnimationFrame ||
            function (callback) {
                window.setTimeout(callback, 1000 / 60);
            };
    }());

    var Engine = (function () {
        function Engine(layer, objects) {
            this.layer = layer;
            this.objects = objects || [];
        }

        Engine.prototype = {
            start: function () {
                // THIS IS NOT WORKING - FIX IT
                this.objects.hero.x++;
                var engine = this;
                requestAnimationFrame(function () {
                    engine(this.layer, this.objects);
                    console.log('loop');
                });
            }
        };

        return Engine;
    }());
    return Engine;
});