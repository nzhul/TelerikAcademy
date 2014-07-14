define(['constants', 'gameObject'], function (CONST, gameObjects) {
    var Mouse = (function () {
        function Mouse() {
            this.x = 0;
            this.y = 0;
            this.down = false;
            this.initMapEvents = function (mapMatrix , Renderer) {
                var root = document.getElementById('root');
                root.addEventListener('mousemove', function (ev) {
                    var x = ev.offsetX;
                    var y = ev.offsetY;
                    var currCol = Math.floor(x / CONST.TILE_SIZE);
                    var currRow = Math.floor(y / CONST.TILE_SIZE);

                    //console.log(currCol + ' | ' + currRow);
                    // Render Entity in this position mapMatrix[row][col];
                    var hoveredMapCell = mapMatrix[currRow][currCol];
                    if(hoveredMapCell instanceof gameObjects.WalkableCell){
                        Renderer.renderMapCell(hoveredMapCell);
                    }
                })
            }
        }
        return Mouse;
    }());
    return Mouse;
});