define([], function () {
    var Engine = (function () {
        function Engine(context, renderer, objects) {
            this.layer = context;
            this.objects = objects || [];
            var self = this;
            this.start = function engine() {

                // Update Stuff
                //console.log(self.objects.hero.y--);

                // Redraw Stuff
                renderer.clearLayer(context);
                renderer.renderEntity(self.objects.hero);

                requestAnimationFrame(function () {
                    engine(self.layer, self.objects);
                });
            }
        }

        return Engine;
    }());
    return Engine;
});