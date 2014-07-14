define(['constants', 'gameObject'], function (CONST, gameObjects) {
    var Mouse = (function () {
        function Mouse() {
            this.x = 0;
            this.y = 0;
            this.down = false;
            this.acticeCell;
            var self = this;
            this.initMapEvents = function (mapMatrix , Renderer) {
                var root = document.getElementById('root');
                self.acticeCell = gameObjects.getWalkableCell({
                    x: 0 - CONST.TILE_SIZE,
                    y: 0 - CONST.TILE_SIZE,
                    width: 0,
                    height: 0,
                    layer: 'mapContext',
                    color: 'white'
                });
                root.addEventListener('mousemove', function (ev) {
                    var x = ev.offsetX;
                    var y = ev.offsetY;
                    var currCol = Math.floor(x / CONST.TILE_SIZE);
                    var currRow = Math.floor(y / CONST.TILE_SIZE);

                    Renderer.renderMapCell(self.acticeCell, 'white');
                    var hoveredMapCell = mapMatrix[currRow][currCol];
                    if(hoveredMapCell instanceof gameObjects.WalkableCell){
                        Renderer.renderMapCell(hoveredMapCell, 'yellowgreen');
                        self.acticeCell = hoveredMapCell;
                    }
                })
            }
        }
        return Mouse;
    }());
    return Mouse;
});